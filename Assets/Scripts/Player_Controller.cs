using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using timer = Countdown;

public class Player_Controller : MonoBehaviour
{
    public bool left_on;          // turns on/off left wheel
    public bool right_on;         // turns on/off right wheel

    public KeyboardInput inputManager;

    private float left_w;          // FRONT left wheel's angular velocity
    private float right_w;         // FRONT right wheel's angular velocity

    public bool sensor_on;              // turns on/off sensor
    public bool sensor_detect;          // whether the sensor detects an object (yes/no)

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


    // Physics code
    private void FixedUpdate()
    {
        float width = robot.transform.localScale.x;

        Vector2 input = inputManager.MoveAction();

        left_w += input.x;
        right_w += input.y;

        // Calculate linear velocities from angular
        float left_v = left_w * radius;
        float right_v = right_w * radius;

        // Set linear velocites to zero if the motors have been turned off
        if (!left_on) {
            left_v = 0;
        }
        if (!right_on) {
            right_v = 0;
        }

        // Use ideal physical model for simple skid-steered robot to calculate
        // change in rotation and current velocity
        float linear_velocity = (right_v + left_v)/2;
        float terrain_factor = (terrain_alpha*width);
        float angular_velocity = (-left_v + right_v)/terrain_factor;

        // Apply physics to local transform after rotation according to
        // calculation to ensure linear velocity is in the same direction as
        // the robot's local (apparent) "up," or forward, direction.
        transform.Rotate(0, 0, angular_velocity * Time.fixedDeltaTime);
        robot.velocity = this.transform.up * linear_velocity;
    }

    void Update ()
    {


    }
}
