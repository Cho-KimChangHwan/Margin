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
public struct WearingItem
{
    public int horse_num;
    public int item_key;
    public int speed;
    public int accel;
    public int hp;
    public int agility;
    public int consis;


    public WearingItem(int horse_num, int item_key, int speed, int accel, int hp, int agility, int consis)
    {
        this.horse_num = horse_num;
        this.item_key = item_key;
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

    public int mytern;

    public HorseInfo[] UserHorse = new HorseInfo[]
    {
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111),
        new HorseInfo ("", -1, -1, -1, -1, -1, -1, -1, 1111)
    };

    public int[] horse_items = new int[6];

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

    public WearingItem[] WearingItem = new WearingItem[]
{
        new WearingItem (0, 0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0, 0),
        new WearingItem (1, 0, 0, 0, 0, 0, 0),
        new WearingItem (1, 0, 0, 0, 0, 0, 0),
        new WearingItem (1, 0, 0, 0, 0, 0, 0),
        new WearingItem (1, 0, 0, 0, 0, 0, 0),
        new WearingItem (2, 0, 0, 0, 0, 0, 0),
        new WearingItem (2, 0, 0, 0, 0, 0, 0),
        new WearingItem (2, 0, 0, 0, 0, 0, 0),
        new WearingItem (2, 0, 0, 0, 0, 0, 0),
        new WearingItem (3, 0, 0, 0, 0, 0, 0),
        new WearingItem (3, 0, 0, 0, 0, 0, 0),
        new WearingItem (3, 0, 0, 0, 0, 0, 0),
        new WearingItem (3, 0, 0, 0, 0, 0, 0),
        new WearingItem (4, 0, 0, 0, 0, 0, 0),
        new WearingItem (4, 0, 0, 0, 0, 0, 0),
        new WearingItem (4, 0, 0, 0, 0, 0, 0),
        new WearingItem (4, 0, 0, 0, 0, 0, 0),
        new WearingItem (5, 0, 0, 0, 0, 0, 0),
        new WearingItem (5, 0, 0, 0, 0, 0, 0),
        new WearingItem (5, 0, 0, 0, 0, 0, 0),
        new WearingItem (5, 0, 0, 0, 0, 0, 0)
};

    void Awake()
    {
        many = 0;
        spec_check = false;
        inven_check = false;
        captain = 0;
        select = 0;
        money = 3000;
        itemMany = 3;
        horse_items[0] = 2222;

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

