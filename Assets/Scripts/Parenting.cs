﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parenting : MonoBehaviour {

    private GameObject child;
    //private GameObject parent;
    //private PuzzleElement child;
    

	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Contains("Input"))
        {
            Debug.Log("setting parent!");
           


        }

        else if (other.gameObject.tag.Contains("Gear"))
        {
            Gear gearScript = this.GetComponent<Gear>();
            Debug.Log("gear parenting."); 
            gameObject.transform.parent = other.transform;
            //child = Instantiate(Resources.Load("Gear40")) as GameObject;


            //gameObject.transform.parent = (other.gameObject.GetComponent<Gear>().parent).transform;

            Debug.Log("pare happened.:"); 
        }

        else
        {
            Debug.Log("nothing happening."); 
        }
    }
}