using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gachaControl : MonoBehaviour
{

    public GameObject first;
    public GameObject second;
    public GameObject third;

    public GameObject horse1;
    public GameObject horse2;
    public GameObject horse3;

    public void gacha_b1_click()
    {
        GameObject first = GameObject.Find("first");
        GameObject second = GameObject.Find("second");
        iTween.MoveTo(first, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(second, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
    }
    public void go_click()
    {
        GameObject horse1 = GameObject.Find("render_horse1"); 
        GameObject horse2 = GameObject.Find("render_horse2"); 
        GameObject horse3 = GameObject.Find("render_horse3"); 
    }

}
