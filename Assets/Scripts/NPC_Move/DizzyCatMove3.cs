using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyCatMove3 : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim; 
    Collider2D collider;

    public GameObject nero;
    GameObject bomb1;   // 두번째 폭탄
    
    public Boolean neroButtonOn2 = false;
    public int chaseStart = 0;
    public Boolean chaseLeft = false;

    void Start()
    {
        bomb1 = GameObject.Find("bomb1");
        bomb1.SetActive(false);
        //chaseStart = 1;
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if (chaseStart == 1)
        {
            anim.SetBool("isCatRun", true);     // 달리는 애니메이션 시작
            collider.isTrigger = false;
            //nero.transform.position = new Vector3(21f, -4.5f, 0);
            chaseStart += 1;
            if (transform.position.y >= 0.5f)
            {
                transform.position = new Vector3(27.5f, -4.5f, 0);
                chaseLeft = true;
            }
        }

        if (chaseLeft)
        {
            if (neroButtonOn2)
            {
                if (Math.Truncate(transform.position.x) >= 4.5)
                {
                    transform.Translate(new Vector3(-0.05f, 0, 0), Space.Self);
                }
                else
                {
                    chaseLeft = false;
                    collider.isTrigger = true;
                    anim.SetBool("isCatRun", false);    // 달리는 애니메이션 끝
                }
            }
            else
            {
                transform.Translate(new Vector3(-0.05f, 0, 0), Space.Self);
            }
        }

        if (2f < nero.transform.position.x && nero.transform.position.x < 3f)
        {
            if (nero.transform.position.y <= -2.5f)
            {
                Debug.Log("두번째 폭탄 펑");
                neroButtonOn2 = true;
                bomb1.SetActive(true);
            }
        }

    }
}
