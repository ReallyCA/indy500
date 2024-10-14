/***********************************************************************
* file: CarController.cs
* author: Ivan Trinh, Anthony Jimenez
* class: CS 4700 - Game Development
* assignment: Program 3
* date last modified: 10/13/2024
*
* purpose: This program is used by the car in order to actually move the
* car. With user input, the car should behave similar to an actual car,
* where it slows down naturally without any throttle, and turn naturally
* depending on the velocity and angle it's going at.
*
***********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Base Settings for the car, can be adjusted to preference
    [Header("Car Settings")]
    public float accelerationF = 2.0f;
    public float decelF = 1.0f;
    public float turnF = 3.5f;
    public float driftF = 0.95f;
    public float maxspeed = 5f;

    // Parameters for the car during gameplay
    float currAcceleration = 0;
    float currSteering = 0;
    float rotationAngle = 90;
    float velocity = 0;


    Rigidbody2D carRigidbody2D; // Refers to the car

    // Called when script instance is being loaded, generates the car's body
    void Awake(){
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Frame-rate independent physics calculations
    void FixedUpdate(){
        ApplyEngineForce();
        KillOrthogonalVelocity();
        ApplySteering();
    }

    //Creates a force to accelerate/deccelerate the car, also limits top speed
    void ApplyEngineForce(){
        velocity = Vector2.Dot(transform.up, carRigidbody2D.velocity);

        if (velocity > maxspeed && currAcceleration > 0){ // limiting front top speed
            return;
        }
        if (velocity < -maxspeed * 0.5f && currAcceleration < 0){ // reverse top speed
            return;
        }

        if (carRigidbody2D.velocity.sqrMagnitude > maxspeed * maxspeed && currAcceleration > 0){
            return; // for cases where the car is not going straight
        }

        if (currAcceleration == 0){ // applies deacceleration if the throttle is off
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, decelF, Time.fixedDeltaTime * 3);
        } else carRigidbody2D.drag = 0;
        Vector2 engineForceVector = transform.up * currAcceleration * accelerationF;
        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    //Based on current steering input, the rotational angle is updated and applied
    void ApplySteering(){
        float minSpeedBeforeTurning = (carRigidbody2D.velocity.magnitude / 8);
        minSpeedBeforeTurning = Mathf.Clamp01(minSpeedBeforeTurning);
        
        rotationAngle -= currSteering * turnF * minSpeedBeforeTurning;
        carRigidbody2D.MoveRotation(rotationAngle);

    }

    // Ensures that the car turns smoothly basically
    void KillOrthogonalVelocity(){
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);

        carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftF;
    }

    // Updates what the player wants the car to do (i.e turn/move forward)
    public void SetInputVector(Vector2 inputVector){
        currSteering = inputVector.x;
        currAcceleration = inputVector.y;
    }

    // should basically ground the car to a halt when hitting a wall
    void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.CompareTag("Wall")){ // checks if we hit the previous sequential checkpoint
            Vector2 engineForceVector = transform.up * currAcceleration * accelerationF;
            carRigidbody2D.AddForce(-engineForceVector, ForceMode2D.Force);
        } 
    }
}
