using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Horse_Rotate : MonoBehaviour
{
    private float rotateSpeed = 3f;
    Vector2 mouseposition;
    Camera camera;
    bool isclick = false;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(0))
        {
            mouseposition = Input.mousePosition;
            //mouseposition = camera.ScreenToWorldPoint(mouseposition);
            Debug.Log(mouseposition.ToString());
            if(mouseposition.x > 5.0f && mouseposition.x<425.0f)
            {
                if(mouseposition.y > 145.0f && mouseposition.y <465.0f)
                {
                    Debug.Log("ss");
                    isclick = true;       
                }
            }
        }
        else
        {
            isclick = false;
        }

        if(isclick == true)
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * rotateSpeed, 0f, Space.World);
            //transform.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed, 0f, 0f);
        }
        
    }

    public void clickposition()
    {
        
    }

    
}
