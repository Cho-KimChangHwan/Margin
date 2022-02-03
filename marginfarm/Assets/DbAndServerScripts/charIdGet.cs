﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class charIdGet : MonoBehaviourPunCallbacks
{
    public object gotMes;
    public SkinnedMeshRenderer horseSkin;
    public GameObject thisHorse;
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
                thisHorse = GameObject.Find("myHorse(Clone)");
                horseSkin = thisHorse.GetComponentInChildren<SkinnedMeshRenderer>();
                horseSkin.material.SetTexture("_MainTex", GameManager.instance.hMats[GameManager.instance.lineKey[0]]);
                if (photonView.IsMine)
                    thisHorse.name = GameManager.instance.Id;              
                break;
            case 2:
                PhotonNetwork.Instantiate("myHorse", new Vector3(35.5f, 0f, -12.0f), Quaternion.Euler(new Vector3(0f, 180f, 0f)), 0);
                thisHorse = GameObject.Find("myHorse(Clone)");
                horseSkin = thisHorse.GetComponentInChildren<SkinnedMeshRenderer>();
                horseSkin.material.SetTexture("_MainTex", GameManager.instance.hMats[GameManager.instance.lineKey[1]]);
                if (photonView.IsMine)
                    thisHorse.name = GameManager.instance.Id;
                break;
            case 3:
                PhotonNetwork.Instantiate("myHorse", new Vector3(37.0f, 0f, -12.0f), Quaternion.Euler(new Vector3(0f, 180f, 0f)), 0);
                break;
            case 4:
                PhotonNetwork.Instantiate("myHorse", new Vector3(38.5f, 0f, -12.0f), Quaternion.Euler(new Vector3(0f, 180f, 0f)), 0);
                break;
        }
       
    }
    void Start()
    {
    }
    [PunRPC]
    void matSet(int myline, int matKey)
    {
        GameManager.instance.lineKey[myline] = matKey;
    }
    [PunRPC]
    void rpcName(string myHName)
    {
        thisHorse.name = myHName;
    }
}
