using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour {

    private GameObject left, right, linput, rinput, puzzlelogic;

	// Use this for initialization
	void Start () {
        left = GameObject.Find("LeftOutput");
        right = GameObject.Find("RightOutput");
        linput = GameObject.Find("LeftInput");
        rinput = GameObject.Find("RightInput");
        puzzlelogic = GameObject.Find("PuzzleLogic"); 

        left.GetComponent<OutputGear>().enabled = false; 
        right.GetComponent<OutputGear>().enabled = false;
        //left.GetComponent<Parenting>().enabled = false;
        //right.GetComponent<Parenting>().enabled = false;
        linput.GetComponent<InputGear>().enabled = false;
        rinput.GetComponent<InputGear>().enabled = false;
        puzzlelogic.SetActive(false); 

    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (Input.GetKeyDown("space"))
        {
            left.GetComponent<OutputGear>().enabled = true;
            right.GetComponent<OutputGear>().enabled = true;
            linput.GetComponent<InputGear>().enabled = true;
            rinput.GetComponent<InputGear>().enabled = true;
            puzzlelogic.SetActive(true); 
            //left.GetComponent<Parenting>().enabled = true;
            //right.GetComponent<Parenting>().enabled = true;
        }

    }

    //IEnumerator Activation(int num)
    //{
    //    left.GetComponent<OutputGear>().enabled = true;
    //    right.GetComponent<OutputGear>().enabled = true; 
    //    linput.GetComponent<InputGear>().enabled = true;
    //    rinput.GetComponent<InputGear>().enabled = true;
    //    left.GetComponent<Parenting>().enabled = true;
    //    right.GetComponent<Parenting>().enabled = true;

    //    yield return new WaitForSeconds(num);

    //    left.GetComponent<OutputGear>().enabled = false;
    //    right.GetComponent<OutputGear>().enabled = false;
    //    linput.GetComponent<InputGear>().enabled = false;
    //    rinput.GetComponent<InputGear>().enabled = false;
    //    left.GetComponent<Parenting>().enabled = false;
    //    right.GetComponent<Parenting>().enabled = false;

    //    right.GetComponent<OutputGear>().outputVelocity = 0;
    //    left.GetComponent<OutputGear>().outputVelocity = 0;

    //    GameObject.FindGameObjectsWithTag("Gear"); 
    //}

}
