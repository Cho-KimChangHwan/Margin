using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using UnityEngine.SceneManagement;

public class GameLoad : MonoBehaviour
{
    private WebSocket m_WebSocket;

    public Text innerText;
    // Start is called before the first frame update
    void Start()
    {
        m_WebSocket = new WebSocket("ws://172.30.1.51:3333"); //3333 this (4444 home)
        m_WebSocket.Connect();

        innerText = GameObject.Find("Text").GetComponent<Text>();

        m_WebSocket.Send($"id:{GameManager.instance.Id}");
        m_WebSocket.Send($"hd,{GameManager.instance.UserHorse[GameManager.instance.captain].speed}," +
            $"{GameManager.instance.UserHorse[GameManager.instance.captain].accel}," +
            $"{GameManager.instance.UserHorse[GameManager.instance.captain].hp}," +
            $"{GameManager.instance.UserHorse[GameManager.instance.captain].agility}," +
            $"{GameManager.instance.UserHorse[GameManager.instance.captain].consis}"
            );

        m_WebSocket.OnMessage += ws_OnMessage;
    }
    public void ws_OnMessage(object sender, MessageEventArgs e)
    {
        if (e.Data == "GameStart")
        {
            GameManager.instance.racingStart = true;
            SceneManager.LoadScene("RacingScene");
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
