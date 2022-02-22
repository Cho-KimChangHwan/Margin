using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndLog : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEnd ;
    public bool isCountEnd;
    public int myN;
    bool isinput;
    float timer;
    TextMeshProUGUI endText;
    TextMeshProUGUI record;
    TextMeshProUGUI ranking;
    RefereeSC referee;
    HorseStatus horsestatus;
    string rank;
    public int myRank;
    public int myGold;
    void Start()
    {
        isEnd = false;
        isCountEnd = false;
        isinput = false;
        timer = 0;
        rank = "";
        FindOb();
        FindPlayer();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(isEnd)
        {
            string T = ranking.text  + record.text +"\n";
            if ( timer < 10f )
            {
                timer += Time.deltaTime;
                
                if (timer <= 1f && timer > 0f)
                    endText.text = T + "10 초 후 종료" +"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다.";
                else if (timer <= 2f && timer > 1f)
                    endText.text = T +"9 초 후 종료" +"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다.";
                else if (timer <= 3f && timer > 2f)
                    endText.text = T +"8 초 후 종료" +"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다.";
                else if (timer <= 4f && timer > 3f)
                    endText.text = T +"7 초 후 종료"+"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다.";
                else if (timer <= 5f && timer > 4f)
                    endText.text = T +"6 초 후 종료"+"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다.";   
                else if (timer <= 6f && timer > 5f)
                    endText.text = T +"5 초 후 종료" +"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다."+ "\n" +"메인화면으로 돌아갑니다.";
                else if (timer <= 7f && timer > 6f)
                    endText.text = T +"4 초 후 종료"+"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다."+"\n" +"메인화면으로 돌아갑니다.";
                else if (timer <= 8f && timer > 7f)
                    endText.text = T +"3 초 후 종료"+"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다."+"\n" +"메인화면으로 돌아갑니다.";
                else if (timer <= 9f && timer > 8f)
                    endText.text = T +"2 초 후 종료"+"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다."+"\n" +"메인화면으로 돌아갑니다.";
                else if (timer <= 10f && timer > 9f)
                    endText.text = T +"1 초 후 종료"+"\n"+ myRank +"등을 하셔서 " +myGold +"G 를 획득하셨습니다."+"\n" +"메인화면으로 돌아갑니다.";

            }
            else if ( timer >= 10f ){
                isCountEnd = true;
            }

        }
        if(isCountEnd)
        {
            referee.serverDisconnect();
        }
    }
    void FindPlayer()
    {
        string myname = "Player" + (GameManager.instance.mytern ).ToString();
        horsestatus = GameObject.FindWithTag(myname).GetComponent<HorseStatus>();
    }
    void FindOb()
    {
         endText = GameObject.Find("EndText").GetComponent<TextMeshProUGUI>();
        record = GameObject.Find("Record").GetComponent<TextMeshProUGUI>();
        ranking = GameObject.Find("Ranking").GetComponent<TextMeshProUGUI>();
        referee = GameObject.Find("Referee").GetComponent<RefereeSC>();
    }
}
