using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : PuzzleElement {
    public float size;

    float angularVelocity;

    /// The gear or assembly that drives the parent gear
    public PuzzleElement parent;

    void Start () {
       
        Debug.Log("size: " + size);
        //parent = Instantiate(Resources.Load("Gear40", typeof(GameObject))) as PuzzleElement;
        //Debug.Log("parent:" + parent);
        //Debug.Log("help."); 
    }

    void Update () {

    }

    void FixedUpdate () {
        transform.Rotate(0, 0, angularVelocity * Time.fixedDeltaTime);
    }

    public override float AngularVelocity () {
        angularVelocity = parent.Size() / size  * parent.AngularVelocity() * -1f;
        Debug.Log("Gear angular velocity " + angularVelocity + ", size: " + size);
        return angularVelocity;
    }

    public override float Size () {
        return this.size;
    }
}
