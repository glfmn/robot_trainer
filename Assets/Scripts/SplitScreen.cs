using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Set camera view rectangles to split the screen horizontally
public class SplitScreen : MonoBehaviour {

    public Camera left;
    public Camera right;

    // Use this for initialization
    void Start () {
        left.rect = new Rect(0f, 0f, 0.5f, 1f);
        right.rect = new Rect(0.5f, 0f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update () {

    }
}
