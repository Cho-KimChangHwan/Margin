using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gohome : MonoBehaviour
{

    public GameObject fadeImg;
    //bool isclicker = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInStart());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    public void gotohome()
    {
        StartCoroutine(FadeOutStart_main());
    }

    /*public void startselling()
    {
        if(isclicker == 1)

    }*/
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
    public IEnumerator FadeOutStart_main()
    {
        fadeImg.SetActive(true);
        for (float f = 0f; f < 1; f += GameManager.instance.fade_speed)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("aftermain");
    }
}
