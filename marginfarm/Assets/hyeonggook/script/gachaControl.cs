using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Blockchain;

public class gachaControl : MonoBehaviour
{
    DatabaseReference m_Reference;

    public GameObject zero;
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public InputField newname;
    public GameObject item_first;
    public GameObject item_second;

    public SkinnedMeshRenderer horse1;
    public SkinnedMeshRenderer horse2;
    public SkinnedMeshRenderer horse3;
    public SkinnedMeshRenderer horse_s;

    public Texture[] h_Texture = new Texture[8];

    public int classnum;
    public int selectnum;

    public Image bar;
    public Text gauge;
    public Image obj_card_i;

    public int[,] horse_spec_t = new int[5, 3];
    public int[] horse_style = new int[3];
    public int[] item_spec = new int[5];

    public float x, y, z;

    public GameObject cardback1;
    public bool cardback1_c;
    public int timer1;
    public GameObject card1;
    public GameObject cardback2;
    public bool cardback2_c;
    public int timer2;
    public GameObject card2;
    public GameObject cardback3;
    public bool cardback3_c;
    public int timer3;
    public GameObject card3;
    public int itemselect;

    public GameObject obj_card;
    public GameObject spec_card;
    public GameObject cardback_o;
    public GameObject cardback_s;
    public bool cardback_ob;
    public bool cardback_sb;
    public int timero;
    public int timers;
    public Button go_item;

    public GameObject fadeImg;
    public Text money_t;
    public int usedmoney;

    public Button horsebuttonactive1;
    public Button horsebuttonactive2;
    public Button horsebuttonactive3;
    public Button homebotton;

    public Button itembuttonactive1;
    public Button itembuttonactive2;
    public Button itembuttonactive3;
    public Button itembuttonactive4;
    /*
    public int[] speed_t = new int[3]; 0번인덱스
    public int[] accel_t = new int[3]; 1번인덱스
    public int[] hp_t = new int[3]; 
    public int[] agility_t = new int[3];
    public int[] consis_t = new int[3];
    */

    void Start()
    {
        m_Reference = FirebaseDatabase.DefaultInstance.RootReference;
        StartCoroutine("FadeInStart");

        Text money_t = GameObject.Find("money_t").GetComponent<Text>();
        money_t.text = GameManager.instance.money.ToString();
    }

    public void horse_gacha()
    {
        if(GameManager.instance.many == 6)
        {
            senderror("농장이 꽉찼습니다.");
        }
        else
        {
            GameObject zero = GameObject.Find("zero");
            GameObject first = GameObject.Find("first");

            iTween.MoveTo(zero, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
            iTween.MoveTo(first, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
        }
    }
    public void item_gacha()
    {
        if (GameManager.instance.itemMany == 12)
        {
            senderror("아이템 보관함이 꽉찼습니다.");
        }
        else
        {
            GameObject zero = GameObject.Find("zero");
            GameObject item_first = GameObject.Find("item_first");

            iTween.MoveTo(zero, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
            iTween.MoveTo(item_first, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
        }
    }
    public void horse_back()
    {
        GameObject zero = GameObject.Find("zero");
        GameObject first = GameObject.Find("first");

        iTween.MoveTo(zero, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(first, iTween.Hash("y", -380, "delay", 0.1f, "time", 0.5f));
    }

    public void item_back()
    {
        GameObject zero = GameObject.Find("zero");
        GameObject item_first = GameObject.Find("item_first");

        iTween.MoveTo(zero, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(item_first, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
    }

    public void item_after_back()
    {
        GameObject zero = GameObject.Find("item_second");
        GameObject item_first = GameObject.Find("item_first");

        iTween.MoveTo(zero, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(item_first, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
    }
    public void hat_click()
    {
        if (GameManager.instance.money >= 300)
        {
            sendcheck_i("300골드로 뽑으시겠습니까?");
            usedmoney = 300;
            itemselect = 1;

            itembuttonactive1 = GameObject.Find("hat").GetComponent<Button>();
            itembuttonactive1.interactable = false;
            itembuttonactive2 = GameObject.Find("glasses").GetComponent<Button>();
            itembuttonactive2.interactable = false;
            itembuttonactive3 = GameObject.Find("back").GetComponent<Button>();
            itembuttonactive3.interactable = false;
            itembuttonactive4 = GameObject.Find("shoes").GetComponent<Button>();
            itembuttonactive4.interactable = false;
        }
        else
        {
            senderror("골드가 부족합니다.");
        }
 
    }

    public void glasses_click()
    {
        if (GameManager.instance.money >= 300)
        {
            sendcheck_i("300골드로 뽑으시겠습니까?");
            usedmoney = 300;
            itemselect = 2;

            itembuttonactive1 = GameObject.Find("hat").GetComponent<Button>();
            itembuttonactive1.interactable = false;
            itembuttonactive2 = GameObject.Find("glasses").GetComponent<Button>();
            itembuttonactive2.interactable = false;
            itembuttonactive3 = GameObject.Find("back").GetComponent<Button>();
            itembuttonactive3.interactable = false;
            itembuttonactive4 = GameObject.Find("shoes").GetComponent<Button>();
            itembuttonactive4.interactable = false;
        }
        else
        {
            senderror("골드가 부족합니다.");
        }
    }

    public void back_click()
    {
        if (GameManager.instance.money >= 300)
        {
            sendcheck_i("300골드로 뽑으시겠습니까?");
            usedmoney = 300;
            itemselect = 3;

            itembuttonactive1 = GameObject.Find("hat").GetComponent<Button>();
            itembuttonactive1.interactable = false;
            itembuttonactive2 = GameObject.Find("glasses").GetComponent<Button>();
            itembuttonactive2.interactable = false;
            itembuttonactive3 = GameObject.Find("back").GetComponent<Button>();
            itembuttonactive3.interactable = false;
            itembuttonactive4 = GameObject.Find("shoes").GetComponent<Button>();
            itembuttonactive4.interactable = false;
        }
        else
        {
            senderror("골드가 부족합니다.");
        }
    }
    public void shoes_click()
    {
        if (GameManager.instance.money >= 300)
        {
            sendcheck_i("300골드로 뽑으시겠습니까?");
            usedmoney = 300;
            itemselect = 4;

            itembuttonactive1 = GameObject.Find("hat").GetComponent<Button>();
            itembuttonactive1.interactable = false;
            itembuttonactive2 = GameObject.Find("glasses").GetComponent<Button>();
            itembuttonactive2.interactable = false;
            itembuttonactive3 = GameObject.Find("back").GetComponent<Button>();
            itembuttonactive3.interactable = false;
            itembuttonactive4 = GameObject.Find("shoes").GetComponent<Button>();
            itembuttonactive4.interactable = false;
        }
        else
        {
            senderror("골드가 부족합니다.");
        }
    }

    public void gacha_b1_click()
    {
        if(GameManager.instance.money >= 500)
        {
            sendcheck("500골드로 뽑으시겠습니까?");
            usedmoney = 500;
            classnum = 1;
            horsebuttonactive1 = GameObject.Find("level1").GetComponent<Button>();
            horsebuttonactive1.interactable = false;
            horsebuttonactive2 = GameObject.Find("level2").GetComponent<Button>();
            horsebuttonactive2.interactable = false;
            horsebuttonactive3 = GameObject.Find("level3").GetComponent<Button>();
            horsebuttonactive3.interactable = false;
        }
        else
        {
            senderror("골드가 부족합니다.");
        }  
    }
    public void gacha_b2_click()
    {
        if (GameManager.instance.money >= 1000)
        {
            sendcheck("1000골드로 뽑으시겠습니까?");
            usedmoney = 1000;
            classnum = 2;
            horsebuttonactive1 = GameObject.Find("level1").GetComponent<Button>();
            horsebuttonactive1.interactable = false;
            horsebuttonactive2 = GameObject.Find("level2").GetComponent<Button>();
            horsebuttonactive2.interactable = false;
            horsebuttonactive3 = GameObject.Find("level3").GetComponent<Button>();
            horsebuttonactive3.interactable = false;
        }
        else
        {
            senderror("골드가 부족합니다.");
        }
    }
    public void gacha_b3_click()
    {
        if (GameManager.instance.money >= 3000)
        {
            sendcheck("3000골드로 뽑으시겠습니까?");
            usedmoney = 3000;
            classnum = 3;
            horsebuttonactive1 = GameObject.Find("level1").GetComponent<Button>();
            horsebuttonactive1.interactable = false;
            horsebuttonactive2 = GameObject.Find("level2").GetComponent<Button>();
            horsebuttonactive2.interactable = false;
            horsebuttonactive3 = GameObject.Find("level3").GetComponent<Button>();
            horsebuttonactive3.interactable = false;
        }
        else
        {
            senderror("골드가 부족합니다.");
        }
    }

    public void horse_b1_click()
    {
        //세번째 창 값 설정
        horse_s = GameObject.Find("horse_card4").GetComponent<SkinnedMeshRenderer>();
        horse_s.material.SetTexture("_MainTex", h_Texture[horse_style[0]]);

        for (int n = 1; n < 6; n++)
        {
            bar = GameObject.Find("gauge" + n.ToString()).GetComponent<Image>();
            bar.fillAmount = horse_spec_t[n - 1, 0] / 100f;
            gauge = GameObject.Find("gauge_t" + n.ToString()).GetComponent<Text>();
            gauge.text = horse_spec_t[n - 1, 0].ToString() + "/ 100";
        }

        selectnum = 0;

        //창 변경
        
        GameObject second = GameObject.Find("second");
        GameObject third = GameObject.Find("third");
     
        iTween.MoveTo(second, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(third, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
    }

    public void horse_b2_click()
    {
        //세번째 창 값 설정
        horse_s = GameObject.Find("horse_card4").GetComponent<SkinnedMeshRenderer>();
        horse_s.material.SetTexture("_MainTex", h_Texture[horse_style[1]]);

        for (int n = 1; n < 6; n++)
        {
            bar = GameObject.Find("gauge" + n.ToString()).GetComponent<Image>();
            bar.fillAmount = horse_spec_t[n - 1, 1] / 100f;
            gauge = GameObject.Find("gauge_t" + n.ToString()).GetComponent<Text>();
            gauge.text = horse_spec_t[n - 1, 1].ToString() + "/ 100";
        }

        selectnum = 1;

        //창 변경
        GameObject second = GameObject.Find("second");
        GameObject third = GameObject.Find("third");
     
        iTween.MoveTo(second, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(third, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
    }

    public void horse_b3_click()
    {
        //세번째 창 값 설정
        horse_s = GameObject.Find("horse_card4").GetComponent<SkinnedMeshRenderer>();
        horse_s.material.SetTexture("_MainTex", h_Texture[horse_style[2]]);

        for (int n = 1; n < 6; n++)
        {
            bar = GameObject.Find("gauge" + n.ToString()).GetComponent<Image>();
            bar.fillAmount = horse_spec_t[n - 1, 2] / 100f;
            gauge = GameObject.Find("gauge_t" + n.ToString()).GetComponent<Text>();
            gauge.text = horse_spec_t[n - 1, 2].ToString() + "/ 100";
        }

        selectnum = 2;

        //창 변경

        GameObject second = GameObject.Find("second");
        GameObject third = GameObject.Find("third");
    
        iTween.MoveTo(second, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(third, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
    }

    public void go_click()
    {
        Button horse_go_button = GameObject.Find("go").GetComponent<Button>();
        horse_go_button.interactable = false;

        horse1 = GameObject.Find("horse_card1").GetComponent<SkinnedMeshRenderer>();
        horse2 = GameObject.Find("horse_card2").GetComponent<SkinnedMeshRenderer>();
        horse3 = GameObject.Find("horse_card3").GetComponent<SkinnedMeshRenderer>();

        if(classnum == 1)
        {
            int i = Random.Range(0, 8);
            horse1.material.SetTexture("_MainTex", h_Texture[i]);
            horse_style[0] = i;
            i = Random.Range(0, 8);
            horse2.material.SetTexture("_MainTex", h_Texture[i]);
            horse_style[1] = i;
            i = Random.Range(0, 8);
            horse3.material.SetTexture("_MainTex", h_Texture[i]);
            horse_style[2] = i;

            int temp;

            for(int j = 0; j <3; j++)  // speed 값 조절
            {
                temp = Random.Range(1, 31);
                horse_spec_t[0, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // accel 값 조절
            {
                temp = Random.Range(1, 31);
                horse_spec_t[1, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // hp 값 조절
            {
                temp = Random.Range(1, 31);
                horse_spec_t[2, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // agility 값 조절
            {
                temp = Random.Range(1, 31);
                horse_spec_t[3, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // consis 값 조절
            {
                temp = Random.Range(1, 31);
                horse_spec_t[4, j] = temp;
            }

            for(int m = 1; m < 4; m++)
            {
                for (int n = 1; n < 6; n++)
                {
                    bar = GameObject.Find("c" + m.ToString() + "_gauge" + n.ToString()).GetComponent<Image>();
                    bar.fillAmount = horse_spec_t[n-1, m-1] / 100f;
                    gauge = GameObject.Find("c" + m.ToString() + "_gauge_t" + n.ToString()).GetComponent<Text>();
                    gauge.text = horse_spec_t[n-1, m-1].ToString() + "/ 100";
                }
            }
            CardFlip1();
            CardFlip2();
            CardFlip3();
        }
        else if(classnum == 2)
        {
            int i = Random.Range(0, 8);
            horse1.material.SetTexture("_MainTex", h_Texture[i]);
            horse_style[0] = i;
            i = Random.Range(0, 8);
            horse2.material.SetTexture("_MainTex", h_Texture[i]);
            horse_style[1] = i;
            i = Random.Range(0, 8);
            horse3.material.SetTexture("_MainTex", h_Texture[i]);
            horse_style[2] = i;

            int temp;

            for (int j = 0; j < 3; j++)  // speed 값 조절
            {
                temp = Random.Range(1, 65);
                horse_spec_t[0, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // accel 값 조절
            {
                temp = Random.Range(1, 65);
                horse_spec_t[1, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // hp 값 조절
            {
                temp = Random.Range(1, 65);
                horse_spec_t[2, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // agility 값 조절
            {
                temp = Random.Range(1, 65);
                horse_spec_t[3, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // consis 값 조절
            {
                temp = Random.Range(1, 65);
                horse_spec_t[4, j] = temp;
            }

            for (int m = 1; m < 4; m++)
            {
                for (int n = 1; n < 6; n++)
                {
                    bar = GameObject.Find("c" + m.ToString() + "_gauge" + n.ToString()).GetComponent<Image>();
                    bar.fillAmount = horse_spec_t[n - 1, m - 1] / 100f;
                    gauge = GameObject.Find("c" + m.ToString() + "_gauge_t" + n.ToString()).GetComponent<Text>();
                    gauge.text = horse_spec_t[n - 1, m - 1].ToString() + "/ 100";
                }
            }
            CardFlip1();
            CardFlip2();
            CardFlip3();
        }
        else if(classnum == 3)
        {
            int i = Random.Range(0, 8);
            horse1.material.SetTexture("_MainTex", h_Texture[i]);
            horse_style[0] = i;
            i = Random.Range(0, 8);
            horse2.material.SetTexture("_MainTex", h_Texture[i]);
            horse_style[1] = i;
            i = Random.Range(0, 8);
            horse3.material.SetTexture("_MainTex", h_Texture[i]);
            horse_style[2] = i;

            int temp;

            for (int j = 0; j < 3; j++)  // speed 값 조절
            {
                temp = Random.Range(35, 101);
                horse_spec_t[0, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // accel 값 조절
            {
                temp = Random.Range(35, 101);
                horse_spec_t[1, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // hp 값 조절
            {
                temp = Random.Range(35, 101);
                horse_spec_t[2, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // agility 값 조절
            {
                temp = Random.Range(35, 101);
                horse_spec_t[3, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // consis 값 조절
            {
                temp = Random.Range(35, 101);
                horse_spec_t[4, j] = temp;
            }

            for (int m = 1; m < 4; m++)
            {
                for (int n = 1; n < 6; n++)
                {
                    bar = GameObject.Find("c" + m.ToString() + "_gauge" + n.ToString()).GetComponent<Image>();
                    bar.fillAmount = horse_spec_t[n - 1, m - 1] / 100f;
                    gauge = GameObject.Find("c" + m.ToString() + "_gauge_t" + n.ToString()).GetComponent<Text>();
                    gauge.text = horse_spec_t[n - 1, m - 1].ToString() + "/ 100";
                }
            }
            CardFlip1();
            CardFlip2();
            CardFlip3();
        }

    }
    public void goitem_click()
    {
        homebotton = GameObject.Find("home_b").GetComponent<Button>();
        homebotton.interactable = true;

        obj_card_i = GameObject.Find("obj_card_i").GetComponent<Image>();

        if (itemselect == 1)
        {
            //int i = Random.Range(1, 10);
            int i = Random.Range(1, 10);
            obj_card_i.sprite = GameManager.instance.hat_item_card[i];

            // 아이템 스펙 값 설정
            int temp;

            temp = Random.Range(0, 11);
            item_spec[0] = temp;
            temp = Random.Range(0, 11);
            item_spec[1] = temp;
            temp = Random.Range(0, 11);
            item_spec[2] = temp;
            temp = Random.Range(0, 11);
            item_spec[3] = temp;
            temp = Random.Range(0, 11);
            item_spec[4] = temp;

            for (int n = 1; n < 6; n++)
            {
                bar = GameObject.Find("i_gauge" + n.ToString()).GetComponent<Image>();
                bar.fillAmount = item_spec[n - 1] / 10f;
                gauge = GameObject.Find("i_gauge_t" + n.ToString()).GetComponent<Text>();
                gauge.text = item_spec[n - 1].ToString() + " / 10";
            }

            CardFlip_obj();
            CardFlip_spec();

            int k = GameManager.instance.itemMany;
            GameManager.instance.UserItem[k].key = i;
            GameManager.instance.UserItem[k].speed = item_spec[0];
            GameManager.instance.UserItem[k].accel = item_spec[1];
            GameManager.instance.UserItem[k].hp = item_spec[2];
            GameManager.instance.UserItem[k].agility = item_spec[3];
            GameManager.instance.UserItem[k].consis = item_spec[4];
            GameManager.instance.itemMany++;

            BlockHeader blockheader = new BlockHeader(null, GameManager.instance.Id);
            Block genesisBlock = new Block(blockheader, GameManager.instance.Id);

            GameManager.instance.UserItem[k].savetran.Add(GameManager.instance.Id);
            GameManager.instance.UserItem[k].genesishash.Add(genesisBlock.getBlockHash());


            m_Reference.Child("users").Child(GameManager.instance.Id).Child("itemMany").SetValueAsync(GameManager.instance.itemMany);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("key").SetValueAsync(GameManager.instance.UserItem[k].key);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("speed").SetValueAsync(GameManager.instance.UserItem[k].speed);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("accel").SetValueAsync(GameManager.instance.UserItem[k].accel);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("hp").SetValueAsync(GameManager.instance.UserItem[k].hp);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("agility").SetValueAsync(GameManager.instance.UserItem[k].agility);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("consis").SetValueAsync(GameManager.instance.UserItem[k].consis);

            for(int a = 0; a < GameManager.instance.UserItem[k].genesishash.Count; a++)
            {
                m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("Block").Child("node").Child("Hash" + a.ToString()).SetValueAsync(GameManager.instance.UserItem[k].genesishash[a]);
                m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("Block").Child("owner").Child("Tran" + a.ToString()).SetValueAsync(GameManager.instance.UserItem[k].savetran[a]);
            }
        }
        else if (itemselect == 2)
        {
            //int i = Random.Range(1, 10);
            int i = Random.Range(1, 4);
            obj_card_i.sprite = GameManager.instance.glasses_item_card[i];

            // 아이템 스펙 값 설정
            int temp;

            temp = Random.Range(0, 11);
            item_spec[0] = temp;
            temp = Random.Range(0, 11);
            item_spec[1] = temp;
            temp = Random.Range(0, 11);
            item_spec[2] = temp;
            temp = Random.Range(0, 11);
            item_spec[3] = temp;
            temp = Random.Range(0, 11);
            item_spec[4] = temp;

            for (int n = 1; n < 6; n++)
            {
                bar = GameObject.Find("i_gauge" + n.ToString()).GetComponent<Image>();
                bar.fillAmount = item_spec[n - 1] / 10f;
                gauge = GameObject.Find("i_gauge_t" + n.ToString()).GetComponent<Text>();
                gauge.text = item_spec[n - 1].ToString() + " / 10";
            }

            CardFlip_obj();
            CardFlip_spec();

            int k = GameManager.instance.itemMany;
            GameManager.instance.UserItem[k].key = i * 10;
            GameManager.instance.UserItem[k].speed = item_spec[0];
            GameManager.instance.UserItem[k].accel = item_spec[1];
            GameManager.instance.UserItem[k].hp = item_spec[2];
            GameManager.instance.UserItem[k].agility = item_spec[3];
            GameManager.instance.UserItem[k].consis = item_spec[4];
            GameManager.instance.itemMany++;

            BlockHeader blockheader = new BlockHeader(null, GameManager.instance.Id);
            Block genesisBlock = new Block(blockheader, GameManager.instance.Id);

            GameManager.instance.UserItem[k].savetran.Add(GameManager.instance.Id);
            GameManager.instance.UserItem[k].genesishash.Add(genesisBlock.getBlockHash());

            m_Reference.Child("users").Child(GameManager.instance.Id).Child("itemMany").SetValueAsync(GameManager.instance.itemMany);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("key").SetValueAsync(GameManager.instance.UserItem[k].key);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("speed").SetValueAsync(GameManager.instance.UserItem[k].speed);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("accel").SetValueAsync(GameManager.instance.UserItem[k].accel);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("hp").SetValueAsync(GameManager.instance.UserItem[k].hp);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("agility").SetValueAsync(GameManager.instance.UserItem[k].agility);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("consis").SetValueAsync(GameManager.instance.UserItem[k].consis);

            for (int a = 0; a < GameManager.instance.UserItem[k].genesishash.Count; a++)
            {
                m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("Block").Child("node").Child("Hash" + a.ToString()).SetValueAsync(GameManager.instance.UserItem[k].genesishash[a]);
                m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("Block").Child("owner").Child("Tran" + a.ToString()).SetValueAsync(GameManager.instance.UserItem[k].savetran[a]);
            }
        }
        else if (itemselect == 3)
        {
            //int i = Random.Range(1, 10);
            int i = Random.Range(1, 10);
            obj_card_i.sprite = GameManager.instance.back_item_card[i];

            // 아이템 스펙 값 설정
            int temp;

            temp = Random.Range(0, 11);
            item_spec[0] = temp;
            temp = Random.Range(0, 11);
            item_spec[1] = temp;
            temp = Random.Range(0, 11);
            item_spec[2] = temp;
            temp = Random.Range(0, 11);
            item_spec[3] = temp;
            temp = Random.Range(0, 11);
            item_spec[4] = temp;

            for (int n = 1; n < 6; n++)
            {
                bar = GameObject.Find("i_gauge" + n.ToString()).GetComponent<Image>();
                bar.fillAmount = item_spec[n - 1] / 10f;
                gauge = GameObject.Find("i_gauge_t" + n.ToString()).GetComponent<Text>();
                gauge.text = item_spec[n - 1].ToString() + " / 10";
            }

            CardFlip_obj();
            CardFlip_spec();

            int k = GameManager.instance.itemMany;
            GameManager.instance.UserItem[k].key = i * 100;
            GameManager.instance.UserItem[k].speed = item_spec[0];
            GameManager.instance.UserItem[k].accel = item_spec[1];
            GameManager.instance.UserItem[k].hp = item_spec[2];
            GameManager.instance.UserItem[k].agility = item_spec[3];
            GameManager.instance.UserItem[k].consis = item_spec[4];
            GameManager.instance.itemMany++;

            BlockHeader blockheader = new BlockHeader(null, GameManager.instance.Id);
            Block genesisBlock = new Block(blockheader, GameManager.instance.Id);

            GameManager.instance.UserItem[k].savetran.Add(GameManager.instance.Id);
            GameManager.instance.UserItem[k].genesishash.Add(genesisBlock.getBlockHash());

            m_Reference.Child("users").Child(GameManager.instance.Id).Child("itemMany").SetValueAsync(GameManager.instance.itemMany);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("key").SetValueAsync(GameManager.instance.UserItem[k].key);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("speed").SetValueAsync(GameManager.instance.UserItem[k].speed);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("accel").SetValueAsync(GameManager.instance.UserItem[k].accel);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("hp").SetValueAsync(GameManager.instance.UserItem[k].hp);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("agility").SetValueAsync(GameManager.instance.UserItem[k].agility);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("consis").SetValueAsync(GameManager.instance.UserItem[k].consis);

            for (int a = 0; a < GameManager.instance.UserItem[k].genesishash.Count; a++)
            {
                m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("Block").Child("node").Child("Hash" + a.ToString()).SetValueAsync(GameManager.instance.UserItem[k].genesishash[a]);
                m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("Block").Child("owner").Child("Tran" + a.ToString()).SetValueAsync(GameManager.instance.UserItem[k].savetran[a]);
            }
        }
        else if (itemselect == 4)
        {
            int i = Random.Range(1, 4);
            obj_card_i.sprite = GameManager.instance.shoes_item_card[i];

            // 아이템 스펙 값 설정
            int temp;

            temp = Random.Range(0, 11);
            item_spec[0] = temp;
            temp = Random.Range(0, 11);
            item_spec[1] = temp;
            temp = Random.Range(0, 11);
            item_spec[2] = temp;
            temp = Random.Range(0, 11);
            item_spec[3] = temp;
            temp = Random.Range(0, 11);
            item_spec[4] = temp;

            for (int n = 1; n < 6; n++)
            {
                bar = GameObject.Find("i_gauge" + n.ToString()).GetComponent<Image>();
                bar.fillAmount = item_spec[n - 1] / 10f;
                gauge = GameObject.Find("i_gauge_t" + n.ToString()).GetComponent<Text>();
                gauge.text = item_spec[n - 1].ToString() + " / 10";
            }

            CardFlip_obj();
            CardFlip_spec();

            int k = GameManager.instance.itemMany;
            GameManager.instance.UserItem[k].key = i * 1000;
            GameManager.instance.UserItem[k].speed = item_spec[0];
            GameManager.instance.UserItem[k].accel = item_spec[1];
            GameManager.instance.UserItem[k].hp = item_spec[2];
            GameManager.instance.UserItem[k].agility = item_spec[3];
            GameManager.instance.UserItem[k].consis = item_spec[4];
            GameManager.instance.itemMany++;

            BlockHeader blockheader = new BlockHeader(null, GameManager.instance.Id);
            Block genesisBlock = new Block(blockheader, GameManager.instance.Id);

            GameManager.instance.UserItem[k].savetran.Add(GameManager.instance.Id);
            GameManager.instance.UserItem[k].genesishash.Add(genesisBlock.getBlockHash());

            m_Reference.Child("users").Child(GameManager.instance.Id).Child("itemMany").SetValueAsync(GameManager.instance.itemMany);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("key").SetValueAsync(GameManager.instance.UserItem[k].key);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("speed").SetValueAsync(GameManager.instance.UserItem[k].speed);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("accel").SetValueAsync(GameManager.instance.UserItem[k].accel);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("hp").SetValueAsync(GameManager.instance.UserItem[k].hp);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("agility").SetValueAsync(GameManager.instance.UserItem[k].agility);
            m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("consis").SetValueAsync(GameManager.instance.UserItem[k].consis);

            for (int a = 0; a < GameManager.instance.UserItem[k].genesishash.Count; a++)
            {
                m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("Block").Child("node").Child("Hash" + a.ToString()).SetValueAsync(GameManager.instance.UserItem[k].genesishash[a]);
                m_Reference.Child("users").Child(GameManager.instance.Id).Child("items").Child("item" + (k.ToString())).Child("Block").Child("owner").Child("Tran" + a.ToString()).SetValueAsync(GameManager.instance.UserItem[k].savetran[a]);
            }
        }

        GameObject.Find("item_second").transform.Find("go_item_b").gameObject.SetActive(true);
        go_item = GameObject.Find("go_item").GetComponent<Button>();
        go_item.interactable = false;

    }
    public void horseWrite()
    {
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("horses").Child((GameManager.instance.many - 1).ToString()).Child("name").SetValueAsync(GameManager.instance.UserHorse[GameManager.instance.many - 1].name);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("horses").Child((GameManager.instance.many - 1).ToString()).Child("key").SetValueAsync(GameManager.instance.UserHorse[GameManager.instance.many - 1].key);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("horses").Child((GameManager.instance.many - 1).ToString()).Child("level").SetValueAsync(GameManager.instance.UserHorse[GameManager.instance.many - 1].level);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("horses").Child((GameManager.instance.many - 1).ToString()).Child("speed").SetValueAsync(GameManager.instance.UserHorse[GameManager.instance.many - 1].speed);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("horses").Child((GameManager.instance.many - 1).ToString()).Child("accel").SetValueAsync(GameManager.instance.UserHorse[GameManager.instance.many - 1].accel);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("horses").Child((GameManager.instance.many - 1).ToString()).Child("hp").SetValueAsync(GameManager.instance.UserHorse[GameManager.instance.many - 1].hp);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("horses").Child((GameManager.instance.many - 1).ToString()).Child("agility").SetValueAsync(GameManager.instance.UserHorse[GameManager.instance.many - 1].agility);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("horses").Child((GameManager.instance.many - 1).ToString()).Child("consis").SetValueAsync(GameManager.instance.UserHorse[GameManager.instance.many - 1].consis);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("horses").Child((GameManager.instance.many - 1).ToString()).Child("item").SetValueAsync(GameManager.instance.UserHorse[GameManager.instance.many - 1].items);
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("many").SetValueAsync(GameManager.instance.many);
    }

    public void save_click()
    {
        newname = GameObject.Find("name_input").GetComponent<InputField>();
        if (string.IsNullOrWhiteSpace(newname.text) || string.IsNullOrEmpty(newname.text))
        {
            senderror("공백은 입력할 수 없습니다.");
        }
        else
        {
            homebotton = GameObject.Find("home_b").GetComponent<Button>();
            homebotton.interactable = true;

            GameManager.instance.UserHorse[GameManager.instance.many].name = newname.text;

            GameManager.instance.UserHorse[GameManager.instance.many].key = horse_style[selectnum];

            GameManager.instance.UserHorse[GameManager.instance.many].speed = horse_spec_t[0, selectnum];
            GameManager.instance.UserHorse[GameManager.instance.many].accel = horse_spec_t[1, selectnum];
            GameManager.instance.UserHorse[GameManager.instance.many].hp = horse_spec_t[2, selectnum];
            GameManager.instance.UserHorse[GameManager.instance.many].agility = horse_spec_t[3, selectnum];
            GameManager.instance.UserHorse[GameManager.instance.many].consis = horse_spec_t[4, selectnum];

            GameManager.instance.many++;

            horseWrite();

            SceneManager.LoadScene("farm");
        }
      
    }

    public void home_click ()
    {
        StartCoroutine("FadeOutStart_farm");
    }
    public void CardFlip1()
    {
        StartCoroutine(CalculateFlip1());
    }

    IEnumerator CalculateFlip1()
    {
        GameObject card1 = GameObject.Find("card1");
        cardback1_c = true;

        for (int a = 0; a < 180; a = a + 2)
        {
            yield return new WaitForSeconds(0.01f);
            card1.transform.Rotate(new Vector3(x, y, z));
            timer1++;
            timer1++;

            if (timer1 == 90 || timer1 == -90)
            {
                if (cardback1_c == true)
                {
                    cardback1.SetActive(false);
                    cardback1_c = false;
                }
                else
                {
                    cardback1.SetActive(true);
                    cardback1_c = true;
                }
            }

        }
        timer1 = 0;
    }
    public void CardFlip2()
    {
        StartCoroutine(CalculateFlip2());
    }

    IEnumerator CalculateFlip2()
    {
        GameObject card2 = GameObject.Find("card2");
        cardback2_c = true;

        for (int a = 0; a < 180; a = a + 2)
        {
            yield return new WaitForSeconds(0.01f);
            card2.transform.Rotate(new Vector3(x, y, z));
            timer2++;
            timer2++;

            if (timer2 == 90 || timer2 == -90)
            {
                if (cardback2_c == true)
                {
                    cardback2.SetActive(false);
                    cardback2_c = false;
                }
                else
                {
                    cardback2.SetActive(true);
                    cardback2_c = true;
                }
            }

        }
        timer2 = 0;
    }
    public void CardFlip3()
    {
        StartCoroutine(CalculateFlip3());
    }

    public void senderror(string message)
    {
        GameObject error_p = GameObject.Find("error");
        Text error_m = GameObject.Find("error_m").GetComponent<Text>();

        error_m.text = message;
        iTween.MoveTo(error_p, iTween.Hash("y", 680, "delay", 0, "time", 0.5f));
        iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 1.5f, "time", 0.5f));
    }

    IEnumerator CalculateFlip3()
    {
        GameObject card3 = GameObject.Find("card3");
        cardback3_c = true;

        for (int a = 0; a < 180; a = a + 2)
        {
            yield return new WaitForSeconds(0.01f);
            card3.transform.Rotate(new Vector3(x, y, z));
            timer3++;
            timer3++;

            if (timer3 == 90 || timer3 == -90)
            {
                if (cardback3_c == true)
                {
                    cardback3.SetActive(false);
                    cardback3_c = false;
                }
                else
                {
                    cardback3.SetActive(true);
                    cardback3_c = true;
                }
            }

        }
        timer3 = 0;
    }

    public void CardFlip_obj()
    {
        StartCoroutine(CalculateFlip_obj());
    }

    IEnumerator CalculateFlip_obj()
    {
        GameObject obj_card = GameObject.Find("obj_card");
        cardback_ob = true;

        for (int a = 0; a < 180; a = a + 2)
        {
            yield return new WaitForSeconds(0.01f);
            obj_card.transform.Rotate(new Vector3(x, y, z));
            timero++;
            timero++;

            if (timero == 90 || timero == -90)
            {
                if (cardback_ob == true)
                {
                    cardback_o.SetActive(false);
                    cardback_ob = false;
                }
                else
                {
                    cardback_o.SetActive(true);
                    cardback_ob = true;
                }
            }

        }
        timero = 0;
    }

    public void CardFlip_spec()
    {
        StartCoroutine(CalculateFlip_spec());
    }

    IEnumerator CalculateFlip_spec()
    {
        GameObject spec_card = GameObject.Find("spec_card");
        cardback_sb = true;

        for (int a = 0; a < 180; a = a + 2)
        {
            yield return new WaitForSeconds(0.01f);
            spec_card.transform.Rotate(new Vector3(x, y, z));
            timers++;
            timers++;

            if (timero == 90 || timero == -90)
            {
                if (cardback_sb == true)
                {
                    cardback_s.SetActive(false);
                    cardback_sb = false;
                }
                else
                {
                    cardback_s.SetActive(true);
                    cardback_sb = true;
                }
            }

        }
        timers = 0;
    }

    public void sendcheck(string message)
    {
        GameObject error_p = GameObject.Find("check");
        Text error_m = GameObject.Find("check_m").GetComponent<Text>();

        error_m.text = message;
        iTween.MoveTo(error_p, iTween.Hash("y", 680, "delay", 0, "time", 0.5f));
    }

    public void check_yes()
    {
        GameObject error_p = GameObject.Find("check");
        iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 0, "time", 0.5f));

        GameObject first = GameObject.Find("first");
        GameObject second = GameObject.Find("second");
      
        iTween.MoveTo(first, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(second, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));

        GameManager.instance.money -= usedmoney;
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("money").SetValueAsync(GameManager.instance.money);

        Text money_t = GameObject.Find("money_t").GetComponent<Text>();
        money_t.text = GameManager.instance.money.ToString();

        homebotton = GameObject.Find("home_b").GetComponent<Button>();
        homebotton.interactable = false;

    }

    public void check_no()
    {
        GameObject error_p = GameObject.Find("check");
        iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 0.2f, "time", 0.5f));

        horsebuttonactive1 = GameObject.Find("level1").GetComponent<Button>();
        horsebuttonactive1.interactable = true;
        horsebuttonactive2 = GameObject.Find("level2").GetComponent<Button>();
        horsebuttonactive2.interactable = true;
        horsebuttonactive3 = GameObject.Find("level3").GetComponent<Button>();
        horsebuttonactive3.interactable = true;
    }

    public void sendcheck_i(string message)
    {
        GameObject error_p = GameObject.Find("check_i");
        Text error_m = GameObject.Find("check_m_i").GetComponent<Text>();

        error_m.text = message;
        iTween.MoveTo(error_p, iTween.Hash("y", 680, "delay", 0, "time", 0.5f));
    }

    public void check_i_yes()
    {
        GameObject error_p = GameObject.Find("check_i");
        iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 0, "time", 0.5f));

        GameObject item_second = GameObject.Find("item_second");
        GameObject item_first = GameObject.Find("item_first");

        iTween.MoveTo(item_first, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(item_second, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));

        GameManager.instance.money -= usedmoney;
        m_Reference.Child("users").Child(GameManager.instance.Id).Child("money").SetValueAsync(GameManager.instance.money);

        Text money_t = GameObject.Find("money_t").GetComponent<Text>();
        money_t.text = GameManager.instance.money.ToString();

        homebotton = GameObject.Find("home_b").GetComponent<Button>();
        homebotton.interactable = false;

    }

    public void check_i_no()
    {
        GameObject error_p = GameObject.Find("check_i");
        iTween.MoveTo(error_p, iTween.Hash("y", 900, "delay", 0.2f, "time", 0.5f));

        itembuttonactive1 = GameObject.Find("hat").GetComponent<Button>();
        itembuttonactive1.interactable = true;
        itembuttonactive2 = GameObject.Find("glasses").GetComponent<Button>();
        itembuttonactive2.interactable = true;
        itembuttonactive3 = GameObject.Find("back").GetComponent<Button>();
        itembuttonactive3.interactable = true;
        itembuttonactive4 = GameObject.Find("shoes").GetComponent<Button>();
        itembuttonactive4.interactable = true;
    }

    public IEnumerator FadeInStart()
    {
        fadeImg.SetActive(true);
        for (float f = 1f; f > 0; f -= GameManager.instance.fade_speed)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }
        
        fadeImg.SetActive(false);
    }
    //페이드 인
    public IEnumerator FadeOutStart_farm()
    {
        fadeImg.SetActive(true);
        for (float f = 0f; f < 1; f += GameManager.instance.fade_speed)
        {
            Color c = fadeImg.GetComponent<Image>().color;
            c.a = f;
            fadeImg.GetComponent<Image>().color = c;
            yield return null;
        }
        SceneManager.LoadScene("farm");
    }

}
