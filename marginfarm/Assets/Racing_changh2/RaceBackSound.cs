using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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
    public Sprite soundImg,muteImg;
    Image thisimg;


    void Awake() {
        audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        originalV = audioSource.volume;
        if (SceneManager.GetActiveScene().name == "Trade"){
            clickaudio = GameObject.Find("TradePanel").GetComponent<AudioSource>();
        }
        else{
            clickaudio = GameObject.Find("Canvas").GetComponent<AudioSource>();
        }
        clickV = clickaudio.volume;
        thisimg = this.GetComponent<Image>();
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
            thisimg.sprite = muteImg;
            On = false;
        }
        else
        {
            audioSource.volume = originalV;
            clickaudio.volume = clickV;
            thisimg.sprite = soundImg;
            On = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
