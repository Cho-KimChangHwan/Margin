using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HorseInfo
{
    public string name;
    public int key;
    public int level;
    public int speed;
    public int accel;
    public int hp;
    public int agility;
    public int consis;
    public int items;
    

    public HorseInfo (string name, int key, int level, int speed, int accel, int hp, int agility, int consis, int items)
    {
        this.name = name;
        this.key = key;
        this.level = level;
        this.speed = speed;
        this.accel = accel;
        this.hp = hp;
        this.agility = agility;
        this.consis = consis;
        this.items = items;
    }
   
}

public struct ItemInfo
{
    public int key;
    public int speed;
    public int accel;
    public int hp;
    public int agility;
    public int consis;


    public ItemInfo(int key, int speed, int accel, int hp, int agility, int consis)
    {
        this.key = key;
        this.speed = speed;
        this.accel = accel;
        this.hp = hp;
        this.agility = agility;
        this.consis = consis;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int many;  // 유저의 말 수
    public int itemMany; // 유저의 아이템 수
    public string Id;  // 유저 ID
    public int captain;  
    public int select;
    public bool gameStart;  // 게임스타드 유무파악
    public bool racingStart;

    public int money;
    public bool spec_check;
    public bool inven_check;

    public HorseInfo[] UserHorse = new HorseInfo[]
    {
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111)
    };

    public ItemInfo[] UserItem = new ItemInfo[]
{
        new ItemInfo (2, 0, 0, 0, 0, 0),
        new ItemInfo (20, 0, 0, 0, 0, 0),
        new ItemInfo (200, 0, 0, 0, 0, 0),
        new ItemInfo (-1, -1, -1, -1, -1, -1),
        new ItemInfo (-1, -1, -1, -1, -1, -1),
        new ItemInfo (-1, -1, -1, -1, -1, -1),
        new ItemInfo (-1, -1, -1, -1, -1, -1),
        new ItemInfo (-1, -1, -1, -1, -1, -1),
        new ItemInfo (-1, -1, -1, -1, -1, -1),
        new ItemInfo (-1, -1, -1, -1, -1, -1),
        new ItemInfo (-1, -1, -1, -1, -1, -1),
        new ItemInfo (-1, -1, -1, -1, -1, -1)
};

    void Awake()
    {
        many = 0;
        spec_check = false;
        captain = 0;
        select = 0;
        money = 3000;
        itemMany = 3;

        /*
        for (int i = 0; i > 6; i++)
        {
            if (UserHorse[i].alive == true)
            {
                many = i + 1;
            }
            else
            {
                break;
            }
        }
        */
        instance = this;
    }
}

