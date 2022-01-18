using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListSetting : MonoBehaviour
{
    public GameObject horse;
    public SkinnedMeshRenderer horseSkin;

    public Texture[] h_Texture = new Texture[8];

    public Button button;
    public GameObject x1;
    public GameObject x2;
    public Text h_name;
    public GameObject h_image;

    public int check;
    public int con;

    // Start is called before the first frame update
    void Start()
    {

        GameManager.instance.spec_check = false;

        for (int i = 1; i <= GameManager.instance.many; i++)
        {
            GameObject horse = GameObject.Find("horse_o" + i.ToString());
            horse.SetActive(true);

            horseSkin = GameObject.Find("horse_s" + i.ToString()).GetComponent<SkinnedMeshRenderer>();
            horseSkin.material.SetTexture("_MainTex", h_Texture[GameManager.instance.UserHorse[i - 1].key]);
        }

        for (int i = 6; i > GameManager.instance.many; i--)
        {
            GameObject horse = GameObject.Find("horse_o" + i.ToString());
            horse.SetActive(false);
        }

        Debug.Log(GameManager.instance.many);
        check = GameManager.instance.many;

        for (con = 1; con <= 6; con++)
        {
            button = GameObject.Find("horse" + con.ToString()).GetComponent<Button>();
            GameObject x1 = GameObject.Find("onex" + con.ToString());
            GameObject x2 = GameObject.Find("twox" + con.ToString());
            h_name = GameObject.Find("h_text" + con.ToString()).GetComponent<Text>();
            GameObject h_image = GameObject.Find("h_image" + con.ToString());

            if (check >= con)
            {
                button.interactable = true;

                if (GameManager.instance.UserHorse[con - 1].level < 4)
                {
                    button.image.color = Color.yellow;
                }
                else if (GameManager.instance.UserHorse[con - 1].level < 7)
                {
                    button.image.color = Color.green;
                }
                else if (GameManager.instance.UserHorse[con - 1].level < 10)
                {
                    button.image.color = Color.blue;
                }
                else
                {
                    button.image.color = Color.red;
                }
                x1.SetActive(false);
                x2.SetActive(false);
                h_name.text = GameManager.instance.UserHorse[con-1].name;
                h_image.SetActive(true);
            }
            else
            {
                button.interactable = false;
                x1.SetActive(true);
                x2.SetActive(true);
                h_name.text = "";
                h_image.SetActive(false);
            };

            //Debug.Log(GameManager.instance.UserHorse[con - 1].level);
        };
    
    }

    // Update is called once per frame
}
