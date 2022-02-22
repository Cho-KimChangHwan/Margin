using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartLineSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    HorseStatus horseStatus;
    TextMeshProUGUI ranking;
    void Start()
    {
        string myname = "Player" + (GameManager.instance.mytern ).ToString();
        ranking = GameObject.Find("Ranking").GetComponent<TextMeshProUGUI>();
        horseStatus = GameObject.FindWithTag(myname).GetComponent<HorseStatus>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(horseStatus.horseLocation["Third"])
        {
            Destroy(this);
        }

    }
}
