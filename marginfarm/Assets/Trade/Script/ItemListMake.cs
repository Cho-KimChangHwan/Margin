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

    public int[] itemdata = new int[5];
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
         for (int i = 0; i < GameManager.instance.marketMany; i++)
         {
            GameObject temp = Instantiate(item_button, content.transform);
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
}
