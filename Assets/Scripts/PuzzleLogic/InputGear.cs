using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGear : PuzzleElement {
    // size of gear
    public float size;

    // 
    public float input;

    // number of times user rotates input gear 
    public int rotations = 0; 

    void Start () {

    }

    void Update () {

    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, input * Time.fixedDeltaTime);

    }

    public override float AngularVelocity () {
        return input;
    }

    public override float Size () {
        return size;
    }
}
