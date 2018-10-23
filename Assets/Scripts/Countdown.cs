using System.Collections;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using UnityEngine;

/* Starts timer after death before game restarts */ 
public class Countdown : MonoBehaviour {

    private int timeLeft = 6;           // Number of seconds before game restarts
    public Text countdown;              // Countdown timer text


	void Start () {

        StartCoroutine("LoseTime");
        Time.timeScale = 1; 
		
	}
	

	void Update () {

        // Shows timer counting down on the Canvas. 
        countdown.text = ("" + timeLeft); 

        // When countdown reaches zero .. 
        if (timeLeft == 0)
        {
            // .. Scene restarts. 
            SceneManager.LoadScene("scene0");
        }
	}


    IEnumerator LoseTime()
    {
        // Timer counts down once per second.
        while(true){
            yield return new WaitForSeconds(1);
            timeLeft--; 
        }
    }
}
