using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class CFirebase : MonoBehaviour
{
    DatabaseReference m_Reference;

    public InputField logInput;
    public InputField passwordInput;
    public Image popup_error;

    public bool IsError = false;

    public string getId;
    public string getPassword;

    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference; //access

        logInput = GameObject.Find("Id").GetComponent<InputField>();
        passwordInput = GameObject.Find("Password").GetComponent<InputField>();
    }
    void Update()
    {
        getId = logInput.text;
        getPassword = passwordInput.text;

        if(IsError == true)
        {
            popup_error.gameObject.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                IsError = false;
            }
        }
        else
        {
            popup_error.gameObject.SetActive(false);
        }

        
    }

    public void ConfrmClick()
    {
        FirebaseDatabase.DefaultInstance.GetReference("users")
            .GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;

                    bool findId = snapshot.Child(getId).HasChildren;
                    object findPas = snapshot.Child(getId).Child("password").Value;

                    if (findId  == false) //create account
                    {
                        Debug.Log("NoId!!Creating...");
                        m_Reference.Child("users").Child(getId).Child("password").SetValueAsync(getPassword);
                        GameManager.instance.gameStart = true;
                        GameManager.instance.Id = getId;
                        SceneManager.LoadScene("mainmap");
                        //firstStartWite();
                    }
                    else if(findPas.ToString() != getPassword) //pass error
                    {                       
                        IsError = true;
                    }
                    else //login success
                    {
                        Debug.Log("Correct!!GameStart");
                        GameManager.instance.gameStart = true;
                        GameManager.instance.Id = getId;
                        SceneManager.LoadScene("mainmap");
                    }
                }
            });
    }

    public void firstStartWite()
    {
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("name").SetValueAsync("basicHorse");
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("key").SetValueAsync("2");
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("level").SetValueAsync("1");
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("speed").SetValueAsync("15");
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("accel").SetValueAsync("7");
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("hp").SetValueAsync("70");
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("agility").SetValueAsync("20");
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("consis").SetValueAsync("50");
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("item").SetValueAsync("0");
        m_Reference.Child("users").Child(getId).Child("HorseInfo").Child("alive").SetValueAsync("true");
    }
}