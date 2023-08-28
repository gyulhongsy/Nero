using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyCatMove1 : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Collider2D collider;

    public GameObject nero;     // �׷� ������Ʈ
    GameObject bomb2;   // ù��° ��ź
    
    public Boolean neroButtonOn1 = false;   // �׷� ù��° ��ź �������� ����
    public int chaseStart = 0;  // �׷� ������ ������ ���� 0: ���� ����, 1: ����
    public Boolean chaseLeft = false;   //���� �� �Ʒ� ������ �̵� ���� ����

    void Start()
    {
        bomb2 = GameObject.Find("bomb2");
        bomb2.SetActive(false);
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
        if (chaseStart == 1)    // �׷� ��°� ��
        {
            anim.SetBool("isCatRun", true);     // �޸��� �ִϸ��̼� ����
            collider.isTrigger = false; // �׷ο� �浹 �Ͼ�� ��
            AudioSource MEOW = GetComponent<AudioSource>();
            MEOW.Play();
            //nero.transform.position = new Vector3(21f, -4.5f, 0);
            chaseStart += 1;    // ���������� ���� �ٲ�
            if (transform.position.y >= 0.5f)
            {
                transform.position = new Vector3(25f, -4.5f, 0);
                chaseLeft = true;   // �������� ������ ����
            }
        }

        if (chaseLeft)  // ���� ��°� ���� ��
        {
            if (neroButtonOn1)  // ù��° ��ư ������ ��
            {
                if (Math.Truncate(transform.position.x) >= 8.5) // ù���� ��ź���� �̵�
                {
                    transform.Translate(new Vector3(-0.05f, 0, 0), Space.Self);
                }
                else // ��ź ������ ����
                {
                    chaseLeft = false;  // ���� �̵� ��
                    collider.isTrigger = true;  // �浹 ���ֱ�
                    anim.SetBool("isCatRun", false);    // �޸��� �ִϸ��̼� ��
                }
            }
            else    // ��� �̵�
            {
                transform.Translate(new Vector3(-0.05f, 0, 0), Space.Self);
            }
        }

        if (6f < nero.transform.position.x && nero.transform.position.x < 7f)   // �׷� ��ź��ư ������ ��ġ ����
        {
            if (nero.transform.position.y <= -2.5f)
            {
                Debug.Log("ù��° ��ź ��");
                neroButtonOn1 = true;   // ��ź ���� ��
                bomb2.SetActive(true);  // ��ź ���� ��Ÿ��
            }
        }

    }
}
