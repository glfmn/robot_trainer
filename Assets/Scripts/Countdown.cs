using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


/* Starts timer after death before game restarts */
public class Countdown : MonoBehaviour
{

    public Text countdown;              // Countdown timer text
    public bool TimerOn;                // Turns countdown timer on/off

    public GameObject gameOverPanel;    // shows a Game Over screen
    private AudioSource death;          // sound plays when robot dies

    private float timeLeft = 6.0f;      // Seconds until game restarts
    private int seconds;                // timeLeft expressed in seconds

    void Start()
    {
        death = GetComponent<AudioSource>();
        GetComponent<AudioSource>().playOnAwake = false;
        gameOverPanel.SetActive(false);

        TimerOn = false;

    }

    void Update()
    {
        if (Input.GetKey("escape")) {
            SceneManager.LoadScene("scene0");
        }

        /* restarts game after timeLeft seconds */
        if (TimerOn == true)
        {
            timeLeft -= Time.deltaTime;
            seconds = (int)timeLeft % 60;
            countdown.text = ("" + seconds);
            if (timeLeft < 0)
            {
                TimerOn = false;
                SceneManager.LoadScene("scene0");
            }
        }
    }

    /* when the robot hits anything, it dies */
    void OnCollisionEnter2D(Collision2D other)
    {
        /* robot hits obstacle */
        if (other.collider.tag == "Obstacle")
        {
            Debug.Log("hit something");

            /* shows game over screen */
            gameOverPanel.SetActive(true);

            /* plays the sound of robot death */
            death.Play();

            /* starts countdown timer */
            TimerOn = true;

        }
    }
}
