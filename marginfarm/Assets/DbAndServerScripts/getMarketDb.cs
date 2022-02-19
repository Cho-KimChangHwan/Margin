using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class getMarketDb : MonoBehaviour
{
    DatabaseReference m_Reference;

    // Start is called before the first frame update
    void Start()
    {
        getData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void getData()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance.GetReference("users").Child(GameManager.instance.Id)
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                DataSnapshot snapshot = task.Result;
                //get first data
                
                //GameManager.instance.itemMany = Convert.ToInt32(snapshot.Child("itemMany").Value);
            });
    }
}
