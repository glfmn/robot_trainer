using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinCondition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /* when the robot crosses finish line,you win */
    void OnCollisionEnter2D(Collision2D other)
    {
        /* robot crosses finish line */
        if (other.collider.tag == "Win")
        {
            /* shows win screen */
            SceneManager.LoadScene("Win_scene"); 

        }
    }
}
