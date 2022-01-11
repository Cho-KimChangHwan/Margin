using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick1 : MonoBehaviour
{
    public GameObject button;
    public GameObject x1;
    public GameObject x2;
    public int check;

    // Start is called before the first frame update
    void Start()
    {
        GameObject button = GameObject.Find("horseone");
        GameObject x1 = GameObject.Find("onexone");
        GameObject x2 =GameObject.Find("onextwo");

        check = GameManager.instance.many;

        Debug.Log(check);

        if (check >= 1)
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
