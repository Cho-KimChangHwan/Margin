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


    public HorseInfo(string name, int key, int level, int speed, int accel, int hp, int agility, int consis, int items)
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
    public int item_key;
    public int speed;
    public int accel;
    public int hp;
    public int agility;
    public int consis;


    public WearingItem(int item_key, int speed, int accel, int hp, int agility, int consis)
    {
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
    public float fade_speed;

    public Texture[] hMats = new Texture[8];
    public int[] lineKey = new int[4];

    public GameObject[] back_item = new GameObject[10];
    public GameObject[] hat_item = new GameObject[10];
    public GameObject[] glasses_item = new GameObject[10];
    public GameObject[] shoes_item = new GameObject[10];

    public Sprite[] back_item_card = new Sprite[10];
    public Sprite[] hat_item_card = new Sprite[10];
    public Sprite[] glasses_item_card = new Sprite[10];
    public Sprite[] shoes_item_card = new Sprite[10];

    public string[] horsesLocation = new string[3];
    public Vector3[] horsesPosition = new Vector3[3];
    public bool[] horsesReady = new bool[3];
    public string ranking = "";
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
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0),
        new ItemInfo (0, 0, 0, 0, 0, 0)

    };

    public WearingItem[] WearingItem = new WearingItem[]
{
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0),
        new WearingItem (0, 0, 0, 0, 0, 0)
};

    void Awake()
    {
        many = 0;
        spec_check = false;
        inven_check = false;
        captain = 0;
        select = -1;
        money = 3000;
        itemMany = 0;
        fade_speed = 0.12f;

        instance = this;
    }
}

