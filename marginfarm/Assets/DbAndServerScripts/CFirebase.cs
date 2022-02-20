using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        if(logInput.isFocused != true && passwordInput.isFocused != true) {
            if(Input.GetKeyDown(KeyCode.Tab)) {
                logInput.Select();
            }
        }
 
        if(logInput.isFocused == true) {
            if(Input.GetKeyDown(KeyCode.Tab)) {
                passwordInput.Select();
            }
        }
 
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
                        firstStartWite();
                        GameManager.instance.gameStart = true;
                        GameManager.instance.Id = getId;
                       
                    }
                    else if(findPas.ToString() != getPassword) //pass error
                    {                       
                        IsError = true;
                    }
                    else //login success
                    {
                        GameManager.instance.gameStart = true;
                        GameManager.instance.Id = getId;
                    }
                }
            });
    }

    public void firstStartWite()
    {
        m_Reference.Child("users").Child(getId).Child("password").SetValueAsync(getPassword);
        m_Reference.Child("users").Child(getId).Child("money").SetValueAsync(GameManager.instance.money);
        m_Reference.Child("users").Child(getId).Child("captain").SetValueAsync(GameManager.instance.captain);
        m_Reference.Child("users").Child(getId).Child("many").SetValueAsync(GameManager.instance.many);
    }
}