using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject objectToInstantiate;
    private GameObject myCurrentObject;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }

    private bool OnMouseDown()
    {
        Debug.Log("clicked.");
        return true;
        //GameObject obj = Instantiate
        //(gear, new Vector3(-.84f, -.16f, -.37f), Quaternion.identity) as GameObject;
        /* Vector3 position = new Vector3(5, 5, 5);

        GameObject newGameObject = Instantiate(GameObjectToInstantiate);

        newGameObject.transform.position = position; */
        //Vector3 p = Camera.main.ScreenToWorldPoint
        //                  (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        //myCurrentObject = Instantiate
        //       (objectToInstantiate, Camera.main.ScreenToWorldPoint(new Vector3(p.x - 27.1f, p.y + 13.5f, 0.0f)), Quaternion.identity);
        //if (Input.GetMouseButton(0) && myCurrentObject)
        //{
        //    Debug.Log("Dragging");

        //    myCurrentObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}

        //if (Input.GetMouseButtonUp(0) && myCurrentObject)
        //{

        //    myCurrentObject = null;

        //}


    }

    //public void create()
    //{
        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 10;
        //Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        //print("Mouse is down");
        //if (GameObject.FindWithTag("GameLogic").GetComponent<gamePhasesScript>().IsPlayerPhase)
        //{
        //    GameObject prefabToInstantiateClone = (GameObject)Instantiate(prefabToInstantiate, objPos, Quaternion.identity);
        //}
    }


    //void OnMouseDrag()
    //{
    //    Vector2 pos = Input.mousePosition;
    //    pos = Camera.main.ScreenToWorldPoint(pos);
    //    pos.x = Mathf.Round(pos.x);
    //    pos.y = Mathf.Round(pos.y);
    //    transform.position = pos;
    //    if (Input.GetKey(KeyCode.LeftControl))
    //    {
    //        if (transform.position != GameObject.Find("SomePrefabName").transform.position)
    //        {
    //            GameObject myGameObject = Instantiate(objectToInstantiate) as GameObject;
    //            myGameObject.name = "SomePrefabName";
    //        }
    //    }
    //}
