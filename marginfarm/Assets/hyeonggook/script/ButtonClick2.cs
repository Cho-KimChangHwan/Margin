using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick2 : MonoBehaviour
{
    public GameObject button = GameObject.Find("horsetwo");
    public GameObject x1 = GameObject.Find("twoxone");
    public GameObject x2 = GameObject.Find("twoxtwo");

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.many >= 2)
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
