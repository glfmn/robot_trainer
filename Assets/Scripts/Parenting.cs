using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parenting : MonoBehaviour {

    private GameObject child;

	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Gear gearScript = this.GetComponent<Gear>();
        OutputGear OutputgearScript = this.GetComponent<OutputGear>();

        //if (other.gameObject.tag.Contains("Input"))
        //{

        //    //gearScript.parent = other.gameObject.GetComponent<PuzzleElement>(); 
        //}

        //else if (other.gameObject.tag.Contains("Gear"))
        //{
        //    // sets this object as the child of the thing it collides with

        //        //gearScript.parent = Resources.Load("PuzzleElements/Gear40") as PuzzleElement;

        //}


        // if an output gear, set this object as the child of the collided thingy
        if (gameObject.name.Contains("Output"))
        {
            Debug.Log("ouput parenting.");
            if (gameObject.transform.position.x > other.gameObject.transform.position.x)
            {
                OutputgearScript.output = other.gameObject.GetComponent<PuzzleElement>();
            }
        }

        else
        {
            // if current object is to right of collided object, 
            // set this object as the child of the collided object 

            if (gameObject.transform.position.x > other.gameObject.transform.position.x)
            {
                Debug.Log("using location.:");
                //gameObject.transform.parent = other.transform;
                gearScript.parent = other.gameObject.GetComponent<PuzzleElement>();
            }
        }
    }
}
