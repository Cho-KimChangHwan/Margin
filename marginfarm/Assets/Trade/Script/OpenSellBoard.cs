using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSellBoard : MonoBehaviour
{
    public GameObject SellBoard;
    public GameObject BuyBoard;

    public Image item_i;
    public Button item_b;

    // Start is called before the first frame update
    void Start()
    {
        //SellBoard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void opener()
    {
        SellBoard.gameObject.SetActive(true);
        BuyBoard.gameObject.SetActive(false);
        inven_itemlist_make();
    }
    public void inven_itemlist_make()
    {
        for (int i = 1; i <= GameManager.instance.itemMany; i++)
        {
            Debug.Log("item" + i.ToString() + "_i");
            item_i = GameObject.Find("item" + i.ToString() + "_i").GetComponent<Image>();
            item_b = GameObject.Find("item" + i.ToString()).GetComponent<Button>();
            item_b.interactable = true;

            if (GameManager.instance.UserItem[i - 1].key < 10)
            {
                item_i.sprite = GameManager.instance.hat_item_card[GameManager.instance.UserItem[i - 1].key];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 100)
            {
                item_i.sprite = GameManager.instance.glasses_item_card[(GameManager.instance.UserItem[i - 1].key) / 10];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 1000)
            {
                item_i.sprite = GameManager.instance.back_item_card[(GameManager.instance.UserItem[i - 1].key) / 100];
            }
            else if (GameManager.instance.UserItem[i - 1].key < 10000)
            {
                item_i.sprite = GameManager.instance.shoes_item_card[(GameManager.instance.UserItem[i - 1].key) / 1000];
            }
        }
        for (int i = 12; i > GameManager.instance.itemMany; i--)
        {
            item_b = GameObject.Find("item" + i.ToString()).GetComponent<Button>();
            item_i = GameObject.Find("item" + i.ToString() + "_i").GetComponent<Image>();
            item_i.sprite = GameManager.instance.hat_item_card[0];
            item_b.interactable = false;
        }
    }
}
