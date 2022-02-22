using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceBackSound : MonoBehaviour
{
    // Start is called before the first frame update
  
    public AudioClip backSound;

    AudioSource audioSource;
    float originalV;
    bool On= true;
    TextMeshProUGUI soundT;


    void Awake() {
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        originalV = audioSource.volume;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }
    public void SoundControl()
    {
        if(On)
        {
            audioSource.volume = 0f;
            On = false;
        }
        else
        {
            audioSource.volume = originalV;
            On = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
