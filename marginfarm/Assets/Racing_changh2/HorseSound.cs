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
    void Awake() {
        this.audioSource = GetComponent<AudioSource>();
        count = GameObject.Find("Count").GetComponent<CountDown>();
        horseStatus = this.GetComponent<HorseStatus>();
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
        if(count.isStart && !horseStatus.horseLocation["Final"])
        {
            audioSource.clip = runSound;
            audioSource.Play();
        }
    }
}
