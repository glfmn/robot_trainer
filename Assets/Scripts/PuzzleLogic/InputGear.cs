using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGear : PuzzleElement {
    public float size;
    public float input;
    public int rotations = 0; 

    void Start () {

    }

    void Update () {

    }

    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                          Input.mousePosition.y, 10.0f));
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider)
            {
                if (hit.collider.tag == "Input")
                {
                    Debug.Log("Rotating.");
                    transform.Rotate(0, 0, 180);
                    rotations++;
                }

            }

            if (Input.GetKeyDown("space"))
            {
                StartCoroutine(MyCounter(gameObject.GetComponent<InputGear>().rotations));
            }
        }
    }

    IEnumerator MyCounter(int number)
    {
        float timePassed = 0;
        while (timePassed < number)
        {
            Debug.Log("doing counter.:"); 
            transform.Rotate(0, 0, input * Time.fixedDeltaTime);
            /* wait one second per interval */
            //yield return 0; 
            //yield return new WaitForSeconds(1.0f); 
          
            timePassed += Time.fixedDeltaTime;
            yield return null;
        }
    }

    public override float AngularVelocity () {
        return input;
    }

    public override float Size () {
        return size;
    }
}
