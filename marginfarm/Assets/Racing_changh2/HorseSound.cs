using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseSound : MonoBehaviour
{
    public AudioClip startSound;
    public AudioClip runSound;
    AudioSource audioSource;
    CountDown count;
    HorseStatus horseStatus;
    bool isRun;
    void Awake() {
        isRun = false;
        this.audioSource = GetComponent<AudioSource>();
        count = GameObject.Find("Canvas").GetComponent<CountDown>();
 
        string myname = "Player" + (GameManager.instance.mytern ).ToString();
        horseStatus = GameObject.FindWithTag(myname).GetComponent<HorseStatus>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = startSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(count.isStart && !horseStatus.horseLocation["Final"] && !isRun)
        {
            audioSource.clip = runSound;
            audioSource.loop = true;
            audioSource.Play();
            isRun = true;
        }
        else if(horseStatus.horseLocation["Final"])
        {
            audioSource.Stop();
        }
    }
}
