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

    public InputManager inputManager;

    private float left_w;          // FRONT left wheel's angular velocity
    private float right_w;         // FRONT right wheel's angular velocity

    // Maximum wheel angular velocity
    public float max_w;
    public float acceleration;
    public float turn_amplification;

    public bool sensor_on;              // turns on/off sensor
    public bool sensor_detect;          // whether the sensor detects an object (yes/no)

    public float radius;                // wheel radius
    public float terrain_alpha;         // terrain physics

    //public GameObject gameOverPanel;    // shows a Game Over screen

    private float linear_velocity;      // stores a variable for linear velocity of the robot

    private AudioSource death;          // sound plays when robot dies

    private Rigidbody2D robot;          // refers to the entire robot

    private Countdown timer;

    void Start()
    {
        robot = GetComponent<Rigidbody2D>();
        death = GetComponent<AudioSource>();
        GetComponent<AudioSource>().playOnAwake = false;
        //gameOverPanel.SetActive(false);

        if (turn_amplification == 0f) {
            turn_amplification = 1;
        }
    }

    // Apply an easing transformation to float between zero and one
    //
    // Guarnateed to return a value between zero and one
    private float ease(float t) {
        float sign = 1;
        if (t != 0f) {
            sign = t / Mathf.Abs(t);
        }
        // Smooth in, Smooth out
        t /= .5f;
        return 0.5f * t * t * sign;
    }

    private float absolute_clamp(float t, float max) {
        float sign = 1;
        if (Mathf.Abs(t) > max_w) {
            // Avoid dividing by zero, but get the sign of the passed value to
            // keep the maximum in terms of magnitude
            if (t != 0f) {
                sign = t / Mathf.Abs(t);
            }
            t = sign*max_w;
        }
        return t;
    }

    // Physics code
    private void FixedUpdate()
    {
        float width = robot.transform.localScale.x;

        Vector2 action = inputManager.MoveAction();

        // Accumulate the value from the input
        //left_w += action.x * acceleration;
        //right_w += action.y * acceleration;
        left_w = action.x; 
        right_w = action.y; 

        // Clamp the absolute value to the maximum angular velocity
        left_w = absolute_clamp(left_w, max_w);
        right_w = absolute_clamp(right_w, max_w);

        // Calculate linear velocities from angular after easing the angular
        // velocities
        float left_v = ease(left_w/max_w) * max_w * radius;
        float right_v = ease(right_w/max_w) * max_w * radius;

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
        float terrain = (terrain_alpha*width);
        float angular_velocity = turn_amplification * (right_v-left_v)/terrain;

        // Apply physics to local transform after rotation according to
        // calculation to ensure linear velocity is in the same direction as
        // the robot's local (apparent) "up," or forward, direction.
        transform.Rotate(0, 0, angular_velocity * Time.fixedDeltaTime);
        robot.velocity = this.transform.up * linear_velocity;
    }

    void Update () {


    }

    /* when the robot hits anything, it dies */
    void OnCollisionEnter2D(Collision2D other)
    {
        /* robot hits obstacle */
        if (other.collider.tag == "Obstacle")
        {
            Debug.Log("hit something");

            /* shows game over screen */
            SceneManager.LoadScene("Death");

            /* plays the sound of robot death */
            //death.Play();

            ///* starts countdown timer */
            //TimerOn = true;

        }
    }
}
