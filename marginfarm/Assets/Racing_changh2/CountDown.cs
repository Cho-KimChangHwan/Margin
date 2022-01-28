using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    int timer;
    int startTimer ;
    Text count;
    public bool isStart = false;
    void Start()
    {
        isStart = false;
        timer = 0;
        startTimer = 0;
        count = GameObject.Find("Count").GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer == 0)
        {
            //Time.timeScale = 0.0f;
        }


        if ( timer < 180 )
        {
            timer ++;
            if (timer <= 60 && timer > 0)
                count.text = "3";
            else if (timer <= 120 && timer > 0)
                count.text = "2";
            else if (timer <= 180 && timer > 0)
                count.text = "1";
        }
        else if ( timer >= 180 ){
            count.text = "Start !";
            isStart = true;
            Time.timeScale = 1.0f;
        }

        if ( isStart )
        {
            startTimer ++;
            if ( startTimer >= 60 )
            {
                count.text = "";
            }

        }
    }
}
