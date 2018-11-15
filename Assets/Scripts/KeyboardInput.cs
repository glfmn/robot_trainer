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
          x += 2;
        }

        if (Input.GetKey("s")) {
          x -= 2;
        }


        float y = 0;
        if (Input.GetKey("up")) {
          y += 2;
        }
        if (Input.GetKey("down")) {
          y -= 2;
        }


        return new Vector2(x, y);

    }
}
