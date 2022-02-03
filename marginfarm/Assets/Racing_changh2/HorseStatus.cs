using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class HorseStatus : MonoBehaviourPunCallbacks
{
    public struct Status
    {
        public float speed, accel, hp, agility, consis;
        public string name;
        public Status(string n,float s, float a, float h, float ag, float c)
        {
            this.name = n;
            this.speed = s;
            this.accel = a;
            this.hp = h;
            this.agility = ag;
            this.consis = c;
        }
    }
    
    public float s,a,h,ag,c;
    public string n;
    public Dictionary<string, bool> horseLocation = new Dictionary<string, bool>();
    public Status status;
    public float resultSpeed, timeChecker;
    public bool isHalf; // 레일의 절반을 뛰었는지 판단
    // 회전에 필요한 변수 및  오브젝트
    public float rotateTime, radius;
    public bool isRotate;
    public float rotateX, rotateZ;
    // 대각선에 필요한 변수
    bool isDiagonal;
    public float dRandom;
    public Vector3 firstAxis, secondAxis;
    Vector3 startPosition, finalPosition;
    public Vector3 currentPosition;
    public Vector3 lookDirection, changeRotation;
    // 회전 / 대각선의 z좌표
    public float rPoint1 = 30f, rPoint2 = -15f;
    public float dPoint1 = 19.75f, dPoint2 = -4.75f;
    public Animator animator;
    public CountDown count;
    Text record ;
    GameObject leadHorse ;
    HorseStatus leadStatus ;
    bool isCollide=false;
    public float myRecord;

    Renderer myRender;
    void Awake()
    {
        if (photonView.IsMine)
        {
            n = GameManager.instance.UserHorse[GameManager.instance.captain].name;
            s = GameManager.instance.UserHorse[GameManager.instance.captain].speed;
            a = GameManager.instance.UserHorse[GameManager.instance.captain].accel;
            h = GameManager.instance.UserHorse[GameManager.instance.captain].hp;
            ag = GameManager.instance.UserHorse[GameManager.instance.captain].agility;
            c = GameManager.instance.UserHorse[GameManager.instance.captain].consis;
        }
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "RacingScene")
        {
            animator = GetComponent<Animator>();
            count = GameObject.Find("Canvas").GetComponent<CountDown>();
            record = GameObject.Find("Record").GetComponent<Text>();
            gameObject.layer = 10;
            if (photonView.IsMine)
            {
                InputVariable();
                InputLocation();
                InputStatus();
                ApplyConsis();
            }
        }
        Debug.Log( status.name);
        gameObject.name = status.name;
        Debug.Log(gameObject.name );
    }
    void InputVariable()
    {
        firstAxis = new Vector3(15f, 0f, rPoint1);
        secondAxis = new Vector3(15f, 0f, rPoint2);
        lookDirection = new Vector3(0f, 0f, 0f);
        isHalf = false;
        isRotate = false;
        resultSpeed = 0f;
        timeChecker = 0f;
    }
    void InputStatus()
    {
        status = new Status(n,s,a,h,ag,c);
        //status = new Status(10.0f, 60.0f, 40.0f, 50.0f, 8.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "RacingScene")
        {
            if (count.isStart)
            {
                countRecord();
                
                Run();
            }
            else
            {
                myRecord = 0f;
            }
        }
    }
    void countRecord()
    {
        if(horseLocation["Final"])
        {
            record.text = "Record : " + myRecord.ToString("F3") ;
        }
        else
        {
            myRecord += Time.deltaTime;
            record.text = "Record : " + myRecord.ToString("F3") ;
        }
    }
    void Run()
    {
        currentPosition = transform.position;
        CalculateSpeed();
        if (currentPosition.z >= rPoint1 && !isRotate && horseLocation["First"]) // 커브길 시작
        {
            horseLocation["First"] = false;
            horseLocation["Second"] = true;
            isRotate = true;
            isDiagonal = false;
            radius = Vector3.Distance(currentPosition, firstAxis);
            startPosition = currentPosition;
        }
        else if (currentPosition.z <= rPoint2 && !isRotate && horseLocation["Third"])
        {
            horseLocation["Third"] = false;
            horseLocation["Fourth"] = true;
            isRotate = true;
            isDiagonal = false;
            radius = Vector3.Distance(currentPosition, secondAxis);
            startPosition = currentPosition;

        }
        else if (isRotate && (horseLocation["Second"] || horseLocation["Fourth"]))
        {
            Rotate();
        }
        else if (currentPosition.z >= rPoint2 && currentPosition.z <= rPoint1 && horseLocation["First"]) // 직선 코스
        {
            if (photonView.IsMine)
            {
                if (isDiagonal) // 대각선 주행 
                {
                    transform.position = Vector3.MoveTowards(currentPosition,
                                                new Vector3(dRandom, currentPosition.y, rPoint1), 4.5f * resultSpeed * Time.deltaTime);
                }
                else if (currentPosition.z >= dPoint1 && !isDiagonal)
                {
                    isDiagonal = true;
                    dRandom = Random.Range(34f, (float)currentPosition.x);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(currentPosition,
                                                new Vector3(currentPosition.x, currentPosition.y, rPoint1), 5f * resultSpeed * Time.deltaTime);
                    rotateTime = 0;
                }
                ApplyRotate();
            }
            //animator.Play("Horse_Gallop");
            photonView.RPC("rpcAni", RpcTarget.AllBuffered, "Horse_Gallop");
        }
        else if (currentPosition.z >= rPoint2 && currentPosition.z <= rPoint1 && horseLocation["Third"])
        {
            if (photonView.IsMine)
            {
                if (isDiagonal)
                {
                    transform.position = Vector3.MoveTowards(currentPosition,
                                                new Vector3(dRandom, currentPosition.y, rPoint2), 4.5f * resultSpeed * Time.deltaTime);
                }
                else if (currentPosition.z <= dPoint2 && !isDiagonal)
                {
                    isDiagonal = true;
                    dRandom = -1f * Random.Range(4f, -1f * (float)currentPosition.x);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(currentPosition,
                                                new Vector3(currentPosition.x, currentPosition.y, rPoint2), 5f * resultSpeed * Time.deltaTime);
                    rotateTime = 0;
                    isHalf = true;
                }
                ApplyRotate();
            }
            //animator.Play("Horse_Gallop");
            photonView.RPC("rpcAni", RpcTarget.AllBuffered, "Horse_Gallop");
        }
        else if (horseLocation["Final"])
        {
            if (photonView.IsMine)
            {
                transform.position = Vector3.MoveTowards(currentPosition,
                                        finalPosition, 5f * resultSpeed * Time.deltaTime);
            }
            if (transform.position == finalPosition)
            {
                //animator.Play("Horse_Paw2");
                photonView.RPC("rpcAni", RpcTarget.AllBuffered, "Horse_Paw2");
            }
            else{
                //animator.Play("Horse_Trot");
                photonView.RPC("rpcAni", RpcTarget.AllBuffered, "Horse_Trot");
            }
        }
    }

    void ApplyConsis()
    {
        float consisValue = 0f;
        switch ((int)status.consis / 20)
        {
            case 0:
                consisValue = Random.Range(0.7f, 1.1f);
                break;

            case 1:
                consisValue = Random.Range(0.75f, 1.1f);
                break;

            case 2:
                consisValue = Random.Range(0.8f, 1.1f);
                break;

            case 3:
                consisValue = Random.Range(0.85f, 1.1f);
                break;

            case 4:
                consisValue = Random.Range(0.9f, 1.15f);
                break;
            case 5:
                consisValue = Random.Range(0.95f, 1.15f);
                break;
        }
        status.accel *= consisValue;
        status.agility *= consisValue;
        status.hp *= consisValue;
        status.speed *= consisValue;
        Debug.Log(status.speed);
    }
    void CalculateSpeed()
    {
        // status.accel;
        // status.agility;
        // status.consis;
        // status.hp;
        // status.speed;
        timeChecker += 10f * Time.deltaTime;
        if (horseLocation["First"])
        {
            resultSpeed = status.speed + (status.accel / 100) * timeChecker;
        }
        else if (horseLocation["Second"])
        {
            resultSpeed = status.speed + (status.accel / 100) * timeChecker;
            switch ((int)status.agility / 20)
            {
                case 0:
                    resultSpeed = resultSpeed * (0.5f * (status.agility / 20f));
                    break;

                case 1:
                    resultSpeed = resultSpeed * (0.3f * (status.agility / 20f));
                    break;

                case 2:
                    resultSpeed = resultSpeed * (0.233f * (status.agility / 20f));
                    break;

                case 3:
                    resultSpeed = resultSpeed * (0.2f * (status.agility / 20f));
                    break;

                case 5:
                case 4:
                    resultSpeed = resultSpeed * (0.19f * (status.agility / 20f));
                    break;
            }
        }
        else if (horseLocation["Third"])
        {
            if (((100 - status.hp) / 100f * timeChecker) <= status.speed / 2f)
                resultSpeed = status.speed - ((100 - status.hp) / 100f * timeChecker);
            else if (((100 - status.hp) / 100f * timeChecker) > status.speed / 2f)
                resultSpeed = status.speed / 2f;
        }
        else if (horseLocation["Fourth"])
        {
            if (((100 - status.hp) / 100f * timeChecker) <= status.speed / 2f)
                resultSpeed = status.speed - ((100 - status.hp) / 100f * timeChecker);
            else if (((100 - status.hp) / 100f * timeChecker) > status.speed / 2f)
                resultSpeed = status.speed / 2f;

            switch ((int)status.hp / 20)
            {
                case 0:
                    resultSpeed = resultSpeed * (0.5f * (status.agility / 20f));
                    break;

                case 1:
                    resultSpeed = resultSpeed * (0.3f * (status.agility / 20f));
                    break;

                case 2:
                    resultSpeed = resultSpeed * (0.233f * (status.agility / 20f));
                    break;

                case 3:
                    resultSpeed = resultSpeed * (0.2f * (status.agility / 20f));
                    break;

                case 5:
                case 4:
                    resultSpeed = resultSpeed * (0.19f * (status.agility / 20f));
                    break;
            }
        }
        if(isCollide)
            resultSpeed = 0.7f * ((resultSpeed) / 10f) + 1f;
        else
            resultSpeed = ((resultSpeed) / 10f) + 1f;
    }
    void Rotate()
    {
        if (photonView.IsMine)
        {
            Vector3 currentPosition = transform.position;

            if (horseLocation["Second"])
            {
                rotateTime += resultSpeed * Time.deltaTime * 0.3f;
                rotateX = radius * Mathf.Cos(rotateTime);
                rotateZ = radius * Mathf.Sin(-rotateTime);
                transform.position = new Vector3(firstAxis.x + rotateX, startPosition.y, (firstAxis.z - rotateZ));
                if (transform.position.z <= rPoint1 && !isHalf)
                {
                    isRotate = false;
                    isHalf = true;
                    horseLocation["Second"] = false;
                    horseLocation["Third"] = true;
                    timeChecker = 0f;
                    lookDirection = new Vector3(0f, 0f, 0f);
                }
            }
            else if (horseLocation["Fourth"])
            {
                rotateTime += resultSpeed * Time.deltaTime * 0.3f;
                rotateX = radius * Mathf.Cos(-rotateTime);
                rotateZ = radius * Mathf.Sin(-rotateTime);
                transform.position = new Vector3((secondAxis.x - rotateX), startPosition.y, (secondAxis.z + rotateZ));
                if (transform.position.z >= rPoint2 && isHalf)
                {
                    isRotate = false;
                    isHalf = false;
                    horseLocation["Fourth"] = false;
                    horseLocation["Final"] = true;
                    timeChecker = 0f;
                    finalPosition = new Vector3(currentPosition.x, currentPosition.y, Random.Range(6.0f, 25.0f));
                    lookDirection = new Vector3(0f, 0f, 0f);
                }
            }
            Vector3 currentRotation = transform.eulerAngles;
            // lookDirection = (transform.position -currentPosition);
            // transform.rotation = Quaternion.LookRotation(lookDirection);   
            ApplyRotate();
            changeRotation = -currentRotation + transform.eulerAngles;
        }
        //animator.Play("Horse_Canter");
        photonView.RPC("rpcAni", RpcTarget.AllBuffered, "Horse_Canter");
    }
    [PunRPC]
    void rpcAni(string strAni)
    {
        if (animator != null)
            animator.Play(strAni);
    }
    void ApplyRotate()
    {
        lookDirection = -(transform.position - currentPosition);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookDirection), 5f * Time.deltaTime);
        //\\transform.rotation = Quaternion.LookRotation(lookDirection);  
    }
    void InputLocation()
    {
        horseLocation.Add("First", true);
        horseLocation.Add("Second", false);
        horseLocation.Add("Third", false);
        horseLocation.Add("Fourth", false);
        horseLocation.Add("Final", false);
    }

    private void OnCollisionEnter(Collision collision)
    {

       // 이 컴포넌트가 부착된 게임 오브젝트의 콜라이더와 충돌한 게임 오브젝트 가져오기

        leadHorse = collision.gameObject;

        // 특정 컴포넌트 가져오기

        leadStatus = collision.gameObject.GetComponent<HorseStatus>();

        // 콜라이더 가져오기

        var collider = collision.collider;

    }

 

    // Collider 컴포넌트의 is Trigger가 false인 상태로 충돌중일 때

    private void OnCollisionStay(Collision collision)
    {
        if(horseLocation["First"])
        {
            if( currentPosition.z <= leadStatus.currentPosition.z )
            {
                
                isCollide = true;
            }
        }
        else if(horseLocation["Second"])
        {
            if( currentPosition.x >= leadStatus.currentPosition.x )
            {
                isCollide = true;
            }
        }
        else if(horseLocation["Third"])
        {
            if( currentPosition.z >= leadStatus.currentPosition.z )
            {
                isCollide = true;
            }
        }
        else if(horseLocation["Fourth"])
        {
            if( currentPosition.x <= leadStatus.currentPosition.x )
            {
                isCollide = true;
            }
        }
        if(horseLocation["Final"])
        {
            if( currentPosition.z <= leadStatus.currentPosition.z )
            {
                
                isCollide = true;
            }
        }
    }

 

    // Collider 컴포넌트의 is Trigger가 false인 상태로 충돌이 끝났을 때

    private void OnCollisionExit(Collision collision)
    {
        isCollide = false;

    }
}