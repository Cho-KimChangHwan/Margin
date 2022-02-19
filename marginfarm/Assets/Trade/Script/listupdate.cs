using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class listupdate : MonoBehaviour
{
    DatabaseReference m_Reference;

    public Image item_i;
    public Button item_b;

    public int select_num;
    public bool spec_open_check;

    public Image item_s;
    public GameObject select_x;
    public Text change_t;
    public int[] itemdata = new int[5];
    public Image bar;
    public Text gauge;

    public bool slot_check;

    // Start is called before the first frame update
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        inven_itemlist_make();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void inven_itemlist_make()
    {
        for (int i = 1; i <= GameManager.instance.itemMany; i++)
        {
            Debug.Log("item" + i.ToString() + "_i");
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

    public void sell_button_click()
    {
        // 여기에 넣으세요 준영씨 마켓데이터베이스에 저장하는 것을. 저장해야할 아이템 인덱스는 select_num 변수에 저장되어 있답니다. ㅎㅎ
        delete_item();

        GameObject.Find("SellList").transform.Find("select_x").gameObject.SetActive(true);
        spec_open_check = true;
    }

    public void delete_item()
    {
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

        m_Reference.Child("users").Child(GameManager.instance.Id).Child("itemMany").SetValueAsync(GameManager.instance.itemMany);

        for (int k = 0; k < GameManager.instance.itemMany + 1; k++)
        {
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("key").SetValueAsync(GameManager.instance.UserItem[k].key);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("speed").SetValueAsync(GameManager.instance.UserItem[k].speed);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("accel").SetValueAsync(GameManager.instance.UserItem[k].accel);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("hp").SetValueAsync(GameManager.instance.UserItem[k].hp);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("agility").SetValueAsync(GameManager.instance.UserItem[k].agility);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("consis").SetValueAsync(GameManager.instance.UserItem[k].consis);
        }
    }

}
