using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour, IInputManager {

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }

    public Vector2 MoveAction()
    {

        float x = 0;
        if (Input.GetKey("w")) {
          x += 1;
        }

        if (Input.GetKey("s")) {
          x -= 1;
        }

        float y = 0;
        if (Input.GetKey("up")) {
          y += 1;
        }
        if (Input.GetKey("down")) {
          y -= 1;
        }

        return new Vector2(x, y);

    }
}
