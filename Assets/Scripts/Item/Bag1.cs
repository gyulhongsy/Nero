using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bag1 : MonoBehaviour
{
    public GameObject bag;

    public void BagOpen()   // 가방 열기
    {
        bag.SetActive(true);
        Debug.Log("가방 열기");
    }

    public void BagClose()  // 가방 닫기
    {
        bag.SetActive(false);
        Debug.Log("가방 닫기");
    }

}
