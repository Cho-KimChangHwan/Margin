using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmSetting : MonoBehaviour
{
    public GameObject horse;
    public SkinnedMeshRenderer horseSkin;

    public Texture[] h_Texture = new Texture[8];

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.spec_check = false;

        for (int i = 1; i <= GameManager.instance.many; i++)
        {
            GameObject horse = GameObject.Find("horse" + i.ToString());
            horse.SetActive(true);

            horseSkin = GameObject.Find("horse_s" + i.ToString()).GetComponent<SkinnedMeshRenderer>();
            horseSkin.material.SetTexture("_MainTex", h_Texture[GameManager.instance.UserHorse[i - 1].key]);
        }

        for (int i = 6; i > GameManager.instance.many; i--)
        {
            GameObject horse = GameObject.Find("horse" + i.ToString());
            horse.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
