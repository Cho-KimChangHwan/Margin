using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

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
                GameManager.instance.UserHorse[0].level = Convert.ToInt32(snapshot.Child("HorseInfo").Child("level").Value);
                Debug.Log(GameManager.instance.UserHorse[0].level);
            });
    }
}
