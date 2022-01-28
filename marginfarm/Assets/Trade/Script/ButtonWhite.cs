using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWhite : MonoBehaviour
{
    public GameObject WhiteObject;
    public GameObject BlackObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor()
    {
        BlackObject.gameObject.SetActive(false);
        WhiteObject.gameObject.SetActive(true);
    }
}
