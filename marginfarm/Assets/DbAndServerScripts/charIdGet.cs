﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class charIdGet : MonoBehaviourPunCallbacks
{
    public TextMesh charId;
    public int randd;
    // Start is called before the first frame update
    void Start()
    {
        charId = GetComponent<TextMesh>();
        randd = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        charId.text = randd.ToString();
    }
}