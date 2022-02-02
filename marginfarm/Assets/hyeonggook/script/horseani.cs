using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseani : MonoBehaviour
{
    List<string> animArray;
    Animation anim;
    int index = 0;
    int randomNum;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        animArray = new List<string>();

        foreach (AnimationState state in anim)
        {
            animArray[index] = state.name;
            index++;
        };

        randomNum = Random.Range(0, index);
        anim.Play(animArray[randomNum]);
    }

    // Update is called once per frame
    void Update()
    {
        randomNum = Random.Range(0, index);
        anim.Play(animArray[randomNum]);
    }
}