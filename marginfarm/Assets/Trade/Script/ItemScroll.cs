using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScroll : MonoBehaviour
{
    public int list = 10;
    public bool isclick = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        createitem();
    }

    public void createitem() {
        if(isclick == true)
        {
            int y = 0;
            for(int i = 0; i<list; i++)
            {
                //var node = Instantiate(item,new Vector3(0,y,0),Quaternion.identity);
                //node.transform.SetParent(GameObject.Find("content").transform);
                y -= 115;
            }
            isclick = false;
        }
    }
}
