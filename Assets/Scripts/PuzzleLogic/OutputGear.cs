using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputGear : MonoBehaviour, IPuzzleElement {

    public PuzzleElement output;
    public float size;

    public float outputVelocity;

    void Start () {

    }

    void Update () {

    }

    void FixedUpdate () {
        transform.Rotate(0, 0, outputVelocity * Time.fixedDeltaTime);
    }

    public float AngularVelocity () {
        outputVelocity = output.Size() / size  * output.AngularVelocity() * -1f;
        Debug.Log("This is output angular velocity: " + output.AngularVelocity()); 
        return outputVelocity;
    }

    public float Size () {
        return 1f;
    }
}
