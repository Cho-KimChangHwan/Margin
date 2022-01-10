using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseStatus : MonoBehaviour
{
    // Start is called before the first frame update
     public struct Status
    {
        public float speed , accel , hp , agility , consistency;
        public Status(float s,float a,float h,float ag,float c)
        {
            this.speed = s;
            this.accel = a;
            this.hp = h;
            this.agility = ag;
            this.consistency = c;
        }
    }
    public Dictionary<string,bool> horseLocation = new Dictionary<string, bool>();
    Status horseStatus;

    bool isHalf; // 레일의 절반을 뛰었는지 판단
    float rotateTime;
    // 회전에 필요한 변수 및  오브젝트
    float radius;
    bool isRotate;
    Vector3 firstAxis,secondAxis;
    Vector3 startPosition,endPosition;
    void Start()
    {
        AddLocation();
        firstAxis = new Vector3(15f,0f,30f);
        secondAxis = new Vector3(15f,0f,-15f);
        horseStatus = new Status(2.0f,1.0f,1.0f,1.0f,1.0f);
        isHalf =false;
        isRotate =false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        Run();
    }

    void Run()
    {
        Vector3 currentPosition = transform.position;

        if(currentPosition.z >= 30  && !isRotate && horseLocation["First"] ) // 커브길 시작
        {
            horseLocation["First"] = false;
            horseLocation["Second"] = true;
            isRotate = true;
            radius = Vector3.Distance( currentPosition , firstAxis);
            startPosition = currentPosition;
        }
        else if(currentPosition.z <= -15f && !isRotate && horseLocation["Third"])
        {
            horseLocation["Third"] = false;
            horseLocation["Fourth"] = true;
            isRotate = true;
            radius = Vector3.Distance( currentPosition , secondAxis);
            startPosition = currentPosition;
            
        }
        else if(isRotate && (horseLocation["Second"] || horseLocation["Fourth"]) )
        {
            Rotate();
        }
        else if(currentPosition.z >= -15f && currentPosition.z <= 30f && horseLocation["First"]) // 직선 코스
        {
            transform.position = Vector3.MoveTowards(currentPosition , 
                                        new Vector3(currentPosition.x,currentPosition.y,30f),10f*horseStatus.speed* Time.deltaTime);
            rotateTime=0;
        }
        else if(currentPosition.z >= -15f && currentPosition.z <= 30f  && horseLocation["Third"] )
        {
            transform.position = Vector3.MoveTowards(currentPosition , 
                                        new Vector3(currentPosition.x,currentPosition.y,-15f),10f*horseStatus.speed* Time.deltaTime); 
            rotateTime=0;
            isHalf = true;
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
            rotateTime += horseStatus.speed* Time.deltaTime * 1f ;
            float x = radius * Mathf.Cos(rotateTime);
            float z = radius * Mathf.Sin(-rotateTime);
            transform.position = new Vector3( firstAxis.x +x,startPosition.y, ( firstAxis.z -z));
            if(transform.position.z <= 30f && !isHalf )
            {
               isRotate = false;
               horseLocation["Second"] = false;
               horseLocation["Third"] = true;
            }
        }
        else if(horseLocation["Fourth"])
        {
            rotateTime += horseStatus.speed* Time.deltaTime * 0.5f ;
            float x = radius * Mathf.Cos(-rotateTime);
            float z = radius * Mathf.Sin(-rotateTime);
            transform.position = new Vector3( (secondAxis.x -x),startPosition.y, ( secondAxis.z +z));
            if(transform.position.z >= -15f && isHalf )
            {
               isRotate = false;
               horseLocation["Fourth"] = false;
               horseLocation["Final"] = true;
               endPosition = new Vector3(currentPosition.x,currentPosition.y, Random.Range(6.0f,25.0f));
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
