using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float cameraSpeed = 5.0f;

    public GameObject player;
    // void Start()
    // {
    //     player = GameObject.Find("Player");

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     Vector3 dir = player.transform.position - this.transform.position;
    //     Vector3 moveVector = new Vector3(dir.x * 5 * Time.deltaTime, dir.y * 5 * Time.deltaTime, 0.0f);
    //     this.transform.Translate(moveVector);
    // }
}
