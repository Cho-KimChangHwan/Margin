using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveNum : MonoBehaviour
{
    public int print_select;

    public Button buy_item;
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
        //Debug.Log(GameManager.instance.market_select);

        if(GameManager.instance.market_button_active == false)
        {
            Button buy_item = GameObject.Find("buy_item").GetComponent<Button>();
            buy_item.interactable = true;
            GameManager.instance.market_button_active = true;
        }
    }
}
