/***********************************************************************
* file: CarInputHandler.cs
* author: Ivan Trinh, Anthony Jimenez
* class: CS 4700 - Game Development
* assignment: Program 3
* date last modified: 10/13/2024
*
* purpose: This program is for receiving user input, and forwarding it 
* to CarController. This program also checks to see if the timer is 
* still active, but if it isn't, then the program stops accepting user
* input.
*
***********************************************************************/
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

    // Starts the timer when the first frame is updated
    private void Start(){
        EventManager.StopGame += EventManagerOnStopGame;
        OnTimerStart();
    }

    // Used for checking which inputs the user has provided
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
