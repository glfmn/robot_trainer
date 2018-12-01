using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGear10 : MonoBehaviour {

    public GameObject objectToInstantiate;
    private GameObject myCurrentObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                          Input.mousePosition.y, 10.0f));
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider)
            {
                if (hit.collider.tag == "Spawn10")
                {
                    myCurrentObject = Instantiate
                                      (objectToInstantiate,
                                       new Vector3(mousePos.x, mousePos.y + 15.0f, 0.0f), Quaternion.identity);
                }
            }

            else
            {
                Debug.Log("nothing happened.");
            }

        }

    }
}
