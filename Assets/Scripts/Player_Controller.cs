using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using timer = Countdown;

public class Player_Controller : MonoBehaviour
{

    public bool left_front_on;          // turns on/off left FRONT wheel
    public bool right_front_on;         // turns on/off right FRONT wheel

    // public bool left_back_on;        // turning on/off left BACK wheel
    // public bool right_back_on;       // turning on/off right BACK wheel

    public bool sensor_on;              // turns on/off sensor
    public bool sensor_detect;          // whether the sensor detects an object (yes/no)

    public float left_front_w;          // FRONT left wheel's angular velocity
    public float right_front_w;         // FRONT right wheel's angular velocity

    // public float left_back_w;        // BACK left wheel's angular velocity
    // public float right_back_w;       // BACK right wheel's angular velocity

    public float radius;                // wheel radius
    public float terrain_alpha;         // terrain physics

    public GameObject gameOverPanel;    // shows a Game Over screen

    private float linear_velocity;      // stores a variable for linear velocity of the robot

    private AudioSource death;          // sound plays when robot dies

    private Rigidbody2D robot;          // refers to the entire robot

    private Countdown timer;

    void Start()
    {

        robot = GetComponent<Rigidbody2D>();
        death = GetComponent<AudioSource>();
        GetComponent<AudioSource>().playOnAwake = false;
        gameOverPanel.SetActive(false);


    }


    /* Physics code */
    private void FixedUpdate()
    {

        float width = robot.transform.localScale.x;

        // sets angular vel. of wheel to 0 if wheel is off
        if (left_front_on == false)
        {
            left_front_w = 0;
        }

        if (right_front_on == false)
        {
            right_front_w = 0;
        }

       /* if (left_back_on == false)
        {
            left_back_w = 0;
        }

        if (right_back_on == false)
        {
            right_back_w = 0;
        } */


        Vector2 movement = new Vector2(
            (radius * right_front_w) / 2 + (radius * left_front_w) / 2,
            (-left_front_w * radius) / (terrain_alpha * width) + (right_front_w * radius) / (terrain_alpha * width)
         );


        // player moves in direction up at calculated linear velocity
        // robot.MovePosition(robot.position + Vector2.up * movement.x);

        robot.velocity = Vector2.up * movement.x;

        // robot.Add
        robot.MoveRotation(robot.rotation + movement.y * Time.fixedDeltaTime);


    }

    void Update ()
    {


    }
}
