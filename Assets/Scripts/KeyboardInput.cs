using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : InputManager {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public override Vector2 MoveAction()
    {

        float x = 0;
        if (Input.GetKey("w")) {
          x += 10;
        }

        if (Input.GetKey("s")) {
          x -= 10;
        }

        float y = 0;
        if (Input.GetKey("up")) {
          y += 10;
        }
        if (Input.GetKey("down")) {
          y -= 10;
        }

        return new Vector2(x, y);

    }
}
