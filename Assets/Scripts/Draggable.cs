﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]

// makes an object draggable with the mouse. add to prefabs you want dragged
// when instantiated. 
public class Draggable : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 currentPos = Camera.main.ScreenToWorldPoint(curScreenPoint)+offset;
        //transform.position = curPosition;
        transform.position = new Vector3(Mathf.Round(currentPos.x),
                             Mathf.Round(currentPos.y),
                             Mathf.Round(currentPos.z));

    }

}