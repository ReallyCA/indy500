/***********************************************************************
* file: Boundaries.cs
* author: Ivan Trinh, Anthony Jimenez
* class: CS 4700 - Game Development
* assignment: Program 3
* date last modified: 10/13/2024
*
* purpose: This program is just a failsafe in case the car somehow 
* manages to go out of bounds, in which the car is set within the camera.
*
***********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour{
    private Vector2 screenBounds;

    // Start is called before the first frame update, sets the boundaries where the car can go
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1, screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);
        transform.position = viewPos;
    }
}
