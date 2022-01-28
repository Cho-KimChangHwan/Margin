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
    public Image item_i;

    public RawImage[] horse_render = new RawImage[6];

    public Image[] back_item_card = new Image[10];
    public Image[] hat_item_card = new Image[10];
    public Image[] glasses_item_card = new Image[10];
    public Image[] shoes_item_card = new Image[10];

    public GameObject[] back_item = new GameObject[10];
    public GameObject[] hat_item = new GameObject[10];
    public GameObject[] glasses_item = new GameObject[10];
    public GameObject[] shoes_item = new GameObject[10];

    public Image slot_back;
    public Image slot_hat;
    public Image slot_glasses;
    public Image slot_shoes;

    public RawImage horse_image;
    public Button item_b;

    public int item_temp;

    public int data;
    public int i;
    public int[] userdata = new int[5];

    public GameObject picture;
    public Transform camera_po;
    public void specview_close()  //스펙뷰 닫으면 카메라 원위치 이동시키고 창 닫기
    {
        if (GameManager.instance.spec_check == true)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));

            GameObject picture = GameObject.Find("Main Camera");
            camera_po = GameObject.Find("c_main").GetComponent<Transform>();
            iTween.RotateTo(picture, iTween.Hash("rotation", new Vector3(20.22f, 116.198f, 2.54f), "delay", 0.1f, "time", 2f));
            iTween.MoveTo(picture, iTween.Hash("position", camera_po.position, "delay", 0.1f, "time", 2f));

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

        GameObject picture = GameObject.Find("Main Camera");
        camera_po = GameObject.Find("c_point" + GameManager.instance.select.ToString()).GetComponent<Transform>();
        iTween.RotateTo(picture, iTween.Hash("rotation", new Vector3(0, 143.33f, 0), "delay", 0.1f, "time", 2f));
        iTween.MoveTo(picture, iTween.Hash("position", camera_po.position, "delay", 0.1f, "time", 2f));

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

        GameObject picture = GameObject.Find("Main Camera");
        camera_po = GameObject.Find("c_point" + GameManager.instance.select.ToString()).GetComponent<Transform>();
        iTween.RotateTo(picture, iTween.Hash("rotation", new Vector3(0, 143.33f, 0), "delay", 0.1f, "time", 2f));
        iTween.MoveTo(picture, iTween.Hash("position", camera_po.position, "delay", 0.1f, "time", 2f));

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

        GameObject picture = GameObject.Find("Main Camera");
        camera_po = GameObject.Find("c_point" + GameManager.instance.select.ToString()).GetComponent<Transform>();
        iTween.RotateTo(picture, iTween.Hash("rotation", new Vector3(0, 143.33f, 0), "delay", 0.1f, "time", 2f));
        iTween.MoveTo(picture, iTween.Hash("position", camera_po.position, "delay", 0.1f, "time", 2f));

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

        GameObject picture = GameObject.Find("Main Camera");
        camera_po = GameObject.Find("c_point" + GameManager.instance.select.ToString()).GetComponent<Transform>();
        iTween.RotateTo(picture, iTween.Hash("rotation", new Vector3(0, 143.33f, 0), "delay", 0.1f, "time", 2f));
        iTween.MoveTo(picture, iTween.Hash("position", camera_po.position, "delay", 0.1f, "time", 2f));

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

        GameObject picture = GameObject.Find("Main Camera");
        camera_po = GameObject.Find("c_point" + GameManager.instance.select.ToString()).GetComponent<Transform>();
        iTween.RotateTo(picture, iTween.Hash("rotation", new Vector3(0, 143.33f, 0), "delay", 0.1f, "time", 2f));
        iTween.MoveTo(picture, iTween.Hash("position", camera_po.position, "delay", 0.1f, "time", 2f));

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

        GameObject picture = GameObject.Find("Main Camera");
        camera_po = GameObject.Find("c_point" + GameManager.instance.select.ToString()).GetComponent<Transform>();
        iTween.RotateTo(picture, iTween.Hash("rotation", new Vector3(0, 143.33f, 0), "delay", 0.1f, "time", 2f));
        iTween.MoveTo(picture, iTween.Hash("position", camera_po.position, "delay", 0.1f, "time", 2f));

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

    public void inven_itemlist_make(int sel_num)
    {
        horse_image = GameObject.Find("horse_image").GetComponent<RawImage>();
        horse_image = horse_render[sel_num];

        for (int i = 1; i <= GameManager.instance.itemMany; i++)
        {
            item_i = GameObject.Find("item" + i.ToString() + "_i").GetComponent<Image>();
            item_b = GameObject.Find("Item" + i.ToString()).GetComponent<Button>();
            item_b.interactable = true;

            if (GameManager.instance.UserItem[i-1].key < 10) 
            {
                item_i = hat_item_card[GameManager.instance.UserItem[i - 1].key];
            } 
            else if (GameManager.instance.UserItem[i - 1].key < 100)
            {
                item_i = glasses_item_card[(GameManager.instance.UserItem[i - 1].key) / 10];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 1000)
            {
                item_i = back_item_card[(GameManager.instance.UserItem[i - 1].key) / 100];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 10000)
            {
               
            }
        }
        for (int i = 12; i > GameManager.instance.itemMany; i--)
        {
            item_b = GameObject.Find("Item" + i.ToString()).GetComponent<Button>();
            item_b.interactable = false;
        }

        slot_back = GameObject.Find("slot_back_i").GetComponent<Image>();
        slot_hat = GameObject.Find("slot_hat_i").GetComponent<Image>();
        slot_glasses = GameObject.Find("slot_glasses_i").GetComponent<Image>();
        slot_shoes = GameObject.Find("slot_shoes_i").GetComponent<Image>();

        item_temp = GameManager.instance.UserHorse[sel_num].items;
        
        if(item_temp %10 != 1)
        {
            slot_shoes = shoes_item_card[item_temp % 10];
        }
        item_temp = item_temp / 10;
        if (item_temp % 10 != 1)
        {
            slot_back = back_item_card[item_temp % 10];
        }
        item_temp = item_temp / 10;
        if (item_temp % 10 != 1)
        {
            slot_glasses = glasses_item_card[item_temp % 10];
        }
        item_temp = item_temp / 10;
        if (item_temp != 1)
        {
            slot_hat = hat_item_card[item_temp];
        }
    }
    public void click_slot_back()
    {

    }
    public void click_slot_hat()
    {

    }
    public void click_slot_glasses()
    {

    }
    public void click_slot_shoes()
    {

    }

    public void gotohome()
    {
        SceneManager.LoadScene("mainmap");
    }

    public void gotoshop()
    {
        SceneManager.LoadScene("gacha");
    }
}
