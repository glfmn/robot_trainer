using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// uses output gears to set robot velocity 
public class GearInput : InputManager {

    private GameObject leftout;
    private GameObject rightout; 
	// Use this for initialization
	void Start () {
        leftout = GameObject.Find("LeftOutput");
        rightout = GameObject.Find("RightOutput"); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Vector2 MoveAction()
    {
        float x = 0;
        float y = 0; 

        if (leftout)
        {
            x = (leftout.GetComponent<OutputGear>().outputVelocity)/20;
        }
        if (rightout)
        {
            y = (rightout.GetComponent<OutputGear>().outputVelocity)/20; 
        }
        Debug.Log("using wheels."); 
        return new Vector2(x, y); 
    }
}
