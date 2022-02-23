using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class PhotonInit : MonoBehaviourPunCallbacks
{
    public string version = "v1.0";
    public TextMeshProUGUI show;
    bool isGameStart = false;
    bool getReady = false;
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    void Start()
    {
        show = GameObject.Find("loadingText").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (getReady == true && PhotonNetwork.CurrentRoom.PlayerCount >=4  && isGameStart == false) //3명일 때
        {
            StartCoroutine(this.LoadRacing());
            PhotonNetwork.CurrentRoom.IsOpen = false;
            isGameStart = true;
        }
    }
    public override void OnConnectedToMaster() //포톤 클라우드에 접속이 잘되면 호출되는 콜백함수
    {
        base.OnConnectedToMaster();
        show.text = "서버 연결 중...";
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message) //방 입장이 실패했을 때
    {
        base.OnJoinRandomFailed(returnCode, message);
        show.text = "방이 없습니다 방을 생성하는 중...";
        PhotonNetwork.CreateRoom("MyRoom", new RoomOptions { MaxPlayers = 4 }); //방을 만들어줌 (최대 4명) 
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        show.text = "게임 대기 중...";
        GameManager.instance.mytern = PhotonNetwork.CurrentRoom.PlayerCount;
        getReady = true;
    }
    IEnumerator LoadRacing()
    {
        PhotonNetwork.IsMessageQueueRunning = false;  //씬을 이동하는 동안 포톤 클라우드 서버로부터 네트워크 메시지 수신 중단  
        AsyncOperation ao = Application.LoadLevelAsync("RacingScene"); //백그라운드로 씬 로딩
        yield return ao;
    }
}
