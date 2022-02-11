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

    public GameObject fadeImg;

    public void Start()
    {
        StartCoroutine("FadeInStart");
    }
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

    public void gotofarm()
    {
        StartCoroutine("FadeOutStart_farm");
    }
    public void gotoRace()
    {
        StartCoroutine("FadeOutStart_race");
    }
    public void gototrade()
    {
        StartCoroutine("FadeOutStart_trade");
    }

    public IEnumerator FadeInStart()
    {
        fadeImg.SetActive(true);
        for (float f = 1f; f > 0; f -= 0.02f)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }

        fadeImg.SetActive(false);
    }

    //페이드 인
    public IEnumerator FadeOutStart_farm()
    {
        fadeImg.SetActive(true);
        for (float f = 0f; f < 1; f += 0.02f)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("farm");
    }

    public IEnumerator FadeOutStart_race()
    {
        fadeImg.SetActive(true);
        for (float f = 0f; f < 1; f += 0.02f)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("raceWaitScene");
    }

    public IEnumerator FadeOutStart_trade()
    {
        fadeImg.SetActive(true);
        for (float f = 0f; f < 1; f += 0.02f)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("Trade");
    }
}