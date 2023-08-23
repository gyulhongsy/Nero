using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bag1 : MonoBehaviour
{
    public Boolean isBagOpen = false;

    public GameObject bagObj;
    public GameObject bagButton;
    public GameObject bag;
    

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
            Debug.Log("가방 열기");
        }
    }
}
