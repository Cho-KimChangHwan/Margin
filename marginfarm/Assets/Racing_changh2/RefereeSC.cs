using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;


public class RefereeSC : MonoBehaviourPunCallbacks , IPunObservable
{
    DatabaseReference m_Reference;

    // Start is called before the first frame update
     // 4구간 나누고 , 4구간 안ㅔ서 좌표로 ㅏㅍ단 , 각으로 판단
    // Start is called before the first frame update
    GameObject[] horses ;
    HorseStatus horseStatus;
    TextMeshProUGUI ranking;
    bool isR = false;
    bool everyReady = false; 
    string R;
    public string myLocation = "First";
    int tmpindex;
    public string tmpLocation;
    public Vector3 tmpVector;
    public List<string> Final = new List<string>(); 
    List<string> horseRanking = new List<string>();
    CountDown countDown;
    GameObject end;
    EndLog endLog;
    public float rPoint1 = 30f , rPoint2 = -15f;
    public int myRank;
    bool isPay = false;
    string[] rankColor = { "<color=#0054FF>" ,"<color=#1DDB16>", "<color=#191919>" ,"<color=#FF0000>"};

    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;

        string myname = "Player" + (GameManager.instance.mytern ).ToString();
        endLog = GameObject.Find("EndText").GetComponent<EndLog>();
        end = GameObject.Find("End");
        end.SetActive(false);

        ranking = GameObject.Find("Ranking").GetComponent<TextMeshProUGUI>();
        horseStatus = GameObject.FindWithTag(myname).GetComponent<HorseStatus>();
        countDown = GameObject.Find("Canvas").GetComponent<CountDown>();
        myLocation = horseStatus.myLocation;
    }

    
    void Update()
    {
        if (!everyReady)
        {
            GameManager.instance.hReady[GameManager.instance.mytern - 1] = true;
            photonView.RPC("ReadySet", RpcTarget.AllBuffered, GameManager.instance.mytern - 1);

            bool tmpReady = true;
            for (int i = 0; i < GameManager.instance.hReady.Length; i++)
            {
                if (!GameManager.instance.hReady[i])
                {
                    tmpReady = false;
                }
            }
            if (tmpReady)
            {
                everyReady = true;
                countDown.isReady = true;
            }
        }
        else
        {
            {
                
                photonView.RPC("LocationSet", RpcTarget.AllBuffered, horseStatus.myLocation, horseStatus.currentPosition, GameManager.instance.mytern - 1);
                List<int> First = new List<int>();
                List<int> Second = new List<int>();
                List<int> Third = new List<int>();
                List<int> Fourth = new List<int>();

                for (int playerNum = 0; playerNum < GameManager.instance.hLocation.Length; playerNum++)
                {
                    if (Final.Contains(playerNum.ToString()))
                        continue;
                    if (GameManager.instance.hLocation[playerNum] == "First")
                    {
                        First.Add(playerNum);
                    }
                    else if (GameManager.instance.hLocation[playerNum] == "Second")
                    {
                        Second.Add(playerNum);
                    }
                    else if (GameManager.instance.hLocation[playerNum] == "Third")
                    {
                        Third.Add(playerNum);
                    }
                    else if (GameManager.instance.hLocation[playerNum] == "Fourth")
                    {
                        Fourth.Add(playerNum);
                    }
                    else if (GameManager.instance.hLocation[playerNum] == "Final")
                    {
                        Final.Add(playerNum.ToString());
                    }
                }
                for (int i = 0; i < Final.Count; i++)
                {
                    if (horseRanking.Contains(Final[i]))
                        continue;

                    horseRanking.Add(Final[i]);
                }
                for (int i = 0; i < Fourth.Count; i++)
                {
                    int max = i;
                    for (int j = i + 1; j < Fourth.Count; j++)
                    {
                        if (GameManager.instance.hPosition[Fourth[max]].x <= GameManager.instance.hPosition[Fourth[j]].x)
                            max = j;
                    }
                    horseRanking.Add(Fourth[max].ToString());
                    int tmp;
                    tmp = Fourth[i];
                    Fourth[i] = Fourth[max];
                    Fourth[max] = tmp;
                }
                for (int i = 0; i < Third.Count; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < Third.Count; j++)
                    {
                        if (GameManager.instance.hPosition[Third[min]].z >= GameManager.instance.hPosition[Third[j]].z)
                            min = j;
                    }
                    horseRanking.Add(Third[min].ToString());
                    int tmp;
                    tmp = Third[i];
                    Third[i] = Third[min];
                    Third[min] = tmp;
                }
                for (int i = 0; i < Second.Count; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < Second.Count; j++)
                    {
                        if (GameManager.instance.hPosition[Second[min]].x >= GameManager.instance.hPosition[Second[j]].x)
                            min = j;
                    }
                    horseRanking.Add(Second[min].ToString());
                    int tmp;
                    tmp = Second[i];
                    Second[i] = Second[min];
                    Second[min] = tmp;
                }
                for (int i = 0; i < First.Count; i++)
                {
                    int max = i;
                    for (int j = i + 1; j < First.Count; j++)
                    {
                        if (GameManager.instance.hPosition[First[max]].z <= GameManager.instance.hPosition[First[j]].z)
                            max = j;
                    }
                    horseRanking.Add(First[max].ToString());
                    int tmp;
                    tmp = First[i];
                    First[i] = First[max];
                    First[max] = tmp;
                }
                R = "";
                int rank = 1;
                for (int i = 0; i < horseRanking.Count; i++)
                {
                    R += rankColor[int.Parse(horseRanking[i])] + (rank++).ToString() + " : Player" + (int.Parse(horseRanking[i]) + 1).ToString() + "</color> " + "\n";
                    if((GameManager.instance.mytern-1) == int.Parse(horseRanking[i])) myRank=rank-1;
                }
               photonView.RPC("RankingSet", RpcTarget.AllBuffered, R);
            }
            if ((Final.Count == horseRanking.Count) && horseStatus.horseLocation["Final"])
            {
                end.SetActive(true);
                endLog.myN = GameManager.instance.mytern - 1;
                endLog.myRank = myRank;
                endLog.isEnd = true;
                
                if( !isPay){
                    if(myRank == 4)
                    {
                        endLog.myGold = 1;
                        GameManager.instance.money += endLog.myGold;
                    }
                    else if(myRank == 3)
                    {
                        endLog.myGold = 300;
                        GameManager.instance.money += endLog.myGold;
                    }
                    else if(myRank == 2)
                    {
                        endLog.myGold = 500;
                        GameManager.instance.money += endLog.myGold;
                    }
                    else if(myRank == 1)
                    {
                        endLog.myGold = 1000;
                        GameManager.instance.money += endLog.myGold;
                    }
                    isPay = true;
                    m_Reference.Child("users").Child(GameManager.instance.Id).Child("money").SetValueAsync(GameManager.instance.money);
                }
            }
            horseRanking.Clear();
        }
    }
     
   public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if(stream.IsWriting)
        {
            stream.SendNext(GameManager.instance.mytern-1);
            stream.SendNext(myLocation);
            stream.SendNext(horseStatus.currentPosition);
            stream.SendNext(R);
        }
        else{
            int index = (int)stream.ReceiveNext();
            GameManager.instance.hLocation[index] = (string)stream.ReceiveNext();
            GameManager.instance.hPosition[index] = (Vector3)stream.ReceiveNext();
            ranking.text = (string)stream.ReceiveNext();
            GameManager.instance.hReady[index] = true;
        }
    }
    public void serverDisconnect()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("aftermain");
    }
    [PunRPC]
    void RankingSet(string r)
    {
        GameManager.instance.ranking = r;
        ranking.text = GameManager.instance.ranking;
    }
    [PunRPC]
    void ReadySet(int pNum )
    {
        GameManager.instance.hReady[pNum] = true; 
    }
    [PunRPC]
     void LocationSet(string myLocation,Vector3 currentPosition, int pNum)
     {
         GameManager.instance.hLocation[pNum] = myLocation;
         GameManager.instance.hPosition[pNum] = currentPosition;
     }
}