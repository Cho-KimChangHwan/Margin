using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndButton : MonoBehaviour
{
    // Start is called before the first frame update
    EndLog endLog;
    void Start()
    {
        endLog = GameObject.Find("EndText").GetComponent<EndLog>();
    }
    public void PushEnd()
    {
        endLog.isCountEnd = true;
    }
    // Update is called once per frame
}
