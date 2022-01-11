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

    public HorseInfo[] UserHorse = new HorseInfo[]
    {
        new HorseInfo ("적토마", 2, 1, 15, 7, 100, 20, 50, 0, true),
        new HorseInfo ("", 0, 0, 15, 7, 100, 20, 50, 0, false),
        new HorseInfo ("", 0, 0, 15, 7, 100, 20, 50, 0, false),
        new HorseInfo ("", 0, 0, 15, 7, 100, 20, 50, 0, false),
        new HorseInfo ("", 0, 0, 15, 7, 100, 20, 50, 0, false),
        new HorseInfo ("", 0, 0, 15, 7, 100, 20, 50, 0, false),
    };

    void Awake()
    {
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
        }*/

        many = 1;

        instance = this;
    }
}

