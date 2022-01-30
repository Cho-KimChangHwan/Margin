using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSellBoard : MonoBehaviour
{
    public GameObject SellBoard;
    public GameObject BuyBoard;

    // Start is called before the first frame update
    void Start()
    {
        SellBoard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void opener()
    {
        SellBoard.gameObject.SetActive(true);
        BuyBoard.gameObject.SetActive(false);
    }
}
