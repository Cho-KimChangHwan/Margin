using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseani : MonoBehaviour
{
    Animator anim;
    int randomNum;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {

        }
        else
        {
            randomNum = Random.Range(0, 7);
        }

        anim.SetInteger("state", randomNum);
            
    }
}