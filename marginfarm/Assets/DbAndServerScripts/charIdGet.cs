using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class charIdGet : MonoBehaviourPunCallbacks, IPunObservable
{
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        CreateChar();
        GameManager.instance.lineKey[GameManager.instance.mytern - 1] = GameManager.instance.UserHorse[GameManager.instance.captain].key;
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

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(GameManager.instance.mytern.ToString() + GameManager.instance.UserHorse[GameManager.instance.captain].key.ToString());
        }
        else
        {
            string gotMes = stream.ReceiveNext().ToString();          
            GameManager.instance.lineKey[Convert.ToInt32(gotMes.Substring(0, 1)) - 1] = Convert.ToInt32(gotMes.Substring(1));
            for (int i = 0; i < 4; i++)
            {
                Debug.Log($"말번호{i + 1}: {GameManager.instance.lineKey[i]}");
            }
        }
    }
}
