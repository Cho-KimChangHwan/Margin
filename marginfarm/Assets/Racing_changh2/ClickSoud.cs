using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoud : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            audioSource.Play();
        }
    }
}
