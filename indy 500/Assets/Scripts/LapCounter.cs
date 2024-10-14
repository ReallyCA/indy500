using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    // important variables to determine checkpoints and if a lap has been properly done
    int currentCheckpoint = 0;
    int totalCheckpoints = 4;
    int totalLaps = 0;


    // Checks for the collision to be specifically either a checkpoint or the finish line
    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.CompareTag("CheckPoint")){ // checks if we hit the previous sequential checkpoint
            CheckPoint checkPoint = collider2D.GetComponent<CheckPoint>();
            if (currentCheckpoint + 1 == checkPoint.checkPointNumber){
                currentCheckpoint = checkPoint.checkPointNumber;
                print(currentCheckpoint);
            }
        } else if (collider2D.CompareTag("Finish")){ // checks if we hit all the checkpoints first
            if (currentCheckpoint == totalCheckpoints){ // if so, we did a full lap
                currentCheckpoint = 0;
                totalLaps++;
                print(totalLaps);
            }
        }

    }
}
