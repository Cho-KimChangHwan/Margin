using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class ItemScroll : MonoBehaviour
{
    DatabaseReference m_Reference;

    public bool isclick = false;
    public GameObject item;
    public GameObject content;
    //public GameObject noitem;
    public int yPos = 0;
    // Start is called before the first frame update
    
    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void isenrolled(){
        GameManager.instance.itemMany -= 1;
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("itemMany").SetValueAsync(GameManager.instance.itemMany);

        for (int m = 0; m < GameManager.instance.itemMany + 1; m++)
        {
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (m.ToString())).Child("key").SetValueAsync(GameManager.instance.UserItem[m].key);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (m.ToString())).Child("speed").SetValueAsync(GameManager.instance.UserItem[m].speed);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (m.ToString())).Child("accel").SetValueAsync(GameManager.instance.UserItem[m].accel);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (m.ToString())).Child("hp").SetValueAsync(GameManager.instance.UserItem[m].hp);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (m.ToString())).Child("agility").SetValueAsync(GameManager.instance.UserItem[m].agility);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("item" + (m.ToString())).Child("consis").SetValueAsync(GameManager.instance.UserItem[m].consis);
        }

        GameManager.instance.market_horse += 1;
        //noitem.gameObject.SetActive(false);
        var node = Instantiate(item,content.transform);
        node.transform.SetParent(GameObject.Find("content").transform);
        yPos -= 115;       
    }
}
