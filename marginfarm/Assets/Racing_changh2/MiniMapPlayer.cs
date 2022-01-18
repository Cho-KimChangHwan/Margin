using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject realPlayer;
    void Awake() {
        gameObject.tag = "Mini";
    }
    void Start()
    {
        realPlayer = transform.parent.gameObject;
        gameObject.layer = 9;
        realPlayer.layer = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = realPlayer.transform.position;
    }
}
