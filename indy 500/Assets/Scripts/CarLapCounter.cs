using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLapCounter : MonoBehaviour
{
    int currentCheckpoint = 0;
    int totalCheckpoints = 4;
    int lapCounter = 0;

    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.CompareTag("CheckPoint")){
            CheckPoint checkPoint = collider2D.GetComponent<CheckPoint>();
            if (currentCheckpoint + 1 == checkPoint.checkPointNumber){
                currentCheckpoint = checkPoint.checkPointNumber;
            }
            print("Current Checkpoint: " + currentCheckpoint);
        } else if (collider2D.CompareTag("Finish")){
            if (currentCheckpoint == totalCheckpoints){
                lapCounter += 1;
                currentCheckpoint = 0;
                EventManager.OnLapUpdate(lapCounter);
            }
            print("Laps Done: " + lapCounter);
        }
    }
    
}
