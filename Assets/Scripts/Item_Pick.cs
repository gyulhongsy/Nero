using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pick : MonoBehaviour
{
    public bool itemFlag; //아이템인지 아닌지 판단
    public bool pick; //아이템을 획득했는지 판단
    GameObject obj; //아이템 주는 오브젝트
    GameObject item; //아이템 오브젝트

    void Start()
    {
        itemFlag = false;
        pick = false;
        obj = GameObject.FindWithTag("GetItem");
        item = GameObject.FindWithTag("Item");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("아이템에 닿음");
            itemFlag = true;
        }
    }

    void Update()
    {
        if (itemFlag && (Input.touchCount > 0))
        {
            Debug.Log("아이템에 획득");
            //Destroy(gameObject);
            gameObject.SetActive(false);
            pick = true;
        }
    }

    //test code
    private void OnMouseDown()
    {
        if (itemFlag)
        {
            Debug.Log("아이템에 획득");
            //Destroy(gameObject);
            gameObject.SetActive(false);
            pick = true;
            itemFlag = false;
        }
    }
}
