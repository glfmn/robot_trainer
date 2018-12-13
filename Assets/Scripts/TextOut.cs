using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOut : MonoBehaviour {

    public TextMesh velocity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        velocity.text = ("" + gameObject.GetComponent<OutputGear>().outputVelocity); 
    }
}
