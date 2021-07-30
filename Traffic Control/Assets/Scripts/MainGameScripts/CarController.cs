using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using Random = UnityEngine.Random;


[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour 
{ 
    public bool rightTurn, leftTurn, moveFromUp;
    public float speed = 15f, force =50f;
    private Rigidbody carRb; 
    private float rotateMultRight = 6f, rotateMultLeft = 4.5f, originRotationY;
    private Camera mainCam;  
    public LayerMask carsLayer; 
    private bool isMovingFast; 
    [NonSerialized] public bool carPassed;
    public GameObject turnLeftSignal, turnRightSignal, explosion, exhaust;
    [NonSerialized] public static bool isLose;
    [NonSerialized] public static int countCars;
    public AudioClip crash;   
    public AudioClip[] accelerator;

    private void Start()  
    {
        mainCam = Camera.main;
        carRb = GetComponent<Rigidbody>();
        originRotationY = transform.eulerAngles.y; 

        if (rightTurn)
            StartCoroutine(TurnSignals(turnRightSignal));
        else if (leftTurn) 
            StartCoroutine(TurnSignals(turnLeftSignal));
    } 

     

    IEnumerator TurnSignals(GameObject turnSignal)
    {
        while (!carPassed)
        {
            turnSignal.SetActive(!turnSignal.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }
    }
     
        private void FixedUpdate()
    {
        carRb.MovePosition(transform.position - transform.forward * speed * Time.fixedDeltaTime);
    }

    private void Update()
    {
 #if UNITY_EDITOR
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

 #else
        if (Input.touchCount == 0)
            return;
        Ray ray = mainCam.ScreenPointToRay(Input.GetTouch(0).position);
 #endif 
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance: 100f, carsLayer))
        {
            string carName = hit.transform.gameObject.name;
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0) && !isMovingFast && gameObject.name == carName)
            {
#else
                 if (Input.GetTouch(0).phase == TouchPhase.Began && !isMovingFast && gameObject.name == carName)
                 {
#endif

                     GameObject vfx = Instantiate(exhaust, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
                     Destroy(vfx, 2f);
                     speed *= 2.5f;
                     isMovingFast = true;


                     if (PlayerPrefs.GetString("music") != "No")
                     {
                         GetComponent<AudioSource>().clip = accelerator[Random.Range(0, accelerator.Length)];
                         GetComponent<AudioSource>().Play();
                     }

                 }
            
        } 
    }

    
    
    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.CompareTag("Car"))
      {
        isLose = true;
        speed = 0f;
        other.gameObject.GetComponent<CarController>().speed = 0f;
        GameObject vfx = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 4f);

        if (isMovingFast)
            force *= 1.2f;

        carRb.AddRelativeForce(Vector3.back * force); 

        if (PlayerPrefs.GetString("music") != "No")
        {
            GetComponent<AudioSource>().clip = crash;
            GetComponent<AudioSource>().Play();
        }
      }
    }



    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Car") && other.GetComponent<CarController>().carPassed)
         
         other.GetComponent<CarController>().speed = speed;
        
    }

    private void OnTriggerStay(Collider other)
    {
         if (isLose)
        return;
        if (other.transform.CompareTag("TurnBlock Right") && rightTurn)
        {
            RotateCar(rotateMultRight);
        }
        else if(other.transform.CompareTag("TurnBlock Left") && leftTurn)
        {
            RotateCar(rotateMultLeft,  -1);
        }

    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Trigger Pass"))
    {   if (carPassed)
            return;
        carPassed = true;
        Collider[] colliders = GetComponents<BoxCollider>();
        foreach (Collider col in colliders)
            col.enabled = true;
        countCars++;
    }
        if (other.transform.CompareTag("TurnBlock Right") && rightTurn)
            carRb.rotation = Quaternion.Euler(0, originRotationY + 90f, 0);
        else if (other.transform.CompareTag("TurnBlock Left") && leftTurn)
            carRb.rotation = Quaternion.Euler(0, originRotationY - 90f, 0);
        else if (other.transform.CompareTag("DestroyCars"))
            
            Destroy(gameObject);
    }

    private void RotateCar(float speedRotate, int dir = 1)
                
    {          if (isLose)
                 return; 
     
    if (dir == -1 && transform.localRotation.eulerAngles.y < originRotationY - 90f)
            return;
                if (dir == -1 && moveFromUp && transform.localRotation.eulerAngles.y > 250f && dir == -1 && transform.localRotation.eulerAngles.y < 270f)
            return;
                float rotateSpeed = speed * speedRotate * dir;
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotateSpeed* Time.fixedDeltaTime, 0) );
                carRb.MoveRotation(carRb.rotation * deltaRotation);
    }
}
