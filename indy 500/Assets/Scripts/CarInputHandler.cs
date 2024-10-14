using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;

public class CarInputHandler : MonoBehaviour
{
    // Components
    CarController carController;

    bool active = true;

    // Start is called before the first frame update
    void Awake()
    {
        carController = GetComponent<CarController>();
    }

    // Starts the timer when the first fram is updated
    private void Start(){
        EventManager.StopGame += EventManagerOnStopGame;
        OnTimerStart();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (active){
            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");

            carController.SetInputVector(inputVector);
        }
    }
    void EventManagerOnStopGame() => active = false;
}
