using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonControl : MonoBehaviour
{
    public GameObject spec;
    public Image bar;
    public Text gauge;
    public Text name_t;

    public int data;
    public int i;
    public int[] userdata = new int[5];

    public void specview_close()
    {
        if (GameManager.instance.spec_check == true)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
            GameManager.instance.spec_check = false;
        }
    }
    public void specview_h1()
    {
        GameManager.instance.select = 0;
        data = GameManager.instance.select;

        name_t = GameObject.Find("name_t").GetComponent<Text>();
        name_t.text = GameManager.instance.UserHorse[data].name;

        userdata[0] = GameManager.instance.UserHorse[data].speed;
        userdata[1] = GameManager.instance.UserHorse[data].accel;
        userdata[2] = GameManager.instance.UserHorse[data].hp;
        userdata[3] = GameManager.instance.UserHorse[data].agility;
        userdata[4] = GameManager.instance.UserHorse[data].consis;

        if (GameManager.instance.spec_check == false)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 470, "delay", 0.1f, "time", 0.5f));
        }
        GameManager.instance.spec_check = true;

        for (i = 1; i < 6; i++)
        {
            bar = GameObject.Find("gauge" + i.ToString()).GetComponent<Image>();
            bar.fillAmount = userdata[i - 1] / 100f;
            gauge = GameObject.Find("gauge_t" + i.ToString()).GetComponent<Text>();
            gauge.text = userdata[i - 1].ToString() + "/ 100";
        }
    }
    public void specview_h2()
    {
        GameManager.instance.select = 1;
        data = GameManager.instance.select;

        name_t = GameObject.Find("name_t").GetComponent<Text>();
        name_t.text = GameManager.instance.UserHorse[data].name;

        userdata[0] = GameManager.instance.UserHorse[data].speed;
        userdata[1] = GameManager.instance.UserHorse[data].accel;
        userdata[2] = GameManager.instance.UserHorse[data].hp;
        userdata[3] = GameManager.instance.UserHorse[data].agility;
        userdata[4] = GameManager.instance.UserHorse[data].consis;

        if (GameManager.instance.spec_check == false)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 470, "delay", 0.1f, "time", 0.5f));
        }
        GameManager.instance.spec_check = true;

        for (i = 1; i < 6; i++)
        {
            bar = GameObject.Find("gauge" + i.ToString()).GetComponent<Image>();
            bar.fillAmount = userdata[i - 1] / 100f;
            gauge = GameObject.Find("gauge_t" + i.ToString()).GetComponent<Text>();
            gauge.text = userdata[i - 1].ToString() + "/ 100";
        }
    }
    public void specview_h3()
    {
        GameManager.instance.select = 2;
        data = GameManager.instance.select;

        name_t = GameObject.Find("name_t").GetComponent<Text>();
        name_t.text = GameManager.instance.UserHorse[data].name;

        userdata[0] = GameManager.instance.UserHorse[data].speed;
        userdata[1] = GameManager.instance.UserHorse[data].accel;
        userdata[2] = GameManager.instance.UserHorse[data].hp;
        userdata[3] = GameManager.instance.UserHorse[data].agility;
        userdata[4] = GameManager.instance.UserHorse[data].consis;

        if (GameManager.instance.spec_check == false)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 470, "delay", 0.1f, "time", 0.5f));
        }
        GameManager.instance.spec_check = true;

        for (i = 1; i < 6; i++)
        {
            bar = GameObject.Find("gauge" + i.ToString()).GetComponent<Image>();
            bar.fillAmount = userdata[i - 1] / 100f;
            gauge = GameObject.Find("gauge_t" + i.ToString()).GetComponent<Text>();
            gauge.text = userdata[i - 1].ToString() + "/ 100";
        }
    }
    public void specview_h4()
    {
        GameManager.instance.select = 3;
        data = GameManager.instance.select;

        name_t = GameObject.Find("name_t").GetComponent<Text>();
        name_t.text = GameManager.instance.UserHorse[data].name;

        userdata[0] = GameManager.instance.UserHorse[data].speed;
        userdata[1] = GameManager.instance.UserHorse[data].accel;
        userdata[2] = GameManager.instance.UserHorse[data].hp;
        userdata[3] = GameManager.instance.UserHorse[data].agility;
        userdata[4] = GameManager.instance.UserHorse[data].consis;

        if (GameManager.instance.spec_check == false)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 470, "delay", 0.1f, "time", 0.5f));
        }
        GameManager.instance.spec_check = true;

        for (i = 1; i < 6; i++)
        {
            bar = GameObject.Find("gauge" + i.ToString()).GetComponent<Image>();
            bar.fillAmount = userdata[i - 1] / 100f;
            gauge = GameObject.Find("gauge_t" + i.ToString()).GetComponent<Text>();
            gauge.text = userdata[i - 1].ToString() + "/ 100";
        }
    }

    public void specview_h5()
    {
        GameManager.instance.select = 4;
        data = GameManager.instance.select;

        name_t = GameObject.Find("name_t").GetComponent<Text>();
        name_t.text = GameManager.instance.UserHorse[data].name;

        userdata[0] = GameManager.instance.UserHorse[data].speed;
        userdata[1] = GameManager.instance.UserHorse[data].accel;
        userdata[2] = GameManager.instance.UserHorse[data].hp;
        userdata[3] = GameManager.instance.UserHorse[data].agility;
        userdata[4] = GameManager.instance.UserHorse[data].consis;

        if (GameManager.instance.spec_check == false)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 470, "delay", 0.1f, "time", 0.5f));
        }
        GameManager.instance.spec_check = true;

        for (i = 1; i < 6; i++)
        {
            bar = GameObject.Find("gauge" + i.ToString()).GetComponent<Image>();
            bar.fillAmount = userdata[i - 1] / 100f;
            gauge = GameObject.Find("gauge_t" + i.ToString()).GetComponent<Text>();
            gauge.text = userdata[i - 1].ToString() + "/ 100";
        }
    }

    public void specview_h6()
    {
        GameManager.instance.select = 5;
        data = GameManager.instance.select;

        name_t = GameObject.Find("name_t").GetComponent<Text>();
        name_t.text = GameManager.instance.UserHorse[data].name;

        userdata[0] = GameManager.instance.UserHorse[data].speed;
        userdata[1] = GameManager.instance.UserHorse[data].accel;
        userdata[2] = GameManager.instance.UserHorse[data].hp;
        userdata[3] = GameManager.instance.UserHorse[data].agility;
        userdata[4] = GameManager.instance.UserHorse[data].consis;

        if (GameManager.instance.spec_check == false)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 470, "delay", 0.1f, "time", 0.5f));
        }
        GameManager.instance.spec_check = true;

        for (i = 1; i < 6; i++)
        {
            bar = GameObject.Find("gauge" + i.ToString()).GetComponent<Image>();
            bar.fillAmount = userdata[i - 1] / 100f;
            gauge = GameObject.Find("gauge_t" + i.ToString()).GetComponent<Text>();
            gauge.text = userdata[i - 1].ToString() + "/ 100";
        }
    }
    public void gotohome()
    {
        SceneManager.LoadScene("mainmap");
    }
}
