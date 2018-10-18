using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public bool left_front_on;          // stores variable for turning on/off left FRONT wheel
    public bool right_front_on;         // stores variable for turning on/off right FRONT wheel
    public bool left_back_on;           // stores variable for turning on/off left BACK wheel
    public bool right_back_on;          // stores variable for turning on/off right BACK wheel

    public bool sensor_on;        // stores variable for turning on/off sensor
    public bool sensor_detect;    // stores variable for whether the sensor detects an object (yes/no)

    public float left_front_w;     // stores variable for FRONT left wheel's angular velocity
    public float right_front_w;    // stores variable for FRONT right wheel's angular velocity
    public float left_back_w;      // stores variable for BACK left wheel's angular velocity
    public float right_back_w;     // stores variable for BACK right wheel's angular velocity

    private float linear_velocity;  // stores a variable for linear velocity of the robot 
    private Rigidbody2D robot;      // stores a reference to the entire robot

    // Use this for initialization
    void Start () {

		
	}

    // Physics code
    private void FixedUpdate()
    {
        // sets angular vel. of wheel to 0 if wheel is off
        if (left_front_on == false)
        {
            left_front_w = 0; 
        }

        if (right_front_on == false)
        {
            right_front_w = 0;
        }

        if (left_back_on == false)
        {
            left_back_w = 0; 
        }

        if (right_back_on == false)
        {
            right_back_w = 0; 
        }

        float moveLeft;
        float moveRight;

        Vector2 movement = new Vector2(moveLeft, moveRight);

        // player moves in direction movement at calculated linear velocity
        robot.AddForce(movement * linear_velocity);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
