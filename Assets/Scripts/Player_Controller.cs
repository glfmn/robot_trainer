using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public bool left_on;          // turns on/off left wheel
    public bool right_on;         // turns on/off right wheel

    public float left_w;          // FRONT left wheel's angular velocity
    public float right_w;         // FRONT right wheel's angular velocity

    public bool sensor_on;              // turns on/off sensor
    public bool sensor_detect;          // whether the sensor detects an object (yes/no)

    public float radius;                // wheel radius
    public float terrain_alpha;         // terrain physics

    public GameObject gameOverPanel;    // shows a Game Over screen

    private float linear_velocity;      // stores a variable for linear velocity of the robot

    private AudioSource death;          // sound plays when robot dies
    private float restartTimer;         // timer counting down to respawn
    private float restartDelay = 5;     // time between game ending and restarting


    private Rigidbody2D robot;          // refers to the entire robot

    // Use this for initialization
    void Start()
    {

        robot = GetComponent<Rigidbody2D>();
        death = GetComponent<AudioSource>();
        GetComponent<AudioSource>().playOnAwake = false;

        gameOverPanel.SetActive(false);

    }


    // obstacle collision logi
    private void OnCollisionEnter2D(Collision2D other)
    {

        // When the player collides with an obstacle, restart the scene after
        // playing a death sound.
        if (other.collider.tag == "Obstacle")
        {
            Debug.Log("hit something");

            gameOverPanel.SetActive(true);

            // plays the sound of robot death
            death.Play();

            // Starts the countdown to restart ..
            restartTimer += Time.deltaTime;

            // .. when countdown reaches restart delay time ..
            if (restartTimer >= restartDelay)
            {
                // .. level reloads.
                SceneManager.LoadScene("scene0");
            }

        }
    }

    // Physics code
    private void FixedUpdate()
    {
        float width = robot.transform.localScale.x;

        // Calculate linear velocities from angular
        float left_v = left_w * radius;
        float right_v = right_w * radius;

        // Set linear velocites to zero if the motors have been turned off
        if (left_on == false)
        {
            left_v = 0;
        }
        if (right_on == false)
        {
            right_v = 0;
        }

        // Use ideal physical model for simple skid-steered robot to calculate
        // change in rotation and current velocity
        float linear_velocity = right_v/2 + left_v/2;
        float angular_velocity
            = -left_v / (terrain_alpha*width)
            + right_v / (terrain_alpha*width);

        // Apply physics to local transform after rotation according to
        // calculation to ensure linear velocity is in the same direction as
        // the robot's local (apparent) "up," or forward, direction.
        transform.Rotate(0, 0, angular_velocity * Time.fixedDeltaTime);
        robot.velocity = this.transform.up * linear_velocity;
    }

    // Update is called once per frame
    void Update () {

	}
}
