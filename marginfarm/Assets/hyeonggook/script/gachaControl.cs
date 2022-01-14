using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gachaControl : MonoBehaviour
{

    public GameObject first;
    public GameObject second;
    public GameObject third;

    public SkinnedMeshRenderer horse1;
    public SkinnedMeshRenderer horse2;
    public SkinnedMeshRenderer horse3;

    public Texture[] h_Texture = new Texture[11];

    public int classnum;
    public int selectnum;

    public Image bar;
    public Text gauge;

    public int[,] horse_spec_t = new int[5, 3];

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

    /*
    public int[] speed_t = new int[3]; 0번인덱스
    public int[] accel_t = new int[3]; 1번인덱스
    public int[] hp_t = new int[3]; 
    public int[] agility_t = new int[3];
    public int[] consis_t = new int[3];
    */
    public void gacha_b1_click()
    {
        GameObject first = GameObject.Find("first");
        GameObject second = GameObject.Find("second");
        GameObject third = GameObject.Find("third");
        iTween.MoveTo(first, iTween.Hash("y", 1100, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(second, iTween.Hash("y", 360, "delay", 0.1f, "time", 0.5f));
        iTween.MoveTo(third, iTween.Hash("y", -380, "delay", 0.1f, "time", 0.5f));

        classnum = 1;
    }

    public void go_click()
    {
        horse1 = GameObject.Find("horse_card1").GetComponent<SkinnedMeshRenderer>();
        horse2 = GameObject.Find("horse_card2").GetComponent<SkinnedMeshRenderer>();
        horse3 = GameObject.Find("horse_card3").GetComponent<SkinnedMeshRenderer>();

        if(classnum == 1)
        {
            int i = Random.Range(0, 11);
            horse1.material.SetTexture("_MainTex", h_Texture[i]);
            i = Random.Range(0, 11);
            horse2.material.SetTexture("_MainTex", h_Texture[i]);
            i = Random.Range(0, 11);
            horse3.material.SetTexture("_MainTex", h_Texture[i]);

            int temp;

            for(int j = 0; j <3; j++)  // speed 값 조절
            {
                temp = Random.Range(1, 101);
                horse_spec_t[0, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // accel 값 조절
            {
                temp = Random.Range(1, 101);
                horse_spec_t[1, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // hp 값 조절
            {
                temp = Random.Range(1, 101);
                horse_spec_t[2, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // agility 값 조절
            {
                temp = Random.Range(1, 101);
                horse_spec_t[3, j] = temp;
            }
            for (int j = 0; j < 3; j++)   // consis 값 조절
            {
                temp = Random.Range(1, 101);
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

        }
        else if(classnum == 3)
        {

        }

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

}
