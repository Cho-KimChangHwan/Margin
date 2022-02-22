using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float cameraSpeed = 5.0f;
    float distance;
    Vector3 distanceV,distanceV2;
    GameObject miniplayer;
    GameObject realPlayer;
    HorseStatus horsestatus;
    Vector3 cameraDirection;
    Vector3 lookDirection;
    Vector3 currentPosition;
    void Start()
    {
        FindObject();
        SetDistance();
    }
    void SetDistance()
    {
        distanceV = -realPlayer.transform.position + transform.position;
        distanceV2 = distanceV - new Vector3(2f*distanceV.x,0f,0f);
        distance = Vector3.Distance( transform.position , realPlayer.transform.position);
        cameraDirection = transform.eulerAngles;
    }
    void FindObject()
    {
        miniplayer = GameObject.Find("MiniPlayer");
        realPlayer = miniplayer.transform.parent.gameObject;
        horsestatus = realPlayer.GetComponent<HorseStatus>();
    }
    void Follow()
    {
        if( !horsestatus.isRotate )
        { 
            currentPosition = transform.position; 
            if(!horsestatus.isHalf)
            {
                transform.position = distanceV + Vector3.MoveTowards( horsestatus.currentPosition, 
                                                new Vector3(horsestatus.currentPosition.x,horsestatus.currentPosition.y,horsestatus.rPoint1 ),4.5f*horsestatus.resultSpeed* Time.deltaTime); 
            }
            else
            {
                transform.position =  distanceV2 + Vector3.MoveTowards( horsestatus.currentPosition, 
                                                new Vector3(horsestatus.currentPosition.x,horsestatus.currentPosition.y,horsestatus.rPoint2 ),4.5f*horsestatus.resultSpeed* Time.deltaTime); 
            }
        }
        else if (horsestatus.isRotate)
        {
            if(!horsestatus.isHalf)
            {
                horsestatus.rotateX = (distance+horsestatus.radius) * Mathf.Cos(horsestatus.rotateTime);
                horsestatus.rotateZ = (distance+horsestatus.radius) * Mathf.Sin(-horsestatus.rotateTime);
                transform.position = new Vector3( horsestatus.firstAxis.x +horsestatus.rotateX,transform.position.y, ( horsestatus.firstAxis.z -horsestatus.rotateZ));
            }
            else
            {
                horsestatus.rotateX = (distance+horsestatus.radius) * Mathf.Cos(-horsestatus.rotateTime);
                horsestatus.rotateZ = (distance+horsestatus.radius) * Mathf.Sin(-horsestatus.rotateTime);
                transform.position = new Vector3( horsestatus.secondAxis.x - horsestatus.rotateX,transform.position.y, ( horsestatus.secondAxis.z +horsestatus.rotateZ));
            }
        }
        transform.rotation = Quaternion.LookRotation(realPlayer.transform.position -transform.position);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }
}
