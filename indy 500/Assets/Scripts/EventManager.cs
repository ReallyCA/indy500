/***********************************************************************
* file: EventManager.cs
* author: Ivan Trinh, Anthony Jimenez, chunky bacon gamer
* class: CS 4700 - Game Development
* assignment: Program 3
* date last modified: 10/13/2024
*
* purpose: This program was partially developed by chunky bacon gamer on
* youtube, who also developed the Timer.cs file. We added more events to
* keep track of how many laps have been completed, in addition to if the
* game should still accept inputs based on if the timer is still running.
*
***********************************************************************/
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction TimerStart;
    public static event UnityAction TimerStop;
    public static event UnityAction<float> TimerUpdate;
    public static event UnityAction StopGame;
    public static event UnityAction<int> LapUpdate;

    public static void OnTimerStart() => TimerStart?.Invoke();
    public static void OnTimerStop() => TimerStop?.Invoke();
    public static void OnTimerUpdate(float value) => TimerUpdate?.Invoke(value);
    public static void OnStopGame() => StopGame?.Invoke();
    public static void OnLapUpdate(int laps) => LapUpdate?.Invoke(laps);
}