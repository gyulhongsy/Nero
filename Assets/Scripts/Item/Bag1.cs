using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bag1 : MonoBehaviour
{
    public GameObject bag;

    public void BagOpen()   // ���� ����
    {
        bag.SetActive(true);
        Debug.Log("���� ����");
    }

    public void BagClose()  // ���� �ݱ�
    {
        bag.SetActive(false);
        Debug.Log("���� �ݱ�");
    }

}
