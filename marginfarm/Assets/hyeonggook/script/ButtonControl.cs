using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public struct TempItemInfo
{
    public int key;
    public int speed;
    public int accel;
    public int hp;
    public int agility;
    public int consis;


    public TempItemInfo(int key, int speed, int accel, int hp, int agility, int consis)
    {
        this.key = key;
        this.speed = speed;
        this.accel = accel;
        this.hp = hp;
        this.agility = agility;
        this.consis = consis;
    }
}
public class ButtonControl : MonoBehaviour
{
    public GameObject spec;
    public GameObject inven;
    public Image bar;
    public Text gauge;
    public Text name_t;
    public Image item_i;
    public GameObject temp;

    public Texture[] horse_render = new Texture[6];

    public Sprite[] back_item_card = new Sprite[10];
    public Sprite[] hat_item_card = new Sprite[10];
    public Sprite[] glasses_item_card = new Sprite[10];
    public Sprite[] shoes_item_card = new Sprite[10];

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
    public Image item_s;
    public GameObject select_x;
    public Text change_t;

    public GameObject under;

    public int select_num;
    public int horse_s_n;
    public bool slot_check;
    public bool spec_open_check;

    public TempItemInfo[] TempUserItem = new TempItemInfo[]
    {
        new TempItemInfo (0, 0, 0, 0, 0, 0)
    };

    public int data;
    public int i;
    public int[] userdata = new int[5];

    public GameObject picture;
    public Transform camera_po;

    public void Start()
    {
        spec_open_check = true;
    }
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
    public void invenview_open()
    {
        if (GameManager.instance.inven_check == false)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
            GameObject inven = GameObject.Find("inven");
            iTween.MoveTo(inven, iTween.Hash("y", 470, "delay", 0.6f, "time", 0.5f));

            GameManager.instance.inven_check = true;
        }
    }

    public void invenview_close()
    {
        if (GameManager.instance.inven_check == true)
        {
            GameObject inven = GameObject.Find("inven");
            iTween.MoveTo(inven, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 470, "delay", 0.6f, "time", 0.5f));

            GameManager.instance.inven_check = false;

            select_x.SetActive(true);
            spec_open_check = true;
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

        inven_itemlist_make(data);
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

        inven_itemlist_make(data);
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
        horse_image.texture = horse_render[sel_num];

        for (int i = 1; i <= GameManager.instance.itemMany; i++)
        {
            item_i = GameObject.Find("item" + i.ToString() + "_i").GetComponent<Image>();
            item_b = GameObject.Find("item" + i.ToString()).GetComponent<Button>();
            item_b.interactable = true;

            if (GameManager.instance.UserItem[i-1].key < 10) 
            {
                item_i.sprite = hat_item_card[GameManager.instance.UserItem[i - 1].key];
            } 
            else if (GameManager.instance.UserItem[i - 1].key < 100)
            {
                item_i.sprite = glasses_item_card[(GameManager.instance.UserItem[i - 1].key) / 10];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 1000)
            {
                item_i.sprite = back_item_card[(GameManager.instance.UserItem[i - 1].key) / 100];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 10000)
            {
                item_i.sprite = shoes_item_card[(GameManager.instance.UserItem[i - 1].key) / 1000];
            }
        }
        for (int i = 12; i > GameManager.instance.itemMany; i--)
        {
            item_b = GameObject.Find("item" + i.ToString()).GetComponent<Button>();
            item_i = GameObject.Find("item" + i.ToString() + "_i").GetComponent<Image>();
            item_i.sprite = hat_item_card[1];
            item_b.interactable = false;
        }

        slot_back = GameObject.Find("slot_back_i").GetComponent<Image>();
        slot_hat = GameObject.Find("slot_hat_i").GetComponent<Image>();
        slot_glasses = GameObject.Find("slot_glasses_i").GetComponent<Image>();
        slot_shoes = GameObject.Find("slot_shoes_i").GetComponent<Image>();

        if(GameManager.instance.WearingItem[(sel_num * 4)].item_key != 0)
        {
            slot_hat.sprite = hat_item_card[GameManager.instance.WearingItem[(sel_num * 4)].item_key];
        }
        else
        {
            slot_hat.sprite = hat_item_card[0];
        }
        
        if (GameManager.instance.WearingItem[(sel_num * 4) + 1].item_key != 0)
        {
            slot_glasses.sprite = glasses_item_card[GameManager.instance.WearingItem[(sel_num * 4) + 1].item_key / 10];
        }
        else
        {
            slot_glasses.sprite = glasses_item_card[0];
        }

        if (GameManager.instance.WearingItem[(sel_num * 4) + 2].item_key != 0)
        {
            slot_back.sprite = back_item_card[GameManager.instance.WearingItem[(sel_num * 4) + 2].item_key / 100];
        }
        else
        {
            slot_back.sprite = back_item_card[0];
        }

        if (GameManager.instance.WearingItem[(sel_num * 4) + 3].item_key != 0)
        {
            slot_shoes.sprite = shoes_item_card[GameManager.instance.WearingItem[(sel_num * 4) + 3].item_key / 1000];
        }
        else
        {
            slot_shoes.sprite = shoes_item_card[0];
        }
    }

    public void click_slot_back()
    {
        slot_check = true;
        click_item_button(2);
    }
    public void click_slot_hat()
    {
        slot_check = true;
        click_item_button(0);
    }
    public void click_slot_glasses()
    {
        slot_check = true;
        click_item_button(1);
    }
    public void click_slot_shoes()
    {
        slot_check = true;
        click_item_button(3);
    }


    public void click_item_1()
    {
        slot_check = false;
        click_item_button(0);
    }
    public void click_item_2()
    {
        slot_check = false;
        click_item_button(1);
        slot_check = false;
    }
    public void click_item_3()
    {
        slot_check = false;
        click_item_button(2);
        slot_check = false;
    }
    public void click_item_4()
    {
        slot_check = false;
        click_item_button(3);
        slot_check = false;
    }
    public void click_item_5()
    {
        slot_check = false;
        click_item_button(4);
        slot_check = false;
    }
    public void click_item_6()
    {
        slot_check = false;
        click_item_button(5);
        slot_check = false;
    }
    public void click_item_7()
    {
        slot_check = false;
        click_item_button(6);
        slot_check = false;
    }
    public void click_item_8()
    {
        slot_check = false;
        click_item_button(7);
        slot_check = false;
    }
    public void click_item_9()
    {
        slot_check = false;
        click_item_button(8);
        slot_check = false;
    }
    public void click_item_10()
    {
        slot_check = false;
        click_item_button(9);
        slot_check = false;
    }
    public void click_item_11()
    {
        slot_check = false;
        click_item_button(10);
        slot_check = false;
    }
    public void click_item_12()
    {
        slot_check = false;
        click_item_button(11);
        slot_check = false;
    }

    public void click_item_button(int button_num)
    {
        GameObject select_x = GameObject.Find("select_x");

        select_num = button_num;

        if(spec_open_check == true)
        {
            select_x.SetActive(false);
            spec_open_check = false;
        }

        item_s = GameObject.Find("item_s_i").GetComponent<Image>();

        if (slot_check)
        {
            change_t = GameObject.Find("change_t").GetComponent<Text>();
            change_t.text = "해제";
            

            if (button_num == 0)
            {
                item_s.sprite = hat_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4)].item_key];
            }
            else if (button_num == 1)
            {
                item_s.sprite = glasses_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4) + 1].item_key / 10];
            }
            else if (button_num == 2)
            {
                item_s.sprite = back_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4) + 2].item_key / 100];
            }
            else if (button_num == 3)
            {
                item_s.sprite = shoes_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4) + 3].item_key / 1000];
            }

        }
        else
        {
            change_t = GameObject.Find("change_t").GetComponent<Text>();
            change_t.text = "장착";

            if (GameManager.instance.UserItem[button_num].key < 10)
            {
                item_s.sprite = hat_item_card[GameManager.instance.UserItem[button_num].key];
            }
            else if (GameManager.instance.UserItem[button_num].key < 100)
            {
                item_s.sprite = glasses_item_card[(GameManager.instance.UserItem[button_num].key) / 10];
            }
            else if (GameManager.instance.UserItem[button_num].key < 1000)
            {
                item_s.sprite = back_item_card[(GameManager.instance.UserItem[button_num].key) / 100];
            }
            else if (GameManager.instance.UserItem[button_num].key < 10000)
            {
                item_s.sprite = shoes_item_card[(GameManager.instance.UserItem[button_num].key) / 1000];
            }
        }
    }

    public void click_change_button()
    {
        horse_s_n = GameManager.instance.select;

        if (slot_check)  //해제
        {
            if (select_num == 0)  //모자해제
            {
                GameObject under = GameObject.Find("hat_h" + horse_s_n.ToString());
                GameObject temp = Instantiate(hat_item[(GameManager.instance.WearingItem[(GameManager.instance.select * 4)].item_key)], under.transform.position, Quaternion.identity);
                temp.transform.parent = under.transform;

            }
            else if (select_num == 1)  //안경해제
            {
                item_s.sprite = glasses_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4) + 1].item_key / 10];
            }
            else if (select_num == 2)  //등해제
            {
                item_s.sprite = back_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4) + 2].item_key / 100];
            }
            else if (select_num == 3)  //신발해제
            {
                item_s.sprite = shoes_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4) + 3].item_key / 1000];
            }
        }
        else  //장착
        {
            if (GameManager.instance.UserItem[select_num].key < 10)
            {
                int horse_ss = horse_s_n + 1;
                GameObject under = GameObject.Find("hat_h" + horse_ss.ToString());
                GameObject temp = Instantiate(hat_item[GameManager.instance.UserItem[select_num].key], under.transform.position, Quaternion.identity);
                temp.transform.parent = under.transform;
                
                if(GameManager.instance.WearingItem[(horse_s_n * 4)].item_key == 0)
                {
                    GameManager.instance.WearingItem[(horse_s_n * 4)].item_key = GameManager.instance.UserItem[select_num].key;
                    GameManager.instance.WearingItem[(horse_s_n * 4)].speed = GameManager.instance.UserItem[select_num].speed;
                    GameManager.instance.WearingItem[(horse_s_n * 4)].accel = GameManager.instance.UserItem[select_num].accel;
                    GameManager.instance.WearingItem[(horse_s_n * 4)].hp = GameManager.instance.UserItem[select_num].hp;
                    GameManager.instance.WearingItem[(horse_s_n * 4)].agility = GameManager.instance.UserItem[select_num].agility;
                    GameManager.instance.WearingItem[(horse_s_n * 4)].consis = GameManager.instance.UserItem[select_num].consis;

                    //정렬
                    for (int i = select_num; i < GameManager.instance.itemMany; i++)
                    {
                        GameManager.instance.UserItem[i].key = GameManager.instance.UserItem[i + 1].key;
                        GameManager.instance.UserItem[i].speed = GameManager.instance.UserItem[i + 1].speed;
                        GameManager.instance.UserItem[i].accel = GameManager.instance.UserItem[i + 1].accel;
                        GameManager.instance.UserItem[i].hp = GameManager.instance.UserItem[i + 1].hp;
                        GameManager.instance.UserItem[i].agility = GameManager.instance.UserItem[i + 1].agility;
                        GameManager.instance.UserItem[i].consis = GameManager.instance.UserItem[i + 1].consis;
                    }

                    if(select_num == 11)
                    {
                        GameManager.instance.UserItem[select_num - 1].key = -1;
                        GameManager.instance.UserItem[select_num - 1].speed = -1;
                        GameManager.instance.UserItem[select_num - 1].accel = -1;
                        GameManager.instance.UserItem[select_num - 1].hp = -1;
                        GameManager.instance.UserItem[select_num - 1].agility = -1;
                        GameManager.instance.UserItem[select_num - 1].consis = -1;
                    }

                    GameManager.instance.itemMany = GameManager.instance.itemMany - 1;

                    inven_itemlist_make(horse_s_n);
                    Debug.Log(1);
                }
            }
            else if (GameManager.instance.UserItem[select_num].key < 100)
            {
                item_s.sprite = glasses_item_card[(GameManager.instance.UserItem[select_num].key) / 10];
            }
            else if (GameManager.instance.UserItem[select_num].key < 1000)
            {
                item_s.sprite = back_item_card[(GameManager.instance.UserItem[select_num].key) / 100];
            }
            else if (GameManager.instance.UserItem[select_num].key < 10000)
            {
                item_s.sprite = shoes_item_card[(GameManager.instance.UserItem[select_num].key) / 1000];
            }
        }
        //GameObject select_x = GameObject.Find("select_x");
        //select_x.SetActive(true);
        //spec_open_check = true;
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
