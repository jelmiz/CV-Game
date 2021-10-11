using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;

    public Joystick joystick;
    [Header("Values")]
    public float turnSpeed = 10f;
    public float force = 1500f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    float rotation = 0f;

    void Start()
    {
      
      Rigidbody rb = gameObject.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        //Referencing the joystic
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
        
        //If joystic is in horizontal position, turn.
        if(Input.touchCount > 0){
            if(horizontalMove < 0 || horizontalMove > 0) {
                rb.rotation =  rb.rotation * Quaternion.AngleAxis(horizontalMove * turnSpeed, Vector3.up);
              }
              
              //If joystic in vertical position, add force relative to joystic position
              if(verticalMove < 0 || verticalMove > 0) {
             rb.AddRelativeForce(0,0, (verticalMove* force) * Time.deltaTime);
              }
        } 
    }
}
