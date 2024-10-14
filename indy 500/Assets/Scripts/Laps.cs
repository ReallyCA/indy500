/***********************************************************************
* file: Laps.cs
* author: Ivan Trinh, Anthony Jimenez
* class: CS 4700 - Game Development
* assignment: Program 3
* date last modified: 10/13/2024
*
* purpose: This program is mainly to display the number of laps that the
* car has already driven, and it gets its lap count from CarLapCounter
* through a UnityEvent, which is more documented in the EventManager 
* file. This program uses TMPro to update the text on the screen.
*
***********************************************************************/
using System;
using UnityEngine;
using TMPro;

public class Lap : MonoBehaviour
{
    private TMP_Text _lapText;
    public int lapsDone = 0;
    private void Awake(){
        _lapText = GetComponent<TMP_Text>();
        EventManager.LapUpdate += EventManagerOnLapUpdate;
    }
    private void EventManagerOnLapUpdate(int laps) => lapsDone = laps;
    private void Update(){
        _lapText.text = lapsDone.ToString();
    }


    
}
