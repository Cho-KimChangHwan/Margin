using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    float startTimer ;
    Text count;
    public bool isStart = false;
    void Start()
    {
        isStart = false;
        timer = 0f;
        startTimer = 0f;
        count = GameObject.Find("Count").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == 0)
        {
            //Time.timeScale = 0.0f;
        }

        if ( timer < 3f )
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer <= 1f && timer > 0f)
                count.text = "3";
            else if (timer <= 2f && timer > 0f)
                count.text = "2";
            else if (timer <= 3f && timer > 0f)
            {
                count.text = "1";
            }
        }
        else if ( timer >= 3f ){
            count.text = "Start !";
            isStart = true;
            Time.timeScale = 1.0f;
        }

        if ( isStart )
        {
            startTimer += Time.deltaTime;
            if ( startTimer >= 1f )
            {
                count.text = "";
            }

        }
    }
}
