using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parenting : MonoBehaviour {

    private GameObject child;
    //private GameObject parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Contains("Gear"))
        {
            Debug.Log("setting parent!");
            other.transform.parent = transform;
        }

        else
        {
            Debug.Log("nothing happening."); 
        }
    }
}
