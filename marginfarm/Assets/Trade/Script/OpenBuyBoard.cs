using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBuyBoard : MonoBehaviour
{
    public GameObject SellBoard;
    public GameObject BuyBoard;
    // Start is called before the first frame update
    void Start()
    {
        BuyBoard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void opener()
    {
        SellBoard.gameObject.SetActive(false);
        BuyBoard.gameObject.SetActive(true);
    }
}
