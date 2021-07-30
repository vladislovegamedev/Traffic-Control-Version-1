using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public GameObject[] maps;
    public bool isMenuScene;
    public float timeToSpawnFrom = 2f, timeToSpawnTo = 4.5f;
    public GameObject[] cars;
    public int countCars;
    private Coroutine bottomCars, leftCars, rightCars, upCars;
    private bool stopCheck;
    public GameObject canvasLosePanel;
    public Text nowScore, topScore, coinsCount;
    public GameObject horn;
    public AudioSource turnSignal;
    [NonSerialized] public static int countLoses;
    private static bool isAdd;
    public GameObject AdObject;
    

    private void Start()
    {   if (!isAdd && PlayerPrefs.GetString("NoAds") !="yes")
        {
            isAdd = true;
            Instantiate(AdObject, Vector3.zero, Quaternion.identity);
        }

        if (!isMenuScene)
        {

        }

        if(PlayerPrefs.GetInt("NowMap") == 2)
        {
            Destroy(maps[0]);
            Destroy(maps[2]);
            maps[1].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("NowMap") == 3 )
        {
            Destroy(maps[0]);
            Destroy(maps[1]);
            maps[2].SetActive(true);
        }
        else 
        {
            Destroy(maps[1]);
            Destroy(maps[2]);
            maps[0].SetActive(true);
        }

        CarController.countCars = 0;
        CarController.isLose = false;

        if (isMenuScene)
        {
            timeToSpawnFrom = 3f;
            timeToSpawnTo = 6f;
        }

        
        bottomCars = StartCoroutine(BottomCars());
        leftCars = StartCoroutine(LeftCars());
        rightCars = StartCoroutine(RightCars());
        upCars = StartCoroutine(UpCars());

        

        StartCoroutine(CreateHorn());
    }

    


    private void Update()
    {
        if (CarController.isLose && !stopCheck )
        {
            countLoses++;
            StopCoroutine(bottomCars);
            StopCoroutine(leftCars);
            StopCoroutine(rightCars);
            StopCoroutine(upCars);
            stopCheck = true;
            canvasLosePanel.SetActive(true);
            nowScore.text = "<color=blue>SCORE: </color>" + CarController.countCars.ToString();
            if (PlayerPrefs.GetInt("Score") < CarController.countCars)
            {
                PlayerPrefs.SetInt("Score", CarController.countCars);
            }
            topScore.text = "<color=red>SCORE: </color>" + PlayerPrefs.GetInt("Score").ToString() ;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")+ CarController.countCars);

            coinsCount.text = "<color=black>" + PlayerPrefs.GetInt("Coins").ToString() +"</color>";

        }
    }

    IEnumerator BottomCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(-2.27f, 0f, -21.6f), 180f);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    
    IEnumerator LeftCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(-95f, 0f, 3.1f), 270f);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    IEnumerator RightCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(25.6f, 0f, 10f), 90f);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    IEnumerator UpCars()
    {
        while (true)
        {
            SpawnCar(new Vector3(-9.5f, 0f, 88f), 0f,isMoveFromUp:true);
            float timeToSpawn = Random.Range(timeToSpawnFrom, timeToSpawnTo);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }


    void SpawnCar(Vector3 pos, float rotationY, bool isMoveFromUp = false)
    {
        GameObject newObj = Instantiate(cars[Random.Range(0, cars.Length)], pos, Quaternion.Euler(0, rotationY, 0)) as GameObject;

        newObj.name = "Car - " + ++countCars;

        int random = isMenuScene ? 1 : Random.Range(1, 4);

        if (isMenuScene)
            newObj.GetComponent<CarController>().speed = 15f;

        switch (random)
        {
            case 1:
                newObj.GetComponent<CarController>().rightTurn = true;

                if (PlayerPrefs.GetString("music") != "No" && !turnSignal.isPlaying)
                {
                    turnSignal.Play();
                    Invoke("StopSound", 4f);
                }
                break;
            case 2:
                newObj.GetComponent<CarController>().leftTurn = true;
                if (PlayerPrefs.GetString("music") != "No" && !turnSignal.isPlaying) { 
                    turnSignal.Play();
                Invoke("StopSound", 4f); }
                if (isMoveFromUp)
                    newObj.GetComponent<CarController>().moveFromUp = true;
                break;
            case 3:

                break;


        }



        
    }

    void StopSound()
    {
        turnSignal.Play();
    }

    IEnumerator CreateHorn()
    {

        while (true)
        {
            
            yield return new WaitForSeconds(Random.Range(4, 7));
            if (PlayerPrefs.GetString("music") != "No")
                Instantiate(horn, Vector3.zero, Quaternion.identity);
        }
    }
}
