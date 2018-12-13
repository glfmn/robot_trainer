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
        Vector3 d_top = ((pos_driver + r_driver*normal) - (pos_driven + r_driven*normal));
        Vector3 c_top = pos_driver - 0.5f * d_top;
        Vector3 d_bot = ((pos_driver - r_driver*normal) - (pos_driven - r_driven*normal));
        Vector3 c_bot = pos_driver - 0.5f * d_bot;

        topBelt.transform.position = c_top;
        bottomBelt.transform.position = c_bot;

        Vector3 n_bot = new Vector3(-d_bot.y, d_bot.x, 0f);
        n_bot.Normalize();

        Vector3 n_top = new Vector3(-d_top.y, d_top.x, 0f);
        n_top.Normalize();

        float z_top = Mathf.Acos(Vector3.Dot(Vector3.zero, n_top));
        float z_bot = -Mathf.PI / 4f + Mathf.Acos(Vector3.Dot(Vector3.zero, n_bot));

        topBelt.transform.rotation = new Quaternion(0f, 0f, z_top, 1f);
        bottomBelt.transform.rotation = new Quaternion(0f, 0f, z_bot, 1f);

        topBelt.transform.localScale = new Vector3(topBelt.transform.localScale.x, d_top.magnitude, 1f);
        bottomBelt.transform.localScale = new Vector3(bottomBelt.transform.localScale.x, d_bot.magnitude, 1f);
    }

    public override float AngularVelocity () {
        angularVelocity = driver.Size() / driven.Size() * driver.AngularVelocity() * -1;
        //Debug.Log("Belt angular velocity " + angularVelocity);
        return angularVelocity;
    }

    public override float Size () {
        return driven.Size();
    }
}
