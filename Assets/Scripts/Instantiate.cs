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

    private void OnMouseDown()
    {
        Debug.Log("clicked.");
        //GameObject obj = Instantiate
        //(gear, new Vector3(-.84f, -.16f, -.37f), Quaternion.identity) as GameObject;
        /* Vector3 position = new Vector3(5, 5, 5);

        GameObject newGameObject = Instantiate(GameObjectToInstantiate);

        newGameObject.transform.position = position; */
        Vector3 p = Camera.main.ScreenToWorldPoint
                          (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        myCurrentObject = Instantiate
               (objectToInstantiate, Camera.main.ScreenToWorldPoint(new Vector3(p.x - 27.1f, p.y + 13.5f, 0.0f)), Quaternion.identity);
        if (Input.GetMouseButton(0) && myCurrentObject)
        {
            Debug.Log("Dragging");

            myCurrentObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0) && myCurrentObject)
        {

            myCurrentObject = null;

        }

    }
}
