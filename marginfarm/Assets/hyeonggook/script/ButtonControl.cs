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
 
    public Image cap_b;

    public Sprite[] captain_check = new Sprite[2];

    public Texture[] horse_render = new Texture[6];

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
    public int what_item;
    public Animator anim;

    public GameObject fadeImg;

    public TempItemInfo[] TempUserItem = new TempItemInfo[]
    {
        new TempItemInfo (0, 0, 0, 0, 0, 0)
    };

    public int data;
    public int i;
    public int[] userdata = new int[5];
    public int[] userdatapitem = new int[5];
    public int[] itemdata = new int[5];

    public GameObject picture;
    public Transform camera_po;

    public void Start()
    {
        spec_open_check = true;
        StartCoroutine("FadeInStart");
    }
    public void specview_close()  //스펙뷰 닫으면 카메라 원위치 이동시키고 창 닫기
    {
        int m = GameManager.instance.select + 1;
        anim = GameObject.Find("horse_o" + m.ToString()).GetComponent<Animator>();
        anim.SetBool("inven", false);

        if (GameManager.instance.spec_check == true)
        {
            GameObject spec = GameObject.Find("spec");
            iTween.MoveTo(spec, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));

            GameObject picture = GameObject.Find("Main Camera");
            camera_po = GameObject.Find("c_main").GetComponent<Transform>();
            iTween.RotateTo(picture, iTween.Hash("rotation", new Vector3(20.22f, 116.198f, 2.54f), "delay", 0.1f, "time", 2f));
            iTween.MoveTo(picture, iTween.Hash("position", camera_po.position, "delay", 0.1f, "time", 2f));

            GameManager.instance.spec_check = false;

            GameManager.instance.select = -1;
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

            if(spec_open_check == false)
            {
                GameObject.Find("inven").transform.Find("select_x").gameObject.SetActive(true);
                spec_open_check = true;
            }
            
        }
    }
    public void specview_h1()
    {
        if(GameManager.instance.select != -1)
        {
            int n = GameManager.instance.select + 1;
            anim = GameObject.Find("horse_o" + n.ToString()).GetComponent<Animator>();
            anim.SetBool("inven", false);
        }
        GameManager.instance.select = 0;

        int m = GameManager.instance.select + 1;
        anim = GameObject.Find("horse_o" + m.ToString()).GetComponent<Animator>();
        anim.SetBool("inven", true);
        spec_make();
        inven_itemlist_make(data);
    }
    public void specview_h2()
    {
        if (GameManager.instance.select != -1)
        {
            int n = GameManager.instance.select + 1;
            anim = GameObject.Find("horse_o" + n.ToString()).GetComponent<Animator>();
            anim.SetBool("inven", false);
        }
        GameManager.instance.select = 1;

        int m = GameManager.instance.select + 1;
        anim = GameObject.Find("horse_o" + m.ToString()).GetComponent<Animator>();
        anim.SetBool("inven", true);

        spec_make();
        inven_itemlist_make(data);
    }
    public void specview_h3()
    {
        if (GameManager.instance.select != -1)
        {
            int n = GameManager.instance.select + 1;
            anim = GameObject.Find("horse_o" + n.ToString()).GetComponent<Animator>();
            anim.SetBool("inven", false);
        }
        GameManager.instance.select = 2;

        int m = GameManager.instance.select + 1;
        anim = GameObject.Find("horse_o" + m.ToString()).GetComponent<Animator>();
        anim.SetBool("inven", true);
        spec_make();
        inven_itemlist_make(data);
    }
    public void specview_h4()
    {
        if (GameManager.instance.select != -1)
        {
            int n = GameManager.instance.select + 1;
            anim = GameObject.Find("horse_o" + n.ToString()).GetComponent<Animator>();
            anim.SetBool("inven", false);
        }
        GameManager.instance.select = 3;

        int m = GameManager.instance.select + 1;
        anim = GameObject.Find("horse_o" + m.ToString()).GetComponent<Animator>();
        anim.SetBool("inven", true);
        spec_make();
        inven_itemlist_make(data);
    }
    public void specview_h5()
    {
        if (GameManager.instance.select != -1)
        {
            int n = GameManager.instance.select + 1;
            anim = GameObject.Find("horse_o" + n.ToString()).GetComponent<Animator>();
            anim.SetBool("inven", false);
        }
        GameManager.instance.select = 4;

        int m = GameManager.instance.select + 1;
        anim = GameObject.Find("horse_o" + m.ToString()).GetComponent<Animator>();
        anim.SetBool("inven", true);
        spec_make();
        inven_itemlist_make(data);
    }
    public void specview_h6()
    {
        if (GameManager.instance.select != -1)
        {
            int n = GameManager.instance.select + 1;
            anim = GameObject.Find("horse_o" + n.ToString()).GetComponent<Animator>();
            anim.SetBool("inven", false);
        }
        GameManager.instance.select = 5;

        int m = GameManager.instance.select + 1;
        anim = GameObject.Find("horse_o" + m.ToString()).GetComponent<Animator>();
        anim.SetBool("inven", true);
        spec_make();
        inven_itemlist_make(data);
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
            
            if (GameManager.instance.UserItem[i - 1].key < 10)
            {
                item_i.sprite = GameManager.instance.hat_item_card[GameManager.instance.UserItem[i - 1].key];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 100)
            {
                item_i.sprite = GameManager.instance.glasses_item_card[(GameManager.instance.UserItem[i - 1].key) / 10];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 1000)
            {
                item_i.sprite = GameManager.instance.back_item_card[(GameManager.instance.UserItem[i - 1].key) / 100];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 10000)
            {
                item_i.sprite = GameManager.instance.shoes_item_card[(GameManager.instance.UserItem[i - 1].key) / 1000];
            }
        }
        for (int i = 12; i > GameManager.instance.itemMany; i--)
        {
            item_b = GameObject.Find("item" + i.ToString()).GetComponent<Button>();
            item_i = GameObject.Find("item" + i.ToString() + "_i").GetComponent<Image>();
            item_i.sprite = GameManager.instance.hat_item_card[1];
            item_b.interactable = false;
        }

        slot_back = GameObject.Find("slot_back_i").GetComponent<Image>();
        slot_hat = GameObject.Find("slot_hat_i").GetComponent<Image>();
        slot_glasses = GameObject.Find("slot_glasses_i").GetComponent<Image>();
        slot_shoes = GameObject.Find("slot_shoes_i").GetComponent<Image>();

        if (GameManager.instance.WearingItem[(sel_num * 4)].item_key != 0)
        {
            slot_hat.sprite = GameManager.instance.hat_item_card[GameManager.instance.WearingItem[(sel_num * 4)].item_key];
        }
        else
        {
            slot_hat.sprite = GameManager.instance.hat_item_card[0];
        }

        if (GameManager.instance.WearingItem[(sel_num * 4) + 1].item_key != 0)
        {
            slot_glasses.sprite = GameManager.instance.glasses_item_card[GameManager.instance.WearingItem[(sel_num * 4) + 1].item_key / 10];
        }
        else
        {
            slot_glasses.sprite = GameManager.instance.glasses_item_card[0];
        }

        if (GameManager.instance.WearingItem[(sel_num * 4) + 2].item_key != 0)
        {
            slot_back.sprite = GameManager.instance.back_item_card[GameManager.instance.WearingItem[(sel_num * 4) + 2].item_key / 100];
        }
        else
        {
            slot_back.sprite = GameManager.instance.back_item_card[0];
        }

        if (GameManager.instance.WearingItem[(sel_num * 4) + 3].item_key != 0)
        {
            slot_shoes.sprite = GameManager.instance.shoes_item_card[GameManager.instance.WearingItem[(sel_num * 4) + 3].item_key / 1000];
        }
        else
        {
            slot_shoes.sprite = GameManager.instance.shoes_item_card[0];
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

        if (spec_open_check == true)
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
                item_s.sprite = GameManager.instance.hat_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4)].item_key];
                itemdata[0] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].speed;
                itemdata[1] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].accel;
                itemdata[2] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].hp;
                itemdata[3] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].agility;
                itemdata[4] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].consis;
            }
            else if (button_num == 1)
            {
                item_s.sprite = GameManager.instance.glasses_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4) + 1].item_key / 10];
                itemdata[0] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].speed;
                itemdata[1] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].accel;
                itemdata[2] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].hp;
                itemdata[3] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].agility;
                itemdata[4] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].consis;
            }
            else if (button_num == 2)
            {
                item_s.sprite = GameManager.instance.back_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4) + 2].item_key / 100];
                itemdata[0] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].speed;
                itemdata[1] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].accel;
                itemdata[2] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].hp;
                itemdata[3] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].agility;
                itemdata[4] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].consis;
            }
            else if (button_num == 3)
            {
                item_s.sprite = GameManager.instance.shoes_item_card[GameManager.instance.WearingItem[(GameManager.instance.select * 4) + 3].item_key / 1000];
                itemdata[0] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].speed;
                itemdata[1] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].accel;
                itemdata[2] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].hp;
                itemdata[3] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].agility;
                itemdata[4] = GameManager.instance.WearingItem[(GameManager.instance.select * 4) + button_num].consis;
            }

            for (int i = 1; i < 6; i++)
            {
                bar = GameObject.Find("itemgauge" + i.ToString()).GetComponent<Image>();
                bar.fillAmount = itemdata[i - 1] / 20f;
                gauge = GameObject.Find("itemgauge_t" + i.ToString()).GetComponent<Text>();
                gauge.text = itemdata[i - 1].ToString();
            }

        }
        else
        {
            change_t = GameObject.Find("change_t").GetComponent<Text>();
            change_t.text = "장착";

            if (GameManager.instance.UserItem[button_num].key < 10)
            {
                item_s.sprite = GameManager.instance.hat_item_card[GameManager.instance.UserItem[button_num].key];
                itemdata[0] = GameManager.instance.UserItem[button_num].speed;
                itemdata[1] = GameManager.instance.UserItem[button_num].accel;
                itemdata[2] = GameManager.instance.UserItem[button_num].hp;
                itemdata[3] = GameManager.instance.UserItem[button_num].agility;
                itemdata[4] = GameManager.instance.UserItem[button_num].consis;
            }
            else if (GameManager.instance.UserItem[button_num].key < 100)
            {
                item_s.sprite = GameManager.instance.glasses_item_card[(GameManager.instance.UserItem[button_num].key) / 10];
                itemdata[0] = GameManager.instance.UserItem[button_num].speed;
                itemdata[1] = GameManager.instance.UserItem[button_num].accel;
                itemdata[2] = GameManager.instance.UserItem[button_num].hp;
                itemdata[3] = GameManager.instance.UserItem[button_num].agility;
                itemdata[4] = GameManager.instance.UserItem[button_num].consis;
            }
            else if (GameManager.instance.UserItem[button_num].key < 1000)
            {
                item_s.sprite = GameManager.instance.back_item_card[(GameManager.instance.UserItem[button_num].key) / 100];
                itemdata[0] = GameManager.instance.UserItem[button_num].speed;
                itemdata[1] = GameManager.instance.UserItem[button_num].accel;
                itemdata[2] = GameManager.instance.UserItem[button_num].hp;
                itemdata[3] = GameManager.instance.UserItem[button_num].agility;
                itemdata[4] = GameManager.instance.UserItem[button_num].consis;
            }
            else if (GameManager.instance.UserItem[button_num].key < 10000)
            {
                item_s.sprite = GameManager.instance.shoes_item_card[(GameManager.instance.UserItem[button_num].key) / 1000];
                itemdata[0] = GameManager.instance.UserItem[button_num].speed;
                itemdata[1] = GameManager.instance.UserItem[button_num].accel;
                itemdata[2] = GameManager.instance.UserItem[button_num].hp;
                itemdata[3] = GameManager.instance.UserItem[button_num].agility;
                itemdata[4] = GameManager.instance.UserItem[button_num].consis;
            }

            for (int i = 1; i < 6; i++)
            {
                bar = GameObject.Find("itemgauge" + i.ToString()).GetComponent<Image>();
                bar.fillAmount = itemdata[i - 1] / 20f;
                gauge = GameObject.Find("itemgauge_t" + i.ToString()).GetComponent<Text>();
                gauge.text = itemdata[i - 1].ToString();
            }
        }
    }

    public void click_change_button()
    {
        horse_s_n = GameManager.instance.select;
        int horse_ss = horse_s_n + 1;
        bool n = false;

        if (slot_check)  //해제
        {
            if (select_num == 0)  //모자해제
            {
                if(GameManager.instance.itemMany != 12)
                {
                    GameObject under = GameObject.Find("hat_h" + horse_ss.ToString());
                    GameObject temp = under.transform.GetChild(0).gameObject;
                    Destroy(temp);

                    uninstall(select_num);
                    inven_itemlist_make(horse_s_n);
                    spec_make();
                }
                else
                {
                    senderror("아이템 보관함이 꽉찼습니다.");
                }
            }
            else if (select_num == 1)  //안경해제
            {
                if (GameManager.instance.itemMany != 12)
                {
                    GameObject under = GameObject.Find("glasses_h" + horse_ss.ToString());
                    GameObject temp = under.transform.GetChild(0).gameObject;
                    Destroy(temp);

                    uninstall(select_num);
                    inven_itemlist_make(horse_s_n);
                    spec_make();
                }
                else
                {
                    senderror("아이템 보관함이 꽉찼습니다.");
                }
            }
            else if (select_num == 2)  //등해제
            {
                if (GameManager.instance.itemMany != 12)
                {
                    GameObject under = GameObject.Find("back_h" + horse_ss.ToString());
                    GameObject temp = under.transform.GetChild(0).gameObject;
                    Destroy(temp);

                    uninstall(select_num);
                    inven_itemlist_make(horse_s_n);
                    spec_make();
                }
                else
                {
                    senderror("아이템 보관함이 꽉찼습니다.");
                }
            }
            else if (select_num == 3)  //신발해제
            {
                if (GameManager.instance.itemMany != 12)
                {
                    GameObject under = GameObject.Find("shoes_h" + horse_ss.ToString());
                    GameObject temp = under.transform.GetChild(0).gameObject;
                    Destroy(temp);

                    uninstall(select_num);
                    inven_itemlist_make(horse_s_n);
                    spec_make();
                }
                else
                {
                    senderror("아이템 보관함이 꽉찼습니다.");
                }
            }
        }
        else  //장착
        {
            if (GameManager.instance.UserItem[select_num].key < 10)
            {
                if(GameManager.instance.WearingItem[(horse_s_n * 4)].item_key != 0)
                {
                    GameObject under1 = GameObject.Find("hat_h" + horse_ss.ToString());
                    GameObject temp1 = under1.transform.GetChild(0).gameObject;
                    Destroy(temp1);
                }

                GameObject under = GameObject.Find("hat_h" + horse_ss.ToString());
                GameObject temp = Instantiate(GameManager.instance.hat_item[GameManager.instance.UserItem[select_num].key], under.transform.position, Quaternion.Euler(new Vector3(38f, -97f, -6f)));
                temp.transform.parent = under.transform;

                what_item = 0;
                install(what_item, select_num);

                inven_itemlist_make(horse_s_n);
                spec_make();

            }
            else if (GameManager.instance.UserItem[select_num].key < 100)
            {
                if (GameManager.instance.WearingItem[(horse_s_n * 4) + 1].item_key != 0)
                {
                    GameObject under1 = GameObject.Find("glasses_h" + horse_ss.ToString());
                    GameObject temp1 = under1.transform.GetChild(0).gameObject;
                    Destroy(temp1);
                }

                GameObject under = GameObject.Find("glasses_h" + horse_ss.ToString());
                GameObject temp = Instantiate(GameManager.instance.glasses_item[GameManager.instance.UserItem[select_num].key / 10], under.transform.position, Quaternion.Euler(new Vector3(20f, -87f, -1f)));
                temp.transform.parent = under.transform;

                what_item = 1;
                install(what_item, select_num);

                inven_itemlist_make(horse_s_n);
                spec_make();
            }
            else if (GameManager.instance.UserItem[select_num].key < 1000)
            {
                if (GameManager.instance.WearingItem[(horse_s_n * 4) + 2].item_key != 0)
                {
                    GameObject under1 = GameObject.Find("back_h" + horse_ss.ToString());
                    GameObject temp1 = under1.transform.GetChild(0).gameObject;
                    Destroy(temp1);
                }

                GameObject under = GameObject.Find("back_h" + horse_ss.ToString());
                GameObject temp = Instantiate(GameManager.instance.back_item[GameManager.instance.UserItem[select_num].key / 100], under.transform.position, Quaternion.Euler(new Vector3(-178f, -178f, 243f)));
                temp.transform.parent = under.transform;

                what_item = 2;
                install(what_item, select_num);

                inven_itemlist_make(horse_s_n);
                spec_make();
            }
            else if (GameManager.instance.UserItem[select_num].key < 10000)
            {
                if (GameManager.instance.WearingItem[(horse_s_n * 4) + 3].item_key != 0)
                {
                    GameObject under1 = GameObject.Find("shoes_h" + horse_ss.ToString());
                    GameObject temp1 = under1.transform.GetChild(0).gameObject;
                    Destroy(temp1);
                }

                GameObject under = GameObject.Find("shoes_h" + horse_ss.ToString());
                GameObject temp = Instantiate(GameManager.instance.shoes_item[GameManager.instance.UserItem[select_num].key / 1000], under.transform.position, Quaternion.Euler(new Vector3(-178f, -178f, 243f)));
                temp.transform.parent = under.transform;

                what_item = 3;
                install(what_item, select_num);

                inven_itemlist_make(horse_s_n);
                spec_make();
            }
        }

        GameObject.Find("inven").transform.Find("select_x").gameObject.SetActive(true);
        spec_open_check = true;
    }

    public void captain_click()
    {
        cap_b = GameObject.Find("cap").GetComponent<Image>();
        cap_b.sprite = captain_check[1];
        
        GameManager.instance.captain = GameManager.instance.select;
    }

    public void gotohome()
    {
        StartCoroutine("FadeOutStart_main");
    }

    public void gotoshop()
    {
        StartCoroutine("FadeOutStart_gacha");
    }

    public void install(int item, int select_num)
    {
        bool n = false;

        if (GameManager.instance.WearingItem[(horse_s_n * 4) + item].item_key != 0)
        {
            TempUserItem[0].key = GameManager.instance.WearingItem[(horse_s_n * 4) + item].item_key;
            TempUserItem[0].speed = GameManager.instance.WearingItem[(horse_s_n * 4) + item].speed;
            TempUserItem[0].accel = GameManager.instance.WearingItem[(horse_s_n * 4) + item].accel;
            TempUserItem[0].hp = GameManager.instance.WearingItem[(horse_s_n * 4) + item].hp;
            TempUserItem[0].agility = GameManager.instance.WearingItem[(horse_s_n * 4) + item].agility;
            TempUserItem[0].consis = GameManager.instance.WearingItem[(horse_s_n * 4) + item].consis;
            n = true;

        }

        GameManager.instance.WearingItem[(horse_s_n * 4) + item].item_key = GameManager.instance.UserItem[select_num].key;
        GameManager.instance.WearingItem[(horse_s_n * 4) + item].speed = GameManager.instance.UserItem[select_num].speed;
        GameManager.instance.WearingItem[(horse_s_n * 4) + item].accel = GameManager.instance.UserItem[select_num].accel;
        GameManager.instance.WearingItem[(horse_s_n * 4) + item].hp = GameManager.instance.UserItem[select_num].hp;
        GameManager.instance.WearingItem[(horse_s_n * 4) + item].agility = GameManager.instance.UserItem[select_num].agility;
        GameManager.instance.WearingItem[(horse_s_n * 4) + item].consis = GameManager.instance.UserItem[select_num].consis;


        for (int i = select_num; i < GameManager.instance.itemMany - 1; i++)                       
        {
            GameManager.instance.UserItem[i].key = GameManager.instance.UserItem[i + 1].key;
            GameManager.instance.UserItem[i].speed = GameManager.instance.UserItem[i + 1].speed;
            GameManager.instance.UserItem[i].accel = GameManager.instance.UserItem[i + 1].accel;
            GameManager.instance.UserItem[i].hp = GameManager.instance.UserItem[i + 1].hp;
            GameManager.instance.UserItem[i].agility = GameManager.instance.UserItem[i + 1].agility;
            GameManager.instance.UserItem[i].consis = GameManager.instance.UserItem[i + 1].consis;
        }

        GameManager.instance.UserItem[GameManager.instance.itemMany - 1].key = -1;
        GameManager.instance.UserItem[GameManager.instance.itemMany - 1].speed = -1;
        GameManager.instance.UserItem[GameManager.instance.itemMany - 1].accel = -1;
        GameManager.instance.UserItem[GameManager.instance.itemMany - 1].hp = -1;
        GameManager.instance.UserItem[GameManager.instance.itemMany - 1].agility = -1;
        GameManager.instance.UserItem[GameManager.instance.itemMany - 1].consis = -1;

        GameManager.instance.itemMany = GameManager.instance.itemMany - 1;

        if (n)
        {
            int m = GameManager.instance.itemMany;
            GameManager.instance.UserItem[m].key = TempUserItem[0].key;
            GameManager.instance.UserItem[m].speed = TempUserItem[0].speed;
            GameManager.instance.UserItem[m].accel = TempUserItem[0].accel;
            GameManager.instance.UserItem[m].hp = TempUserItem[0].hp;
            GameManager.instance.UserItem[m].agility = TempUserItem[0].agility;
            GameManager.instance.UserItem[m].consis = TempUserItem[0].consis;
            n = false;

            GameManager.instance.itemMany = GameManager.instance.itemMany + 1;
        }
    }

    public void uninstall(int select_num)
    {
        int k = GameManager.instance.itemMany;
        
        GameManager.instance.UserItem[k].key = GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].item_key;
        GameManager.instance.UserItem[k].speed = GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].speed;
        GameManager.instance.UserItem[k].accel = GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].accel;
        GameManager.instance.UserItem[k].hp = GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].hp;
        GameManager.instance.UserItem[k].agility = GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].agility;
        GameManager.instance.UserItem[k].consis = GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].consis;

        GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].item_key = 0;
        GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].speed = 0;
        GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].accel = 0;
        GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].hp = 0;
        GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].agility = 0;
        GameManager.instance.WearingItem[(horse_s_n * 4) + select_num].consis = 0;

        GameManager.instance.itemMany = GameManager.instance.itemMany + 1;
        
    }

    public void senderror(string message)
    {
        GameObject error_p = GameObject.Find("error");
        Text error_m = GameObject.Find("error_m").GetComponent<Text>();

        error_m.text = message;
        iTween.MoveTo(error_p, iTween.Hash("y", 680, "delay", 0, "time", 0.5f));
        iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 1.5f, "time", 0.5f));
    }

    public void sendcheck(string message)
    {
        GameObject error_p = GameObject.Find("check");
        Text error_m = GameObject.Find("check_m").GetComponent<Text>();

        error_m.text = message;
        iTween.MoveTo(error_p, iTween.Hash("y", 680, "delay", 0, "time", 0.5f));
      
    }

    public void click_bye()
    {
        if (GameManager.instance.captain == GameManager.instance.select)
        {
            senderror("대표말은 보낼 수 없습니다.");
        }
        else
        {
            sendcheck(GameManager.instance.UserHorse[GameManager.instance.select].name + " 말을 보내시겠습니까?");
        }
        
    }

    public void click_bye_yes()
    {
        byemyhorse();

        //GameObject error_p = GameObject.Find("check");
        //iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 0.2f, "time", 0.5f));

        //specview_close();

    }

    public void click_bye_no()
    {
        GameObject error_p = GameObject.Find("check");
        iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 0.2f, "time", 0.5f));
    }
    public void byemyhorse()
    {
        int horse_n = GameManager.instance.select;

        for (int i = horse_n; i < GameManager.instance.many - 1; i++)
        {
            GameManager.instance.UserHorse[i].name = GameManager.instance.UserHorse[i + 1].name;
            GameManager.instance.UserHorse[i].key = GameManager.instance.UserHorse[i + 1].key;
            GameManager.instance.UserHorse[i].level = GameManager.instance.UserHorse[i + 1].level;
            GameManager.instance.UserHorse[i].speed = GameManager.instance.UserHorse[i + 1].speed;
            GameManager.instance.UserHorse[i].hp = GameManager.instance.UserHorse[i + 1].hp;
            GameManager.instance.UserHorse[i].agility = GameManager.instance.UserHorse[i + 1].agility;
            GameManager.instance.UserHorse[i].consis = GameManager.instance.UserHorse[i + 1].consis;
            GameManager.instance.UserHorse[i].items = GameManager.instance.UserHorse[i + 1].items;

            for(int n = 0; n < 4; n++)
            {
                GameManager.instance.WearingItem[(horse_n * 4) + n].item_key = GameManager.instance.WearingItem[((horse_n + 1) * 4) + n].item_key;
                GameManager.instance.WearingItem[(horse_n * 4) + n].speed = GameManager.instance.WearingItem[((horse_n + 1) * 4) + n].speed;
                GameManager.instance.WearingItem[(horse_n * 4) + n].accel = GameManager.instance.WearingItem[((horse_n + 1) * 4) + n].accel;
                GameManager.instance.WearingItem[(horse_n * 4) + n].hp = GameManager.instance.WearingItem[((horse_n + 1) * 4) + n].hp;
                GameManager.instance.WearingItem[(horse_n * 4) + n].agility = GameManager.instance.WearingItem[((horse_n + 1) * 4) + n].agility;
                GameManager.instance.WearingItem[(horse_n * 4) + n].consis = GameManager.instance.WearingItem[((horse_n + 1) * 4) + n].consis;
            }
        }

        GameManager.instance.UserHorse[GameManager.instance.many - 1].name = "";
        GameManager.instance.UserHorse[GameManager.instance.many - 1].key = -1;
        GameManager.instance.UserHorse[GameManager.instance.many - 1].level = -1;
        GameManager.instance.UserHorse[GameManager.instance.many - 1].speed = -1;
        GameManager.instance.UserHorse[GameManager.instance.many - 1].hp = -1;
        GameManager.instance.UserHorse[GameManager.instance.many - 1].agility = -1;
        GameManager.instance.UserHorse[GameManager.instance.many - 1].consis = -1;

        GameManager.instance.many = GameManager.instance.many - 1;

        for (int n = 0; n < 4; n++)
        {
            GameManager.instance.WearingItem[(GameManager.instance.many * 4) + n].item_key = 0;
            GameManager.instance.WearingItem[(GameManager.instance.many * 4) + n].speed = 0;
            GameManager.instance.WearingItem[(GameManager.instance.many * 4) + n].accel = 0;
            GameManager.instance.WearingItem[(GameManager.instance.many * 4) + n].hp = 0;
            GameManager.instance.WearingItem[(GameManager.instance.many * 4) + n].agility = 0;
            GameManager.instance.WearingItem[(GameManager.instance.many * 4) + n].consis = 0;
        }

        StartCoroutine("FadeOutStart_restart");
    }

    public void spec_make()
    {
        data = GameManager.instance.select;

        name_t = GameObject.Find("name_t").GetComponent<Text>();
        name_t.text = GameManager.instance.UserHorse[data].name;

        userdata[0] = GameManager.instance.UserHorse[data].speed;
        userdatapitem[0] = userdata[0] + GameManager.instance.WearingItem[(data * 4)].speed + GameManager.instance.WearingItem[(data * 4) + 1].speed + GameManager.instance.WearingItem[(data * 4) + 2].speed + GameManager.instance.WearingItem[(data * 4) + 3].speed;
        userdata[1] = GameManager.instance.UserHorse[data].accel;
        userdatapitem[1] = userdata[1] + GameManager.instance.WearingItem[(data * 4)].accel + GameManager.instance.WearingItem[(data * 4) + 1].accel + GameManager.instance.WearingItem[(data * 4) + 2].accel + GameManager.instance.WearingItem[(data * 4) + 3].accel;
        userdata[2] = GameManager.instance.UserHorse[data].hp;
        userdatapitem[2] = userdata[2] + GameManager.instance.WearingItem[(data * 4)].hp + GameManager.instance.WearingItem[(data * 4) + 1].hp + GameManager.instance.WearingItem[(data * 4) + 2].hp + GameManager.instance.WearingItem[(data * 4) + 3].hp;
        userdata[3] = GameManager.instance.UserHorse[data].agility;
        userdatapitem[3] = userdata[3] + GameManager.instance.WearingItem[(data * 4)].agility + GameManager.instance.WearingItem[(data * 4) + 1].agility + GameManager.instance.WearingItem[(data * 4) + 2].agility + GameManager.instance.WearingItem[(data * 4) + 3].agility;
        userdata[4] = GameManager.instance.UserHorse[data].consis;
        userdatapitem[4] = userdata[4] + GameManager.instance.WearingItem[(data * 4)].consis + GameManager.instance.WearingItem[(data * 4) + 1].consis + GameManager.instance.WearingItem[(data * 4) + 2].consis + GameManager.instance.WearingItem[(data * 4) + 3].consis;

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
            bar = GameObject.Find("gauge_i" + i.ToString()).GetComponent<Image>();
            bar.fillAmount = userdatapitem[i - 1] / 100f;
            gauge = GameObject.Find("gauge_t" + i.ToString()).GetComponent<Text>();
            gauge.text = userdatapitem[i - 1].ToString() + "/ 100";
        }

        cap_b = GameObject.Find("cap").GetComponent<Image>();

        if (GameManager.instance.captain == GameManager.instance.select)
        {
            cap_b.sprite = captain_check[1];
        }
        else
        {
            cap_b.sprite = captain_check[0];
        }
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
        //yield return new WaitForSeconds(1);
        fadeImg.SetActive(false);
    }

    //페이드 인
    public IEnumerator FadeOutStart_main()
    {
        fadeImg.SetActive(true);
        for (float f = 0f; f < 1; f += 0.02f)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("aftermain");
    }

    public IEnumerator FadeOutStart_gacha()
    {
        fadeImg.SetActive(true);
        for (float f = 0f; f < 1; f += 0.02f)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("gacha");
    }

    public IEnumerator FadeOutStart_restart()
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


}
