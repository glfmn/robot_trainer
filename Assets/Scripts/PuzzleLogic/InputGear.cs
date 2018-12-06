using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class InputGear : PuzzleElement {
    // size of gear
    public float size;
    public TextMesh velocity;
    public float input;

    // number of times user rotates input gear 
    public int rotations = 0; 

    void Start () {

    }

    void Update () {

    }

    void FixedUpdate()
    {
        velocity.text = ("" + input); 
        transform.Rotate(0, 0, input * Time.fixedDeltaTime);

    }

    public override float AngularVelocity () {
        return input;
    }

    public override float Size () {
        return size;
    }
}
