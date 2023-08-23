using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bag3 : MonoBehaviour
{
    public Boolean isBagOpen = false;
    
    public GameObject bag;

    public GameObject marble2;

    public GameObject invenmarble1;
    public GameObject invenmarble2;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void BagState()
    {
        if (isBagOpen)  //가방 닫기
        {
            isBagOpen = false;
            bag.SetActive(false);
            Debug.Log("가방 닫기");
        }
        else    // 가방 열기
        {
            isBagOpen = true;
            bag.SetActive(true);
            if (marble2.GetComponent<Item_Pick>().pick == true)
                invenmarble2.gameObject.SetActive(true);

            Debug.Log("가방 열기");
        }
    }
}
