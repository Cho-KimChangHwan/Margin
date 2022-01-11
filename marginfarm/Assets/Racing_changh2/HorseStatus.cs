using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseStatus : MonoBehaviour
{
    // Start is called before the first frame update
     public struct Status
    {
        public float speed , accel , hp , agility , consis;
        public Status(float s,float a,float h,float ag,float c)
        {
            this.speed = s;
            this.accel = a;
            this.hp = h;
            this.agility = ag;
            this.consis = c;
        }
    }
    public Dictionary<string,bool> horseLocation = new Dictionary<string, bool>();
    Status horseStatus;

    bool isHalf; // 레일의 절반을 뛰었는지 판단
    // 회전에 필요한 변수 및  오브젝트
    float rotateTime ,radius;
    bool isRotate;
    // 대각선에 필요한 변수
    bool isDiagonal;
    float dRandom;
    Vector3 firstAxis,secondAxis;
    Vector3 startPosition,endPosition;
    // 회전 / 대각선의 z좌표
    float rPoint1 = 30f , rPoint2 = -15f;
    float dPoint1 = 19.75f , dPoint2 = -4.75f;
    void Start()
    {
        AddLocation();
        firstAxis = new Vector3(15f,0f,rPoint1);
        secondAxis = new Vector3(15f,0f,rPoint2);
        horseStatus = new Status(2.0f,1.0f,1.0f,1.0f,1.0f);
        isHalf = false;
        isRotate = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        Run();
    }

    void Run()
    {
        Vector3 currentPosition = transform.position;

        if(currentPosition.z >= rPoint1  && !isRotate && horseLocation["First"] ) // 커브길 시작
        {
            horseLocation["First"] = false;
            horseLocation["Second"] = true;
            isRotate = true;
            isDiagonal = false;
            radius = Vector3.Distance( currentPosition , firstAxis);
            startPosition = currentPosition;
        }
        else if(currentPosition.z <= rPoint2 && !isRotate && horseLocation["Third"])
        {
            horseLocation["Third"] = false;
            horseLocation["Fourth"] = true;
            isRotate = true;
            isDiagonal = false;
            radius = Vector3.Distance( currentPosition , secondAxis);
            startPosition = currentPosition;
            
        }
        else if(isRotate && (horseLocation["Second"] || horseLocation["Fourth"]) )
        {
            Rotate();
        }
        else if(currentPosition.z >= rPoint2 && currentPosition.z <= rPoint1 && horseLocation["First"]) // 직선 코스
        {
            if( isDiagonal )
            {
                transform.position = Vector3.MoveTowards(currentPosition , 
                                            new Vector3(dRandom,currentPosition.y,rPoint1 ),4f*horseStatus.speed* Time.deltaTime);
            }
            else if( currentPosition.z >= dPoint1 && !isDiagonal)
            {
                isDiagonal = true;
                dRandom = Random.Range(34f ,(float)currentPosition.x);
                Debug.Log(dRandom);
            }
            else{
                transform.position = Vector3.MoveTowards(currentPosition , 
                                            new Vector3(currentPosition.x,currentPosition.y,rPoint1),5f*horseStatus.speed* Time.deltaTime);
                rotateTime=0;
            }
        }
        else if(currentPosition.z >= rPoint2 && currentPosition.z <= rPoint1  && horseLocation["Third"] )
        {
            if( isDiagonal )
            {
                transform.position = Vector3.MoveTowards(currentPosition , 
                                            new Vector3(dRandom,currentPosition.y,rPoint2 ),4f*horseStatus.speed* Time.deltaTime);
            }
            else if( currentPosition.z <= dPoint2 && !isDiagonal)
            {
                Debug.Log("dsd");
                isDiagonal = true;
                dRandom = Random.Range((float)currentPosition.x , -4f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(currentPosition , 
                                            new Vector3(currentPosition.x,currentPosition.y,rPoint2),5f*horseStatus.speed* Time.deltaTime); 
                rotateTime=0;
                isHalf = true;
            }
        }
        else if(horseLocation["Final"])
        {
            transform.position = Vector3.MoveTowards(currentPosition , 
                                        endPosition,5f*horseStatus.speed* Time.deltaTime); 
        }
    }

    void DecisionMake()
    {

    }
    void Rotate()
    {
        Vector3 currentPosition = transform.position;

        if(horseLocation["Second"])
        {
            rotateTime += horseStatus.speed* Time.deltaTime * 0.2f ;
            float x = radius * Mathf.Cos(rotateTime);
            float z = radius * Mathf.Sin(-rotateTime);
            transform.position = new Vector3( firstAxis.x +x,startPosition.y, ( firstAxis.z -z));
            if(transform.position.z <= rPoint1 && !isHalf )
            {
               isRotate = false;
               horseLocation["Second"] = false;
               horseLocation["Third"] = true;
            }
        }
        else if(horseLocation["Fourth"])
        {
            rotateTime += horseStatus.speed* Time.deltaTime * 0.2f ;
            float x = radius * Mathf.Cos(-rotateTime);
            float z = radius * Mathf.Sin(-rotateTime);
            transform.position = new Vector3( (secondAxis.x -x),startPosition.y, ( secondAxis.z +z));
            if(transform.position.z >= rPoint2 && isHalf )
            {
               isRotate = false;
               horseLocation["Fourth"] = false;
               horseLocation["Final"] = true;
               endPosition = new Vector3(currentPosition.x,currentPosition.y, Random.Range(6.0f,25.0f));
               Debug.Log(endPosition.z);
            }
        }

    }

    void AddLocation(){
        horseLocation.Add("First",true);
        horseLocation.Add("Second",false);
        horseLocation.Add("Third",false);
        horseLocation.Add("Fourth",false);
        horseLocation.Add("Final",false);
    }
}
