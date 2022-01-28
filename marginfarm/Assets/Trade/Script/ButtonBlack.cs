using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBlack : MonoBehaviour
{
    public GameObject BlackObject;
    public GameObject WhiteObject;
    // Start is called before the first frame update
    void Start()
    {
        BlackObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void changeColor()
    {
        BlackObject.gameObject.SetActive(true);
        WhiteObject.gameObject.SetActive(false);
       
    }
}
