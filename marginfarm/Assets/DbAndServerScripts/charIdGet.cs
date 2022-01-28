using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

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
        float pos = Random.Range(120.0f, 180.0f);
        PhotonNetwork.Instantiate("myHorse", new Vector3(pos, 9.4f, 77.0f), Quaternion.identity, 0);
    }
}
