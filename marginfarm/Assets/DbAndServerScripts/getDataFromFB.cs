using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.SceneManagement;

public class getDataFromFB : MonoBehaviour
{
    DatabaseReference m_Reference;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStart == true)
        {
            getData();
            GameManager.instance.gameStart = false;
            SceneManager.LoadScene("mainmap");
        }
    }
    void getData()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance.GetReference("users").Child(GameManager.instance.Id)
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                DataSnapshot snapshot = task.Result;
                //get first data
                for (int i = 0; i < snapshot.Child("horses").ChildrenCount; i++)
                {
                    GameManager.instance.UserHorse[i].name = snapshot.Child("horses").Child(i.ToString()).Child("name").Value.ToString();
                    GameManager.instance.UserHorse[i].key = Convert.ToInt32(snapshot.Child("horses").Child(i.ToString()).Child("key").Value);
                    GameManager.instance.UserHorse[i].level = Convert.ToInt32(snapshot.Child("horses").Child(i.ToString()).Child("level").Value);
                    GameManager.instance.UserHorse[i].speed = Convert.ToInt32(snapshot.Child("horses").Child(i.ToString()).Child("speed").Value);
                    GameManager.instance.UserHorse[i].accel = Convert.ToInt32(snapshot.Child("horses").Child(i.ToString()).Child("accel").Value);
                    GameManager.instance.UserHorse[i].hp = Convert.ToInt32(snapshot.Child("horses").Child(i.ToString()).Child("hp").Value);
                    GameManager.instance.UserHorse[i].agility = Convert.ToInt32(snapshot.Child("horses").Child(i.ToString()).Child("agility").Value);
                    GameManager.instance.UserHorse[i].consis = Convert.ToInt32(snapshot.Child("horses").Child(i.ToString()).Child("consis").Value);
                    GameManager.instance.UserHorse[i].items = Convert.ToInt32(snapshot.Child("horses").Child(i.ToString()).Child("items").Value);
                }
                for (int i = 0; i < snapshot.Child("items").ChildrenCount; i++)
                {
                    GameManager.instance.UserItem[i].key = Convert.ToInt32(snapshot.Child("items").Child("item" + i.ToString()).Child("key").Value);
                    GameManager.instance.UserItem[i].speed = Convert.ToInt32(snapshot.Child("items").Child("item" + i.ToString()).Child("speed").Value);
                    GameManager.instance.UserItem[i].accel = Convert.ToInt32(snapshot.Child("items").Child("item" + i.ToString()).Child("accel").Value);
                    GameManager.instance.UserItem[i].hp = Convert.ToInt32(snapshot.Child("items").Child("item" + i.ToString()).Child("hp").Value);
                    GameManager.instance.UserItem[i].agility = Convert.ToInt32(snapshot.Child("items").Child("item" + i.ToString()).Child("agility").Value);
                    GameManager.instance.UserItem[i].consis = Convert.ToInt32(snapshot.Child("items").Child("item" + i.ToString()).Child("consis").Value);

                    for (int a = 0; a < snapshot.Child("items").Child("item" + (i.ToString())).Child("Block").Child("node").ChildrenCount; a++)
                    {
                        GameManager.instance.UserItem[i].genesishash.Add(snapshot.Child("items").Child("item" + i.ToString()).Child("Block").Child("node").Child("Hash" + a.ToString()).Value);
                        GameManager.instance.UserItem[i].savetran.Add(snapshot.Child("items").Child("item" + i.ToString()).Child("Block").Child("owner").Child("Tran" + a.ToString()).Value);
                    }       
                }
                for (int i = 0; i < 24; i++)
                {
                    GameManager.instance.WearingItem[i].item_key = Convert.ToInt32(snapshot.Child("WearingItem").Child(i.ToString()).Child("item_key").Value);
                    GameManager.instance.WearingItem[i].accel = Convert.ToInt32(snapshot.Child("WearingItem").Child(i.ToString()).Child("accel").Value);
                    GameManager.instance.WearingItem[i].agility = Convert.ToInt32(snapshot.Child("WearingItem").Child(i.ToString()).Child("agility").Value);
                    GameManager.instance.WearingItem[i].consis = Convert.ToInt32(snapshot.Child("WearingItem").Child(i.ToString()).Child("consis").Value);
                    GameManager.instance.WearingItem[i].hp = Convert.ToInt32(snapshot.Child("WearingItem").Child(i.ToString()).Child("hp").Value);
                    GameManager.instance.WearingItem[i].speed = Convert.ToInt32(snapshot.Child("WearingItem").Child(i.ToString()).Child("speed").Value);
                    for (int a = 0; a < snapshot.Child("WearingItem").Child(i.ToString()).Child("Block").Child("node").ChildrenCount; a++)
                    {
                        GameManager.instance.WearingItem[i].genesishash.Add(snapshot.Child("WearingItem").Child(i.ToString()).Child("Block").Child("node").Child("Hash" + a.ToString()).Value);
                        GameManager.instance.WearingItem[i].savetran.Add(snapshot.Child("WearingItem").Child(i.ToString()).Child("Block").Child("owner").Child("Tran" + a.ToString()).Value);
                    }
                }
                GameManager.instance.money = Convert.ToInt32(snapshot.Child("money").Value);
                GameManager.instance.captain = Convert.ToInt32(snapshot.Child("captain").Value);
                GameManager.instance.many = Convert.ToInt32(snapshot.Child("many").Value);
                GameManager.instance.itemMany = Convert.ToInt32(snapshot.Child("itemMany").Value);
            });
    }
}
