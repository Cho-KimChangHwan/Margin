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
    public bool alive;

    public HorseInfo (string name, int key, int level, int speed, int accel, int hp, int agility, int consis, int items, bool alive)
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
        this.alive = alive;
    }
   
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int many;
    public int captain;
    public int select;
    public bool spec_check;

    public HorseInfo[] UserHorse = new HorseInfo[]
    {
        new HorseInfo ("조준영", 2, 1, 15, 7, 70, 20, 50, 0, true),
        new HorseInfo ("김형국", 0, 4, 16, 8, 80, 25, 51, 0, true),
        new HorseInfo ("서창희", 0, 7, 17, 9, 90, 30, 52, 0, true),
        new HorseInfo ("정지환", 0, 10, 18, 10, 100, 35, 53, 0, true),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 0, false),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 0, false),
    };

    void Awake()
    {
        many = 4;
        spec_check = false;
        captain = 0;
        select = 0;

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

