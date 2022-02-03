﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;


public class charIdGet : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        CreateChar();      
    }
    void CreateChar()
    {
        switch (GameManager.instance.mytern)
        {
            case 1:
                PhotonNetwork.Instantiate("myHorse", new Vector3(34.0f, 0f, -12.0f), Quaternion.Euler(new Vector3(0f, 180f, 0f)), 0);                
                break;
            case 2:
                PhotonNetwork.Instantiate("myHorse", new Vector3(35.5f, 0f, -12.0f), Quaternion.Euler(new Vector3(0f, 180f, 0f)), 0);
                break;
            case 3:
                PhotonNetwork.Instantiate("myHorse", new Vector3(37.0f, 0f, -12.0f), Quaternion.Euler(new Vector3(0f, 180f, 0f)), 0);
                break;
            case 4:
                PhotonNetwork.Instantiate("myHorse", new Vector3(38.5f, 0f, -12.0f), Quaternion.Euler(new Vector3(0f, 180f, 0f)), 0);
                break;
        }       
    }
    [PunRPC]
    void rpcName(string myHName)
    {
        gameObject.name = myHName;
    }
}
