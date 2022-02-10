using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLog : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEnd ;
    public bool isCountEnd;
    public int myN;
    bool isinput;
    float timer;
    Text endText;
    Text record;
    Referee referee;
    HorseStatus horsestatus;
    string rank;
    void Start()
    {
        isEnd = false;
        isCountEnd = false;
        isinput = false;
        timer = 0;
        rank = "";
        endText = GameObject.Find("EndText").GetComponent<Text>();
        record = GameObject.Find("Record").GetComponent<Text>();
        referee = GameObject.Find("Referee").GetComponent<Referee>();
        horsestatus = GameObject.FindWithTag("Player").GetComponent<HorseStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnd)
        {
            if(isinput)
            {
                for(int i=0;i<referee.Final.Count;i++)
                {
                    if( myN == (int.Parse(referee.Final[i])) )
                    {
                        rank += (i+1).ToString() + " : Player"  +(int.Parse(referee.Final[i])+1).ToString() + "(me)" + "\n";
                    }
                    else
                    {
                        rank += (i+1).ToString() + " : Player"  +(int.Parse(referee.Final[i])+1).ToString() + "\n";
                    }
                }
                isinput = true;
            }
            string T = rank + "MyRecord :"  + record.text +"\n";
            if ( timer < 10f )
            {
                timer += Time.deltaTime;
                
                if (timer <= 1f && timer > 0f)
                    endText.text = T + "10 초 후 종료";
                else if (timer <= 2f && timer > 1f)
                    endText.text = T +"9 초 후 종료";
                else if (timer <= 3f && timer > 2f)
                    endText.text = T +"8 초 후 종료";
                else if (timer <= 4f && timer > 3f)
                    endText.text = T +"7 초 후 종료";
                else if (timer <= 5f && timer > 4f)
                    endText.text = T +"6 초 후 종료";    
                else if (timer <= 6f && timer > 5f)
                    endText.text = T +"5 초 후 종료";
                else if (timer <= 7f && timer > 6f)
                    endText.text = T +"4 초 후 종료";
                else if (timer <= 8f && timer > 7f)
                    endText.text = T +"3 초 후 종료";
                else if (timer <= 9f && timer > 8f)
                    endText.text = T +"2 초 후 종료";
                else if (timer <= 10f && timer > 9f)
                    endText.text = T +"1 초 후 종료";

            }
            else if ( timer >= 10f ){
                isCountEnd = true;
            }

        }
    }
}
