using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float cameraSpeed = 5.0f;
    Vector3 length;
    GameObject miniplayer;
    GameObject realPlayer;
    Vector3 cameraDirection;
    void Start()
    {
        miniplayer = GameObject.Find("MiniPlayer1");
        realPlayer = miniplayer.transform.parent.gameObject;
        length = -realPlayer.transform.position + transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = length + Vector3.MoveTowards(realPlayer.GetComponent<HorseStatus>().currentPosition , 
                                            new Vector3(realPlayer.GetComponent<HorseStatus>().dRandom,realPlayer.GetComponent<HorseStatus>().currentPosition.y,realPlayer.GetComponent<HorseStatus>().rPoint2 ),4.5f*realPlayer.GetComponent<HorseStatus>().resultSpeed* Time.deltaTime); 
        
        //transform.rotation = Quaternion.LookRotation(realPlayer.GetComponent<HorseStatus>().lookDirection);
        // Vector3 dir = player.transform.position - this.transform.position;
        // Vector3 moveVector = new Vector3(dir.x * 5 * Time.deltaTime, dir.y * 5 * Time.deltaTime, 0.0f);
        // this.transform.Translate(moveVector);
        cameraDirection = realPlayer.GetComponent<HorseStatus>().lookDirection;
        transform.Rotate(cameraDirection.x,cameraDirection.y,cameraDirection.z);
    }
}
