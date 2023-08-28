using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyCatMove6 : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Collider2D collider;

    public GameObject nero;
    
    public Boolean neroButtonOn2 = false;
    public int chaseStart = 0;
    public Boolean chaseLeft = false;

    void Start()
    {
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
            anim.SetBool("isCatRun", true);     // �޸��� �ִϸ��̼� ����
            collider.isTrigger = false;
            //nero.transform.position = new Vector3(21f, -4.5f, 0);
            chaseStart += 1;
            if (transform.position.y >= 0.5f)
            {
                transform.position = new Vector3(31f, -4.5f, 0);
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
                    anim.SetBool("isCatRun", false);    // �޸��� �ִϸ��̼� ��
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
                Debug.Log("�ι�° ��ź ��");
                neroButtonOn2 = true;
            }
        }

    }
}
