using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class Referee : MonoBehaviourPunCallbacks , IPunObservable
{
    // Start is called before the first frame update
     // 4구간 나누고 , 4구간 안ㅔ서 좌표로 ㅏㅍ단 , 각으로 판단
    // Start is called before the first frame update
    GameObject[] horses ;
    HorseStatus horseStatus;
    Text ranking;
    bool isR = false;
    bool everyReady = false; 
    string R;
    public string myLocation = "First";
    public List<string> Final = new List<string>(); 
    List<string> horseRanking = new List<string>();
    CountDown countDown;
    EndLog endLog;
    public float rPoint1 = 30f , rPoint2 = -15f;
    string[] rankColor = { "<color=#0054FF>" , "<color=#191919>" ,"<color=#1DDB16>","<color=#FF0000>"};

    void Start()
    {
        ranking = GameObject.Find("Ranking").GetComponent<Text>();
        horseStatus = GameObject.FindWithTag("Player").GetComponent<HorseStatus>();
        countDown = GameObject.Find("Canvas").GetComponent<CountDown>();
        myLocation = horseStatus.myLocation;
        endLog = GameObject.Find("EndText").GetComponent<EndLog>();
        horses = new GameObject[3];

    }

    
    void FixedUpdate()
    {
        
        if(!everyReady) 
        {
            GameManager.instance.horsesReady[GameManager.instance.mytern-1] = true;
            photonView.RPC("ReadySet", RpcTarget.AllBuffered, GameManager.instance.mytern-1 ,true);   
            bool tmpReady = true;
            for(int i=0; i < GameManager.instance.horsesReady.Length ; i++)
            {  
                if( !GameManager.instance.horsesReady[i] )
                    tmpReady = false;

            }
            if(tmpReady)
            {
                everyReady = true;
                countDown.isReady = true;
            }
        }

        myLocation = horseStatus.myLocation;
        if ((GameManager.instance.mytern - 1)!=0)
        {

            //photonView.RPC("HorsesSet",RpcTarget.AllBuffered, myLocation , horseStatus.currentPosition );
            GameManager.instance.horsesLocation[GameManager.instance.mytern-1] = myLocation;
            GameManager.instance.horsesPosition[GameManager.instance.mytern-1] = horseStatus.currentPosition;
            List<int> First = new List<int>(); 
            List<int> Second = new List<int>(); 
            List<int> Third = new List<int>(); 
            List<int> Fourth = new List<int>();

            for(int playerNum =0;playerNum < GameManager.instance.horsesLocation.Length;playerNum++)
            {
                if(Final.Contains(playerNum.ToString()))
                        continue;
                if(GameManager.instance.horsesLocation[playerNum] == "First")
                {
                    First.Add(playerNum);
                }
                else if(GameManager.instance.horsesLocation[playerNum] == "Second")
                {
                    Second.Add(playerNum);
                }
                else if(GameManager.instance.horsesLocation[playerNum] == "Third")
                {
                    Third.Add(playerNum);
                }
                else if(GameManager.instance.horsesLocation[playerNum] == "Fourth")
                {
                    Fourth.Add(playerNum);
                }
                else if(GameManager.instance.horsesLocation[playerNum] == "Final")
                {
                    Final.Add(playerNum.ToString());
                }
            }
            for(int i =0; i < Final.Count ; i++)
            {
                if(horseRanking.Contains(Final[i]))
                    continue;

                horseRanking.Add(Final[i]);
            }
            for(int i =0; i <Fourth.Count; i++)
            {
                int max = i;
                for( int j = i+1; j<Fourth.Count;j++)
                {
                    if( GameManager.instance.horsesPosition[Fourth[max]].x <= GameManager.instance.horsesPosition[Fourth[j]].x)
                        max = j;
                }
                horseRanking.Add(Fourth[max].ToString());
                int tmp;
                tmp = Fourth[i];
                Fourth[i] = Fourth[max];
                Fourth[max] = tmp;
        
            }
            for(int i =0; i <Third.Count; i++)
            {
                int min = i;
                for( int j = i+1; j<Third.Count;j++)
                {
                    if( GameManager.instance.horsesPosition[Third[min]].z >= GameManager.instance.horsesPosition[Third[j]].z)
                        min = j;
                }
                horseRanking.Add(Third[min].ToString());
                int tmp;
                tmp = Third[i];
                Third[i] = Third[min];
                Third[min] = tmp;
                
            }
            for(int i =0; i <Second.Count; i++)
            {
                int min = i;
                for( int j = i+1; j<Second.Count;j++)
                {
                    if( GameManager.instance.horsesPosition[Second[min]].x >= GameManager.instance.horsesPosition[Second[j]].x)
                        min = j;
                }
                horseRanking.Add(Second[min].ToString());
                int tmp;
                tmp = Second[i];
                Second[i] = Second[min];
                Second[min] = tmp;
                
            }
            for(int i =0; i <First.Count; i++)
            {
                int max = i;
                for( int j = i+1; j<First.Count;j++)
                {
                    if( GameManager.instance.horsesPosition[First[max]].z <= GameManager.instance.horsesPosition[First[j]].z)
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
            // for (int i = horseRanking.Count-1;  i >=0 ; i--)
            // {
            //     R += (rank++).ToString() + " : Player"  +(int.Parse(horseRanking[i])+1).ToString() + "\n";
            // }
            for (int i = 0;  i < horseRanking.Count ; i++)
            {
                R +=  rankColor[i] +(rank++).ToString() + " : Player"  +(int.Parse(horseRanking[i])+1).ToString() +"</color> " +"\n";
            }
            photonView.RPC("RankingSet", RpcTarget.AllBuffered,R);
        }
        if( (Final.Count == horseRanking.Count) && horseStatus.horseLocation["Final"])
        {
            endLog.myN = GameManager.instance.mytern-1;
            endLog.isEnd = true;
        }
        Debug.Log(GameManager.instance.horseLocation[2]);
        horseRanking.Clear();
    }
    public void serverDisconnect() 
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("aftermain");
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
            GameManager.instance.horsesLocation[index] = (string)stream.ReceiveNext();
            GameManager.instance.horsesPosition[index] = (Vector3)stream.ReceiveNext();
            ranking.text = (string)stream.ReceiveNext();
        }
    }
    [PunRPC]
    void RankingSet(string r)
    {
        GameManager.instance.ranking = r;
        ranking.text = GameManager.instance.ranking;
    }
    [PunRPC]
    void ReadySet(int pNum , bool ready)
    {
        GameManager.instance.horsesReady[pNum] = ready;
    }
    // [PunRPC]
    // void HorsesSet(string myLocation,Vector3 currentPosition )
    // {   

    //     GameManager.instance.horsesLocation[GameManager.instance.mytern-1] = myLocation;
    //     GameManager.instance.horsesPosition[GameManager.instance.myftern-1] = currentPosition;
    // }
}