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
