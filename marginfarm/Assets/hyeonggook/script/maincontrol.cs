using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class maincontrol : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject title_m;
    public GameObject start_m;
    public GameObject gotoset;

    public void touchmain()
    {
   
        GameObject maincamera = GameObject.Find("Main Camera");
        GameObject title_m = GameObject.Find("title_m");
        GameObject start_m = GameObject.Find("start_m");
        GameObject gotoset = GameObject.Find("gotoset");

        iTween.MoveTo(maincamera, iTween.Hash("position", new Vector3(134f, 14f, 51f), "delay", 0, "time", 3f));
        iTween.MoveTo(title_m, iTween.Hash("position", new Vector3(-1056f, 900f, 0), "delay", 0.1f, "time", 2f));
        iTween.MoveTo(start_m, iTween.Hash("position", new Vector3(1285f, -725f, 0), "delay", 0.1f, "time", 2f));
        iTween.MoveTo(gotoset, iTween.Hash("y", 350, "delay", 3f, "time", 0.1f));

    }
}