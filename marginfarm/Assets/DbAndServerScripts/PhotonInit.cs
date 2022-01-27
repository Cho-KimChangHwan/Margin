using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    public string version = "v1.0";
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
    public override void OnConnectedToMaster() //포톤 클라우드에 접속이 잘되면 호출되는 콜백함수
    {
        base.OnConnectedToMaster();
        Debug.Log("Entered Lobby");
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message) //방 입장이 실패했을 때
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("No Room!!");
        PhotonNetwork.CreateRoom("MyRoom", new RoomOptions { MaxPlayers = 4 }); //방을 만들어줌 (최대 4명) 

    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Enter Room");
        CreateChar();
    }
    void CreateChar()
    {
        float pos = Random.Range(120.0f, 180.0f);
        PhotonNetwork.Instantiate("charac", new Vector3(pos, 9.4f, 77.0f), Quaternion.identity, 0);
    }
}
