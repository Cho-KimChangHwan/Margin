using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmer : MonoBehaviour
{
    List<string> animArray;
    Animation anim;
    int index = 3;
    int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        animArray = new List<string>();
        AnimationArray();

        anim.Play(animArray[randomNum]);
        anim.wrapMode = WrapMode.Once;
    }

    public void AnimationArray()
    {
        foreach (AnimationState state in anim)
        {
            animArray.Add(state.name);
            index++;
        }
        randomNum = Random.Range(0, index);
    }


}
