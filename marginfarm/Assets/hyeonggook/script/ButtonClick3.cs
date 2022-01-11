using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick3 : MonoBehaviour
{
    public GameObject button = GameObject.Find("horse3");
    public GameObject x1 = GameObject.Find("3x1");
    public GameObject x2 = GameObject.Find("3x2");

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.many >= 3)
        {
            button.SetActive(true);
            x1.SetActive(false);
            x2.SetActive(false);
        }
        else
        {
            x1.SetActive(true);
            x2.SetActive(true);
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
