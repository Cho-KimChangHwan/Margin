using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Horse_White : MonoBehaviour
{
    private float rotateSpeed = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButton(0))
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * rotateSpeed, 0f, Space.World);
            //transform.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed, 0f, 0f);
        }
    }

    
}
