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
    public Status status;
    public float resultSpeed , timeChecker;
    public bool isHalf; // 레일의 절반을 뛰었는지 판단
    // 회전에 필요한 변수 및  오브젝트
    public float rotateTime ,radius;
    public bool isRotate;
    public float rotateX,rotateZ;
    // 대각선에 필요한 변수
    bool isDiagonal;
    public float dRandom;
    public Vector3 firstAxis,secondAxis;
    Vector3 startPosition,finalPosition;
    public Vector3 currentPosition ;
    public Vector3 lookDirection ,changeRotation ;
    // 회전 / 대각선의 z좌표
    public float rPoint1 = 30f , rPoint2 = -15f;
    public float dPoint1 = 19.75f , dPoint2 = -4.75f;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        gameObject.layer = 10;
        InputVariable();
        InputLocation();
        InputStatus();
        ApplyConsis();
    }
    void InputVariable()
    {
        firstAxis = new Vector3(15f,0f,rPoint1);
        secondAxis = new Vector3(15f,0f,rPoint2);
        lookDirection = new Vector3(0f,0f,0f);
        isHalf = false;
        isRotate = false;
        resultSpeed = 0f;
        timeChecker = 0f;
    }
    void InputStatus()
    {
        status = new Status(42.0f,60.0f,40.0f,50.0f,8.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        Run();
    }

    void Run()
    {
        currentPosition = transform.position;
        CalculateSpeed();
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
            if( isDiagonal ) // 대각선 주행 
            {
                transform.position = Vector3.MoveTowards(currentPosition , 
                                            new Vector3(dRandom,currentPosition.y,rPoint1 ),4.5f* resultSpeed * Time.deltaTime);
            }
            else if( currentPosition.z >= dPoint1 && !isDiagonal)
            {
                isDiagonal = true;
                dRandom = Random.Range(34f ,(float)currentPosition.x);
            }
            else{
                transform.position = Vector3.MoveTowards(currentPosition , 
                                            new Vector3(currentPosition.x,currentPosition.y,rPoint1),5f* resultSpeed * Time.deltaTime);
                rotateTime=0;
            }
            animator.Play("Horse_Canter");
            ApplyRotate();
        }
        else if(currentPosition.z >= rPoint2 && currentPosition.z <= rPoint1  && horseLocation["Third"] )
        {
            if( isDiagonal )
            {
                transform.position = Vector3.MoveTowards(currentPosition , 
                                            new Vector3(dRandom,currentPosition.y,rPoint2 ),4.5f*resultSpeed* Time.deltaTime);          
            }
            else if( currentPosition.z <= dPoint2 && !isDiagonal)
            {
                isDiagonal = true;
                dRandom = -1f* Random.Range(4f, -1f* (float)currentPosition.x );
            }
            else
            {
                transform.position = Vector3.MoveTowards(currentPosition , 
                                            new Vector3(currentPosition.x,currentPosition.y,rPoint2),5f*resultSpeed* Time.deltaTime); 
                rotateTime=0;
                isHalf = true;
            }
            animator.Play("Horse_Canter");
            ApplyRotate(); 
        }
        else if(horseLocation["Final"])
        {
            transform.position = Vector3.MoveTowards(currentPosition , 
                                        finalPosition,5f*resultSpeed* Time.deltaTime); 
            animator.Play("Horse_Trot");
            if(transform.position == finalPosition )
            {
                horseLocation["Final"] = false;
            }
        }
        else
        {
            animator.Play("Horse_Paw2");
        }
    }

    void ApplyConsis()
    {
        float consisValue=0f;
        switch((int)status.consis / 20 )
        {
                case 0 : consisValue = Random.Range (0.7f , 1.1f );
                break;

                case 1 : consisValue =Random.Range (0.75f , 1.1f );
                break;

                case 2 : consisValue =Random.Range (0.8f , 1.1f );
                break;

                case 3 : consisValue =Random.Range (0.85f , 1.1f );
                break;

                case 4 : consisValue =Random.Range (0.9f , 1.15f );
                break;
                case 5 : consisValue =Random.Range (0.95f , 1.15f );
                break;
        }
        status.accel *= consisValue;
        status.agility *= consisValue;
        status.hp *= consisValue;
        status.speed *= consisValue;

    }
    void CalculateSpeed()
    {
        // status.accel;
        // status.agility;
        // status.consis;
        // status.hp;
        // status.speed;
        timeChecker += 10f * Time.deltaTime;
        if(horseLocation["First"])
        {
            resultSpeed = status.speed + (status.accel/100) * timeChecker;
        }
        else if(horseLocation["Second"])
        {
            resultSpeed = status.speed + (status.accel/100) * timeChecker;
            switch((int)status.agility / 20 )
            {
                case 0 : resultSpeed = resultSpeed * ( 0.5f * (status.agility / 20f ));
                break;

                case 1 : resultSpeed = resultSpeed * ( 0.625f * (status.agility / 20f ));
                break;

                case 2 : resultSpeed = resultSpeed * ( 0.75f * (status.agility / 20f ));
                break;

                case 3 : resultSpeed = resultSpeed * ( 0.875f * (status.agility / 20f ));
                break;

                case 5 : 
                case 4 : resultSpeed = resultSpeed * ( 1f * (status.agility / 20f ));
                break;
            }
        }
        else if(horseLocation["Third"])
        {
            if(( (100-status.hp)/100f * timeChecker ) <= status.speed/2f )
                resultSpeed = status.speed - ( (100-status.hp)/100f * timeChecker );
            else if ( ( (100-status.hp)/100f * timeChecker ) > status.speed/2f )
                resultSpeed = status.speed / 2f ;
        }
        else if(horseLocation["Fourth"])
        {
            if(( (100-status.hp)/100f * timeChecker ) <= status.speed/2f )
                resultSpeed = status.speed - ( (100-status.hp)/100f * timeChecker );
            else if ( ( (100-status.hp)/100f * timeChecker ) > status.speed/2f )
                resultSpeed = status.speed / 2f ;

            switch((int)status.hp/ 20 )
            {
                case 0 : resultSpeed = resultSpeed * ( 0.5f * (status.agility / 15f ));
                break;

                case 1 : resultSpeed = resultSpeed * ( 0.625f * (status.agility / 15f ));
                break;

                case 2 : resultSpeed = resultSpeed * ( 0.75f * (status.agility / 15f ));
                break;

                case 3 : resultSpeed = resultSpeed * ( 0.875f * (status.agility / 15f ));
                break;

                case 5 : 
                case 4 : resultSpeed = resultSpeed * ( 1f * (status.agility / 15f ));
                break;
            }
        }
        resultSpeed = ((resultSpeed)/10f) + 1f;
    }
    void Rotate()
    {
        Vector3 currentPosition = transform.position;

        if(horseLocation["Second"])
        {
            rotateTime += resultSpeed * Time.deltaTime * 0.1f ;
            rotateX = radius * Mathf.Cos(rotateTime);
            rotateZ = radius * Mathf.Sin(-rotateTime);
            transform.position = new Vector3( firstAxis.x +rotateX,startPosition.y, ( firstAxis.z -rotateZ));
            if(transform.position.z <= rPoint1 && !isHalf )
            {
               isRotate = false;
               isHalf = true;
               horseLocation["Second"] = false;
               horseLocation["Third"] = true;
               timeChecker = 0f;
               lookDirection = new Vector3(0f,0f,0f);
            }
        }
        else if(horseLocation["Fourth"])
        {
            rotateTime += resultSpeed * Time.deltaTime * 0.1f ;
            rotateX = radius * Mathf.Cos(-rotateTime);
            rotateZ = radius * Mathf.Sin(-rotateTime);
            transform.position = new Vector3( (secondAxis.x -rotateX),startPosition.y, ( secondAxis.z +rotateZ));
            if(transform.position.z >= rPoint2 && isHalf )
            {
               isRotate = false;
               isHalf = false;
               horseLocation["Fourth"] = false;
               horseLocation["Final"] = true;
               timeChecker = 0f;
               finalPosition = new Vector3(currentPosition.x,currentPosition.y, Random.Range(6.0f,25.0f));
               lookDirection = new Vector3(0f,0f,0f);
            }
        }
        Vector3 currentRotation = transform.eulerAngles;
        // lookDirection = (transform.position -currentPosition);
        // transform.rotation = Quaternion.LookRotation(lookDirection);   
        ApplyRotate(); 
        animator.Play("Horse_Gallop");
        changeRotation = - currentRotation  + transform.eulerAngles;
    }
    void ApplyRotate()
    {
        lookDirection = -(transform.position -currentPosition);
        transform.rotation = Quaternion.Lerp( transform.rotation , Quaternion.LookRotation(lookDirection) ,5f*Time.deltaTime);
        //transform.rotation = Quaternion.LookRotation(lookDirection);  
    }
    void InputLocation(){
        horseLocation.Add("First",true);
        horseLocation.Add("Second",false);
        horseLocation.Add("Third",false);
        horseLocation.Add("Fourth",false);
        horseLocation.Add("Final",false);
    }
}