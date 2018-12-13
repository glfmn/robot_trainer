using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzleElement {

    float AngularVelocity ();

    float Size ();
}

public abstract class PuzzleElement : MonoBehaviour,  IPuzzleElement {
    void Start() {

    }

    void Update() {

    }

    public abstract float AngularVelocity();
    public abstract float Size();
}

public class PuzzleLogic : MonoBehaviour {

    public List<OutputGear> tree;
    public List<float> output;

    // Use this for initialization
    void Start () {

    }

    void Update () {

    }

    // Update is called once per frame
    void FixedUpdate () {
        output = new List<float>();
        foreach (OutputGear outputGear in tree) {
            output.Add(outputGear.AngularVelocity());
        }
    }
}
