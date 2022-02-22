using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveNum : MonoBehaviour
{
    public int print_select;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click_market_button()
    {
        GameManager.instance.market_select = print_select;
        Debug.Log(GameManager.instance.market_select);
    }
}
