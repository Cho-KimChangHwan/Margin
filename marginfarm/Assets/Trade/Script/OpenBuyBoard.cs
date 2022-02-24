using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBuyBoard : MonoBehaviour
{
    public GameObject SellBoard;
    public GameObject BuyBoard;

    public Button buy_item;
    // Start is called before the first frame update
    void Start()
    {

        //BuyBoard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void opener()
    {
        SellBoard.gameObject.SetActive(false);
        BuyBoard.gameObject.SetActive(true);
        Button buy_item = GameObject.Find("buy_item").GetComponent<Button>();
        buy_item.interactable = false;
        GameManager.instance.market_button_active = false;
    }
}
