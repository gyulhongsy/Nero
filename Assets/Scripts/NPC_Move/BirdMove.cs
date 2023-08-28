using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    Boolean isFlying = false;   // �� �� �ִ��� Ȯ�� ����

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isFlying)   // ���� ���� true�� ����
        {
            if (transform.position.x < 40)
            {
                transform.Translate(new Vector3(0.02f, 0.02f, 0), Space.Self);
                anim.SetBool("isBirdFlying", true);
               
            }
        }
    }

    void FixedUpdate()  
    {
        // player ���̾ ������ �� �� ����
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, 1, LayerMask.GetMask("Player"));
        if (rayHit.collider != null)
        {
            
            if (rayHit.distance < 7.5f)
            {
                Debug.Log("�� ���ư�");
               
                isFlying = true;    // ���� ���� true
                AudioSource flying = GetComponent<AudioSource>();
                flying.Play();

            }

        }
    }
}
