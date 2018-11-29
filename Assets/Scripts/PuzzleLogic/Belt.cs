using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : PuzzleElement {
    public PuzzleElement driver;
    public PuzzleElement driven;

    public GameObject topBelt;
    public GameObject bottomBelt;

    private float r_driven;
    private float r_driver;
    private Vector3 pos_driven;
    private Vector3 pos_driver;

    float angularVelocity;

    void Start() {

    }

    void Update() {
        pos_driver = driver.gameObject.transform.position;
        transform.position = pos_driver;
        Vector3 scale_driver = driven.gameObject.transform.localScale;
        r_driver = driver.gameObject.GetComponent<CircleCollider2D>().radius;
        r_driver *= scale_driver.x / scale_driver.x;

        pos_driven = driven.gameObject.transform.position;
        Vector3 scale_driven = driven.gameObject.transform.localScale;
        r_driven = driven.gameObject.GetComponent<CircleCollider2D>().radius;
        r_driven *= scale_driven.x / scale_driven.x;

        Vector3 d = pos_driven - pos_driver;
        Vector3 normal = new Vector3(-d.y, d.x, 0f);
        normal.Normalize();
        Vector3 c_top = 1.5f * pos_driver + r_driver*normal;
        Vector3 c_bot = 1.5f * pos_driven - r_driver*normal;

        topBelt.transform.position = c_top;
        bottomBelt.transform.position = c_bot;
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
