using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {

    public GameObject objectToInstantiate;
    private GameObject myCurrentObject; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x + 21.8f, mousePos.y + .8f);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            //if (hit.collider.tag == "Respawn")
            //{
            //    Debug.Log("hit");
            //    Vector3 p = Camera.main.ScreenToWorldPoint
            //          (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            //    myCurrentObject = Instantiate
            //        (objectToInstantiate, Camera.main.ScreenToWorldPoint
            //         (new Vector3(p.x - 27.1f, p.y + 13.5f, 0.0f)), Quaternion.identity);
            //}
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }
            Debug.Log(mousePos2D); 
                Debug.Log("Nice.");

          
     }
        if(Input.GetMouseButton(0) && myCurrentObject){
            myCurrentObject.transform.position =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
     }
 
        if(Input.GetMouseButtonUp(0) && myCurrentObject)
            myCurrentObject = null;
   
        }
 
    }
		
	

