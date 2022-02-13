using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadeinout : MonoBehaviour
{
    public GameObject fadeImg;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInStart());
    }
    public void gotofarm()
    {
        StartCoroutine(FadeOutStart_farm());
    }
    public void gotoRace()
    {
        StartCoroutine(FadeOutStart_race());
    }
    public void gototrade()
    {
        StartCoroutine(FadeOutStart_trade());
    }

    public IEnumerator FadeInStart()
    {
        fadeImg.SetActive(true);
        for (float f = 1f; f > 0; f -= GameManager.instance.fade_speed)
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
        for (float f = 0f; f < 1; f += GameManager.instance.fade_speed)
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
        for (float f = 0f; f < 1; f += GameManager.instance.fade_speed)
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
        for (float f = 0f; f < 1; f += GameManager.instance.fade_speed)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("Trade");
    }


}
