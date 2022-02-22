using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    // 4구간 나누고 , 4구간 안ㅔ서 좌표로 ㅏㅍ단 , 각으로 판단
    // Start is called before the first frame update
    GameObject[] horses ;
    GameObject[] minis;
    Text ranking;
    List<string> Final = new List<string>(); 
    Dictionary<int,string> horseRanking = new Dictionary<int,string>();
    public float rPoint1 = 30f , rPoint2 = -15f;
    void Start()
    {
        FindOb();
        InputInfo();
    }
    void FindOb()
    {
        ranking = GameObject.Find("Ranking").GetComponent<Text>();
        minis = GameObject.FindGameObjectsWithTag("Mini");
        horses = new GameObject[minis.Length];
        for(int i=0;i<minis.Length;i++)
            horses[i] = minis[i].transform.parent.gameObject;
    }
    void SetRanking()
    {
        List<int> First = new List<int>(); 
        List<int> Second = new List<int>(); 
        List<int> Third = new List<int>(); 
        List<int> Fourth = new List<int>();    


        for(int index =0;index <minis.Length;index++)
        {
            for(int j = 0 ; j < Final.Count; j++)
            {
                if(Final[j] == horses[index].name.ToString())
                    continue;
            }
            if(horses[index].GetComponent<HorseStatus>().horseLocation["First"])
            {
                First.Add(index);
            }
            else if(horses[index].GetComponent<HorseStatus>().horseLocation["Second"])
            {
                Second.Add(index);
            }
            else if(horses[index].GetComponent<HorseStatus>().horseLocation["Third"])
            {
                Third.Add(index);
            }
            else if(horses[index].GetComponent<HorseStatus>().horseLocation["Fourth"])
            {
                Fourth.Add(index);
            }
            else if(horses[index].GetComponent<HorseStatus>().horseLocation["Final"])
            {
                Final.Add(horses[index].name.ToString());
            }
        }
        int H=0;
        for(int i =Final.Count; i >0; i--)
            horseRanking[H++] = Final[i];
       
        for(int i =0; i <Fourth.Count; i++)
        {
            int max = i;
            for( int j = i+1; j<Fourth.Count;j++)
            {
                if( horses[(int)Fourth[max]].GetComponent<HorseStatus>().currentPosition.x <= horses[(int)Fourth[j]].GetComponent<HorseStatus>().currentPosition.x )
                {
                    max = j;
                }
            }
            horseRanking[H++] = horses[Fourth[max]].name.ToString();
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
                if( horses[(int)Third[min]].GetComponent<HorseStatus>().currentPosition.z >= horses[(int)Third[j]].GetComponent<HorseStatus>().currentPosition.z )
                {
                    min = j;
                }
            }
            horseRanking[H++] = horses[Third[min]].name.ToString();
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
                if( horses[(int)Second[min]].GetComponent<HorseStatus>().currentPosition.x >= horses[(int)Second[j]].GetComponent<HorseStatus>().currentPosition.x )
                {
                    min = j;
                }
            }
            horseRanking[H++] = horses[Second[min]].name.ToString();
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
                if( horses[(int)First[max]].GetComponent<HorseStatus>().currentPosition.z <= horses[(int)First[j]].GetComponent<HorseStatus>().currentPosition.z )
                {
                    max = j;
                }
            }
            horseRanking[H++] = horses[First[max]].name.ToString();
            int tmp;
            tmp = First[i];
            First[i] = First[max];
            First[max] = tmp;
          
        }
    
        //ranking.text = "1 : " + First[0]+"\n" +"\n" +"2 : " + First[1] +"\n" +"\n" + "3 : " + First[2] +"\n" +"\n" + "4 : " + First[3] +"\n";

         ranking.text = "1 : " + horseRanking[0]+"\n" +"\n" +"2 : " + horseRanking[1] +"\n" +"\n" + "3 : " + horseRanking[2] +"\n" +"\n" + "4 : " + horseRanking[3] +"\n";
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        SetRanking();
    }
    void InputInfo()
    {
        for(int i=0;i<minis.Length;i++)
            horseRanking.Add(i,horses[i].name.ToString() );
    }
}