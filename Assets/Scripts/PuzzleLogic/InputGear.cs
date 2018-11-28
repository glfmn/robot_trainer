using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGear : PuzzleElement {
    public float size;
    public float input;

    void Start () {

    }

    void Update () {

    }

    void FixedUpdate () {
        transform.Rotate(0, 0, input * Time.fixedDeltaTime);
    }

    public override float AngularVelocity () {
        return input;
    }

    public override float Size () {
        return size;
    }
}
