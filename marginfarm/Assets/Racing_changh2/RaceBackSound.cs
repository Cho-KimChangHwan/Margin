using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceBackSound : MonoBehaviour
{
    // Start is called before the first frame update
  
    public AudioClip backSound;
    AudioSource clickaudio;
    AudioSource audioSource;
    float originalV;
    float clickV;
    bool On= true;
    TextMeshProUGUI soundT;


    void Awake() {
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        originalV = audioSource.volume;
        clickaudio = GameObject.Find("Canvas").GetComponent<AudioSource>();
        clickV = clickaudio.volume;
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
            clickaudio.volume = 0f;
            On = false;
        }
        else
        {
            audioSource.volume = originalV;
            clickaudio.volume = clickV;
            On = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
