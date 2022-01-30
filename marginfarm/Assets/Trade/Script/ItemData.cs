using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static ItemData instance;
    private void Awake()
    {
        instance = this;
    }
    public List<SellItem> itemDB = new List<SellItem>();
}
