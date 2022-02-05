using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class Referee : MonoBehaviourPunCallbacks ,IPunObservable
{
    // Start is called before the first frame update
     // 4구간 나누고 , 4구간 안ㅔ서 좌표로 ㅏㅍ단 , 각으로 판단
    // Start is called before the first frame update
    GameObject[] horses ;
    HorseStatus horseStatus;
    Text ranking;
    public string[] horsesLocation = new string[2];
    public Vector3[] horsesPosition = new Vector3[2];
    public string myLocation = "First";
    List<string> Final = new List<string>(); 
    List<string> horseRanking = new List<string>();
    public float rPoint1 = 30f , rPoint2 = -15f;
    void Start()
    {
        ranking = GameObject.Find("Ranking").GetComponent<Text>();
        horseStatus = GameObject.FindWithTag("Player").GetComponent<HorseStatus>();
        myLocation = horseStatus.myLocation;
        
        horses = new GameObject[2];
        Debug.Log(GameManager.instance.mytern + "gt개수");
    }
    // public void OnPhotonSerializeView(PhotonStream stream , PhotonMessageInfo info) {
    //     if(stream.IsWriting)
    //     {
    //         stream.SendNext(horsesLocation);
    //         stream.SendNext(horsesPosition);
    //     }
    //     else{
    //         horsesLocation = (string[])stream.ReceiveNext();
    //         horsesPosition = (Vector3[])stream.ReceiveNext();
    //     }
    // }
    // Update is called once per frame
    
    void FixedUpdate()
    {
        myLocation = horseStatus.myLocation;
        if(photonView.IsMine)
        {

            photonView.RPC("HorsesSet",RpcTarget.AllBuffered, myLocation , horseStatus.currentPosition );


            Debug.Log("ㅍㅗ토ㅇ뷰");
            List<int> First = new List<int>(); 
            List<int> Second = new List<int>(); 
            List<int> Third = new List<int>(); 
            List<int> Fourth = new List<int>();

            //Debug.Log(minis.Length);
            for(int playerNum =0;playerNum < horsesLocation.Length;playerNum++)
            {
                if(Final.Contains(playerNum.ToString()))
                        continue;
                if(horsesLocation[playerNum] == "First")
                {
                    First.Add(playerNum);
                }
                else if(horsesLocation[playerNum] == "Second")
                {
                    Second.Add(playerNum);
                }
                else if(horsesLocation[playerNum] == "Third")
                {
                    Third.Add(playerNum);
                }
                else if(horsesLocation[playerNum] == "Fourth")
                {
                    Fourth.Add(playerNum);
                }
                else if(horsesLocation[playerNum] == "Final")
                {
                    Final.Add(playerNum.ToString());
                }
            }
            int H=0;
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
                    if( horsesPosition[Fourth[max]].x <= horsesPosition[Fourth[j]].x)
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
                    if( horsesPosition[Third[min]].z >= horsesPosition[Third[j]].z)
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
                    if( horsesPosition[Second[min]].x >= horsesPosition[Second[j]].x)
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
                    if( horsesPosition[First[max]].z <= horsesPosition[First[j]].z)
                        max = j;
                }
                horseRanking.Add(First[max].ToString());
                int tmp;
                tmp = First[i];
                First[i] = First[max];
                First[max] = tmp;
        
            }
            // ranking.text = "1 : " + First[0]+"\n" +"\n" +"2 : " + First[1] +"\n" +"\n" + "3 : " + First[2] +"\n" +"\n" + "4 : " + First[3] +"\n";
            string R = "";
            for (int i = horseRanking.Count-1;  i >=0 ; i--)
            {
                R += (i + 1).ToString() + " : Player" + (int.Parse(horseRanking[i])+1).ToString();
            }

            ranking.text = R;

            // ranking.text = "1 : " + horseRanking[0] ;
            horseRanking.Clear();
        }
    }
    [PunRPC]
    void HorsesSet(string myLocation,Vector3 currentPosition )
    {   
        horsesLocation[GameManager.instance.mytern-1] = myLocation;
        horsesPosition[GameManager.instance.mytern-1] = currentPosition;
    }
}
