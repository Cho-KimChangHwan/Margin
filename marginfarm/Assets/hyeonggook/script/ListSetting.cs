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
    public int[] layer_num = { 0, 11, 10, 9, 8, 5, 4 };

    // Start is called before the first frame update
    void Start()
    {

        GameManager.instance.spec_check = false;
        GameManager.instance.inven_check = false;

        for (int i = 1; i <= GameManager.instance.many; i++) //말 그려주기 가지고 있는 말대로 피부 결정
        {
            GameObject horse = GameObject.Find("horse_o" + i.ToString());
            horse.SetActive(true);

            horseSkin = GameObject.Find("horse_s" + i.ToString()).GetComponent<SkinnedMeshRenderer>();
            horseSkin.material.SetTexture("_MainTex", h_Texture[GameManager.instance.UserHorse[i - 1].key]);

            if(GameManager.instance.WearingItem[(i - 1) * 4].item_key != 0)
            {
                GameObject under1 = GameObject.Find("hat_h" + i.ToString());
                GameObject temp1 = Instantiate(GameManager.instance.hat_item[GameManager.instance.WearingItem[(i - 1) * 4].item_key], under1.transform.position, Quaternion.Euler(new Vector3(38f, -97f, -6f)));
                temp1.transform.parent = under1.transform;
                temp1.layer = layer_num[i];
            }
            if (GameManager.instance.WearingItem[(i - 1) * 4 + 1].item_key != 0)
            {
                GameObject under2 = GameObject.Find("glasses_h" + i.ToString());
                GameObject temp2 = Instantiate(GameManager.instance.glasses_item[GameManager.instance.WearingItem[(i - 1) * 4 + 1].item_key / 10], under2.transform.position, Quaternion.Euler(new Vector3(20f, -87f, -1f)));
                temp2.transform.parent = under2.transform;
                temp2.layer = layer_num[i];
            }
            if(GameManager.instance.WearingItem[(i - 1) * 4 + 2].item_key != 0)
            {
                GameObject under3 = GameObject.Find("back_h" + i.ToString());
                GameObject temp3 = Instantiate(GameManager.instance.back_item[GameManager.instance.WearingItem[(i - 1) * 4 + 2].item_key / 100], under3.transform.position, Quaternion.Euler(new Vector3(-178f, -178f, 243f)));
                temp3.transform.parent = under3.transform;
                temp3.layer = layer_num[i];
            }
            if(GameManager.instance.WearingItem[(i - 1) * 4 + 3].item_key != 0)
            {
                GameObject under4 = GameObject.Find("shoes_h" + i.ToString());
                GameObject temp4 = Instantiate(GameManager.instance.shoes_item[GameManager.instance.WearingItem[(i - 1) * 4 + 3].item_key / 1000], under4.transform.position, Quaternion.Euler(new Vector3(-178f, -178f, 243f)));
                temp4.transform.parent = under4.transform;
                temp4.layer = layer_num[i];
            }
        }

        for (int i = 6; i > GameManager.instance.many; i--) //없는말의경우 비활성화
        {
            GameObject horse = GameObject.Find("horse_o" + i.ToString());
            horse.SetActive(false);
        }

        check = GameManager.instance.many;

        for (con = 1; con <= 6; con++)  //아래 말 선택버튼 세팅
        {
            button = GameObject.Find("horse" + con.ToString()).GetComponent<Button>();
            GameObject x1 = GameObject.Find("onex" + con.ToString());
            GameObject x2 = GameObject.Find("twox" + con.ToString());
            h_name = GameObject.Find("h_text" + con.ToString()).GetComponent<Text>();
            GameObject h_image = GameObject.Find("h_image" + con.ToString());

            if (check >= con)  //레벨에 따른 버튼 색 지정
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
