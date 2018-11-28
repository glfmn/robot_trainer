using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : PuzzleElement {
    public PuzzleElement driver;
    public PuzzleElement driven;

    float angularVelocity;

    void Start() {

    }

    void Update() {

    }

    public override float AngularVelocity () {
        angularVelocity = driver.Size() / driven.Size() * driver.AngularVelocity() * -1;
        Debug.Log("Belt angular velocity " + angularVelocity);
        return angularVelocity;
    }

    public override float Size () {
        return driven.Size();
    }
}
