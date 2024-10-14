/***********************************************************************
* file: CarSfxHandler.cs
* author: Ivan Trinh, Anthony Jimenez
* class: CS 4700 - Game Development
* assignment: Program 3
* date last modified: 10/13/2024
*
* purpose: This program is used to produce audio regarding what the car
* is doing right now, such as accelerating or hitting a wall.
*
***********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarSfxHandler : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource engineAudioSource;
    public AudioSource carHitAudioSource;

    // only used to find the velocity of the car
    CarController carController;
    void Awake()
    {
        carController = GetComponentInParent<CarController>();
    }

    // Update is called once per frame, adjusts the pitch of the engine
    void Update()
    {
        UpdateEngineSFX();
    }

    // The pitch of the engine is completely dependent on how fast the car is going
    void UpdateEngineSFX(){
        float velocityMag = carController.GetVelocityMagnitude();

        float desiredEngineVolume = Mathf.Clamp((velocityMag * 0.05f), 0.2f, 1.0f);
        engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume,desiredEngineVolume, Time.deltaTime * 10);

        float desiredEnginePitch = Mathf.Clamp((velocityMag * 1f), 0.5f, 8.0f);
        engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);

    }

    // calls only if it hits a wall, random pitch + volume dependent on how fast the car hit the wall
    void OnCollisionEnter2D(Collision2D collider2D){
        float relativeVelocity = collider2D.relativeVelocity.magnitude;
        float volume = relativeVelocity * 0.1f;

        carHitAudioSource.pitch = Random.Range(0.6f, 1.1f);
        carHitAudioSource.volume = volume;

        if (!carHitAudioSource.isPlaying)
            carHitAudioSource.Play();
        
    }

}
