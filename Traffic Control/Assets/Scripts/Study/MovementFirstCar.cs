using UnityEngine;

public class MovementFirstCar : MonoBehaviour
{
    public GameObject canvasFirst, secondCar, canvasSecond;
    private bool isFirst;
    private CarController _controller;


    private void Start()
    {
        _controller = GetComponent<CarController>();
    }


    private void Update()
    {
        if (transform.position.x < 8f && !isFirst)
        {
            isFirst = false;
            GetComponent<CarController>().speed = 0f;
            canvasFirst.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (!isFirst || transform.position.x > 9f)
            return;
        _controller.speed = 15f;
        canvasFirst.SetActive(false);
        canvasSecond.SetActive(false);
        
        secondCar.GetComponent<CarController>().speed = 12f;
    }

}
