using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardflip : MonoBehaviour
{
    public float x, y, z;
    public GameObject cardback1;
    public bool cardback1_c;
    public int timer1;
    public void CardFlip1()
    {
        cardback1_c = false;
        StartCoroutine(CalculateFlip1());
    }

    public void Flip1()
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

    IEnumerator CalculateFlip1()
    {
        for (int a = 0; a < 180; a++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(new Vector3(x, y, z));
            timer1++;

            if (timer1 == 90 || timer1 == -90)
            {
                Flip1();
            }

        }
        timer1 = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        cardback1_c = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
