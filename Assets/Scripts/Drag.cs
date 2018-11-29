using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    public GameObject objectToInstantiate;
    private GameObject myCurrentObject; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Nice.");
            Vector3 p = Camera.main.ScreenToWorldPoint
                          (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            myCurrentObject = Instantiate
                (objectToInstantiate, Camera.main.ScreenToWorldPoint(new Vector3(p.x - 27.1f, p.y + 13.5f, 0.0f)),Quaternion.identity);
     }
        if(Input.GetMouseButton(0) && myCurrentObject){
            Debug.Log("Dragging");

            myCurrentObject.transform.position =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
     }
 
        if(Input.GetMouseButtonUp(0) && myCurrentObject){
            Debug.Log("letting go."); 

            myCurrentObject = null;
   
        }
 
    }
		
	
}

