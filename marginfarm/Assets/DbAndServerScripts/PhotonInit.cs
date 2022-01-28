using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    public string version = "v1.0";
    public Text show;
    int maxPlayer = 1;
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    void Start()
    {
        show = GameObject.Find("loadingText").GetComponent<Text>();   
    }
    public override void OnConnectedToMaster() //포톤 클라우드에 접속이 잘되면 호출되는 콜백함수
    {
        base.OnConnectedToMaster();
        Debug.Log("Entered Lobby");
        show.text = "서버 연결 중...";
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message) //방 입장이 실패했을 때
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log("No Room!!");
        show.text = "방이 없습니다 방을 생성하는 중...";
        PhotonNetwork.CreateRoom("MyRoom", new RoomOptions { MaxPlayers = 4 }); //방을 만들어줌 (최대 4명) 

    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Enter Room");
        show.text = "게임 대기 중...";
        if(PhotonNetwork.CurrentRoom.PlayerCount >= maxPlayer)
        {
            SceneManager.LoadScene("JunServerTest");
        }
    }
    
}
