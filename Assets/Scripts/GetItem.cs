using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    GameObject item; //아이템 오브젝트
    GameObject player;  // 플레이어 오브젝트
    public GameObject itemTalk;     // 자판기 명령어

    Boolean getItem = false;    // 아이템 가져갔는지 여부

    void Start()
    {
        player = GameObject.Find("Player");
        item = GameObject.FindWithTag("Item");
        item.SetActive(false);
    }

    void Update()
    {
        // 자판기 근처인지, 아이템 안가져갔는지 확인
        if (gameObject.transform.position.x - 2 <= player.transform.position.x && player.transform.position.x <= gameObject.transform.position.x + 2)
        {

            if (getItem == false)
            {
                itemTalk.SetActive(true);
                
            }

        }
        else
        {
            itemTalk.SetActive(false);
            
        }
    }

    private void OnMouseDown()
    {
        AudioSource itemget = GetComponent<AudioSource>();
        itemget.Play();
        Debug.Log("아이템 획득");
        item.SetActive(true);
        getItem = true;
        itemTalk.SetActive(false);
    }
}
