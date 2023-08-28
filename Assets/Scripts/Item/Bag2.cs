using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bag2 : MonoBehaviour
{
    public GameObject bag;

    public GameObject hangover;
    public GameObject drink;

    public GameObject invenHangover;
    public GameObject invenDrink;

    public void BagOpen()   // ���� ���� 
    {
        bag.SetActive(true);
        if (hangover.GetComponent<Item_Pick>().pick == true)
            if (invenHangover.GetComponent<GiveItem>().finishH == false)
                invenHangover.gameObject.SetActive(true);

        if (drink.GetComponent<Item_Pick>().pick == true)
            if (invenDrink.GetComponent<GiveItem>().finishD == false)
                invenDrink.gameObject.SetActive(true);

        Debug.Log("���� ����");
    }

    public void BagClose()  // ���� �ݱ�
    {
        bag.SetActive(false);
        Debug.Log("���� �ݱ�");
    }

}
