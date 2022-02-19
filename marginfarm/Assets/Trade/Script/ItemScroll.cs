using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScroll : MonoBehaviour
{
    public bool isclick = false;
    public GameObject item;
    public GameObject content;
    //public GameObject noitem;
    public int yPos = 0;
    // Start is called before the first frame update
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void isenrolled(){
        //noitem.gameObject.SetActive(false);
        var node = Instantiate(item,content.transform);
        node.transform.SetParent(GameObject.Find("content").transform);
        yPos -= 115;       
    }
}
