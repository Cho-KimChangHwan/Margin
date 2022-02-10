using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLog : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEnd ;
    public bool isCountEnd;
    float timer;
    Text endText;
    Text rank;
    Text record;
    HorseStatus horsestatus;
    void Start()
    {
        isEnd = false;
        isCountEnd = false;
        timer = 0;
        endText = GameObject.Find("EndText").GetComponent<Text>();
        rank = GameObject.Find("Ranking").GetComponent<Text>();
        record = GameObject.Find("Record").GetComponent<Text>();
        horsestatus = GameObject.FindWithTag("Player").GetComponent<HorseStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnd)
        {
            string T = rank.text +"\n" + "MyRecord :"  + record.text +"\n";
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
