using System.Collections;
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

            // sets this object as the child of the thing it collides with
            gameObject.transform.parent = other.transform;
            //child = Instantiate(Resources.Load("Gear40")) as GameObject;

            if (other.gameObject.name.Contains("Gear40"))
            {
                gearScript.parent = Resources.Load("PuzzleElements/Gear40") as PuzzleElement;
                Debug.Log("setting gear 40"); 
            }

            else 
            {
                Debug.Log("didn't set gear 40."); 
            }
            //gameObject.transform.parent = (other.gameObject.GetComponent<Gear>().parent).transform;
        }

        else
        {
            Debug.Log("nothing happening."); 
        }
    }
}
