using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class ItemListMake : MonoBehaviour
{
    DatabaseReference m_Reference;

    public GameObject item_button;
    public GameObject content;
    public int a = 0;
    public int[] itemdata = new int[5];

    public int k;
    // Start is called before the first frame update
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        GetMarketFb();
        button_make();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void button_make()
    {
        a = 0;
        for (int i = 0; i < GameManager.instance.marketMany; i++)
        {
            GameObject temp = Instantiate(item_button, content.transform);
            Button temp_b = temp.GetComponent<Button>();
            GameObject temp_i = temp.transform.GetChild(0).gameObject;

            Image button_i = temp_i.transform.GetChild(0).gameObject.GetComponent<Image>();
            
            if (GameManager.instance.MarketItems[i].key < 10)
            {
                button_i.sprite = GameManager.instance.hat_item_card[GameManager.instance.MarketItems[i].key];
            }
            else if (GameManager.instance.MarketItems[i].key < 100)
            {
                button_i.sprite = GameManager.instance.glasses_item_card[(GameManager.instance.MarketItems[i].key) / 10];
            }
            else if (GameManager.instance.MarketItems[i].key < 1000)
            {
                button_i.sprite = GameManager.instance.back_item_card[(GameManager.instance.MarketItems[i].key) / 100];
            }
            else if (GameManager.instance.MarketItems[i].key < 10000)
            {
                button_i.sprite = GameManager.instance.shoes_item_card[(GameManager.instance.MarketItems[i].key) / 1000];
            }
            
            itemdata[0] = GameManager.instance.MarketItems[i].speed;
            itemdata[1] = GameManager.instance.MarketItems[i].accel;
            itemdata[2] = GameManager.instance.MarketItems[i].hp;
            itemdata[3] = GameManager.instance.MarketItems[i].agility;
            itemdata[4] = GameManager.instance.MarketItems[i].consis;
            
            Image bar;
            Text gauge;
            for (int m = 1; m < 6; m++)
            {
                bar = temp.transform.GetChild(m).gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
                bar.fillAmount = itemdata[m - 1] / 20f;
                gauge = temp.transform.GetChild(m).gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();
                gauge.text = itemdata[m - 1].ToString();
            }
            temp.GetComponent<GiveNum>().print_select = a;
            temp_b.onClick.AddListener(Click_market_i_button);
            a++;
        }
       
    }
    public void update_button()
    {
        GetMarketFb();
        Transform[] childList = content.GetComponentsInChildren<Transform>();

        if(childList != null) {
            for(int i = 1; i < childList.Length; i++) {
                if (childList[i] != transform) {
                    Destroy(childList[i].gameObject);
                }
            }
        }

        button_make();
    }
    public void GetMarketFb()
    {
        FirebaseDatabase.DefaultInstance.GetReference("market").Child("sellList")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                DataSnapshot snapshot = task.Result;
                //get first data
                GameManager.instance.marketMany = Convert.ToInt32(snapshot.Child("marketMany").Value);
                for (int i = 0; i < snapshot.Child("item" + i.ToString()).ChildrenCount; i++)
                {
                    GameManager.instance.MarketItems[i].key = Convert.ToInt32(snapshot.Child("item" + i.ToString()).Child("key").Value);
                    GameManager.instance.MarketItems[i].speed = Convert.ToInt32(snapshot.Child("item" + i.ToString()).Child("speed").Value);
                    GameManager.instance.MarketItems[i].accel = Convert.ToInt32(snapshot.Child("item" + i.ToString()).Child("accel").Value);
                    GameManager.instance.MarketItems[i].hp = Convert.ToInt32(snapshot.Child("item" + i.ToString()).Child("hp").Value);
                    GameManager.instance.MarketItems[i].agility = Convert.ToInt32(snapshot.Child("item" + i.ToString()).Child("agility").Value);
                    GameManager.instance.MarketItems[i].consis = Convert.ToInt32(snapshot.Child("item" + i.ToString()).Child("consis").Value);
                }
                Debug.Log("키값은??? : " + GameManager.instance.MarketItems[0].key.ToString());
            });
        FirebaseDatabase.DefaultInstance.GetReference("users").Child(GameManager.instance.Id)
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                DataSnapshot snapshot = task.Result;

                GameManager.instance.money = Convert.ToInt32(snapshot.Child("money").Value);
            });
    }

    public void Click_market_i_button()
    {
        k = GameManager.instance.market_select;

        //아이템 오브젝트 끼워주기
    }

    public void Click_go_button()
    {
        sendcheck_buy("아이템을 구매하시겠습니까?");
    }

    public void Get_item()
    {
        int m = GameManager.instance.itemMany;
        GameManager.instance.UserItem[m].key = GameManager.instance.MarketItems[k].key;
        GameManager.instance.UserItem[m].speed = GameManager.instance.MarketItems[k].speed;
        GameManager.instance.UserItem[m].accel = GameManager.instance.MarketItems[k].accel;
        GameManager.instance.UserItem[m].hp = GameManager.instance.MarketItems[k].hp;
        GameManager.instance.UserItem[m].agility = GameManager.instance.MarketItems[k].agility;
        GameManager.instance.UserItem[m].consis = GameManager.instance.MarketItems[k].consis;
        GameManager.instance.itemMany++;

        /*
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("itemMany").SetValueAsync(GameManager.instance.itemMany);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("key").SetValueAsync(GameManager.instance.UserItem[k].key);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("speed").SetValueAsync(GameManager.instance.UserItem[k].speed);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("accel").SetValueAsync(GameManager.instance.UserItem[k].accel);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("hp").SetValueAsync(GameManager.instance.UserItem[k].hp);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("agility").SetValueAsync(GameManager.instance.UserItem[k].agility);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (k.ToString())).Child("consis").SetValueAsync(GameManager.instance.UserItem[k].consis);
        */

        //마켓 데이터베이스상 디비 어케할건지?

        for (int i = k; i < GameManager.instance.marketMany - 1; i++)
        {
            GameManager.instance.MarketItems[i].key = GameManager.instance.MarketItems[i + 1].key;
            GameManager.instance.MarketItems[i].speed = GameManager.instance.MarketItems[i + 1].speed;
            GameManager.instance.MarketItems[i].accel = GameManager.instance.MarketItems[i + 1].accel;
            GameManager.instance.MarketItems[i].hp = GameManager.instance.MarketItems[i + 1].hp;
            GameManager.instance.MarketItems[i].agility = GameManager.instance.MarketItems[i + 1].agility;
            GameManager.instance.MarketItems[i].consis = GameManager.instance.MarketItems[i + 1].consis;
        }
        GameManager.instance.marketMany--;

        GameManager.instance.MarketItems[GameManager.instance.marketMany].key = -1;
        GameManager.instance.MarketItems[GameManager.instance.marketMany].speed = -1;
        GameManager.instance.MarketItems[GameManager.instance.marketMany].accel = -1;
        GameManager.instance.MarketItems[GameManager.instance.marketMany].hp = -1;
        GameManager.instance.MarketItems[GameManager.instance.marketMany].agility = -1;
        GameManager.instance.MarketItems[GameManager.instance.marketMany].consis = -1;

    }

    public void sendcheck_buy(string message)
    {
        GameObject error_p = GameObject.Find("check");
        Text error_m = GameObject.Find("check_m").GetComponent<Text>();

        error_m.text = message;
        iTween.MoveTo(error_p, iTween.Hash("y", 680, "delay", 0, "time", 0.5f));

    }
    public void click_buy_yes()
    {
        Get_item();
        GameObject error_p = GameObject.Find("check");
        iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 0.1f, "time", 0.5f));
    }

    public void click_buy_no()
    {
        GameObject error_p = GameObject.Find("check");
        iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 0.1f, "time", 0.5f));
    }
}
