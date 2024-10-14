/***********************************************************************
* file: CarLapCounter.cs
* author: Ivan Trinh, Anthony Jimenez
* class: CS 4700 - Game Development
* assignment: Program 3
* date last modified: 10/13/2024
*
* purpose: This program is used by the car in order to check which 
* checkpoints have been passed, in addition to if a lap has been 
* completed. This program also calls a UnityEvent in order to update
* how many laps have been done on screen. 
*
***********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLapCounter : MonoBehaviour
{
    int currentCheckpoint = 0;
    int totalCheckpoints = 4;
    int lapCounter = 0;

    // Checks which kind of checkpoint had been passed
    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.CompareTag("CheckPoint")){ // standard checkpoint
            CheckPoint checkPoint = collider2D.GetComponent<CheckPoint>();
            if (currentCheckpoint + 1 == checkPoint.checkPointNumber){
                currentCheckpoint = checkPoint.checkPointNumber;
            }
            print("Current Checkpoint: " + currentCheckpoint); // left in for testing
        } else if (collider2D.CompareTag("Finish")){ // finish line
            if (currentCheckpoint == totalCheckpoints){
                lapCounter += 1;
                currentCheckpoint = 0;
                EventManager.OnLapUpdate(lapCounter);
            }
            print("Laps Done: " + lapCounter); // left in for testing
        }
    }
    
}
