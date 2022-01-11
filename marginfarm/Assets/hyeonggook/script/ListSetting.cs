using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListSetting : MonoBehaviour
{

    public Button button;
    public GameObject x1;
    public GameObject x2;

    public int check;
    public int con;

    // Start is called before the first frame update
    void Start()
    {
        check = GameManager.instance.many;

        for (con = 1; con <= 6; con++)
        {
            button = GameObject.Find("horse" + con.ToString()).GetComponent<Button>();
            GameObject x1 = GameObject.Find("onex" + con.ToString());
            GameObject x2 = GameObject.Find("twox" + con.ToString());

            if (check >= con)
            {
                button.interactable = true;
                x1.SetActive(false);
                x2.SetActive(false);
            }
            else
            {
                button.interactable = false;
                x1.SetActive(true);
                x2.SetActive(true);
            };

            //Debug.Log(GameManager.instance.UserHorse[con - 1].level);
        };
    
    }

    // Update is called once per frame

    
}
