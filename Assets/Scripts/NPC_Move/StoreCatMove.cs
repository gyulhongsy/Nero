using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCatMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Collider2D collider;

    public GameObject nero;     // �׷� ������Ʈ
    GameObject storeCatEvent;   // ������ ���� ���ܸ�
    GameObject bomb3;

    public Boolean neroButtonOn = false;    // �׷� ������ ��ź �������� ����
    public int chaseStart = 0;      // �׷� ������ ������ ���� 0: ���� ����, 1: ����
    public Boolean chaseLeft = false;   // ���� 2�� �������� �̵� ���� ����
    public Boolean chaseRignt = false;  //���� �� �Ʒ� ������ �̵� ���� ����

    void Start()
    {
        bomb3 = GameObject.Find("bomb3");
        bomb3.SetActive(false);
        storeCatEvent = GameObject.Find("storeCat event");
        storeCatEvent.SetActive(false);     // ������ ���� ���ܸ� ��Ȱ��ȭ
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
        if(chaseStart == 1)     // �׷� ������ ���� ����
        {
            anim.SetBool("isStoreCatRun", true);    // �޸��� �ִϸ��̼� ����
            collider.isTrigger = false;     // �浹 �Ͼ�� ��
            rigid.constraints = RigidbodyConstraints2D.None;    //y�� ���� ����
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;  // z�� ����
            nero.transform.position = new Vector3(21f, -4.5f, 0);   // �׷� 2������ �̵�
            chaseStart += 1;    // ���������� ���� �ٲ�
            if (transform.position.y >= 0.5f)   
            {
                transform.position = new Vector3(26f, -4.5f, 0);    // ���� ���ܸ� 2������
                chaseLeft  = true;  //���� ������ ����
            }
        }

        if(chaseLeft)   // ���� ��°� ���� ��
        {
            if (Math.Truncate(transform.position.x) > -5)   // x�� -5���� �̵�
            {
                transform.Translate(new Vector3(-0.05f, 0, 0), Space.Self);
            }
            else    // x�� -5���� ����
            {
                chaseLeft = false;  // ���� ������ ���� ��
                spriteRenderer.flipX = true;    // �̹��� x�� ���� ������
                if (transform.position.y <= 7.5f)
                    chaseRignt = true;  // ���������� ������ ���� ����
            }
        }

        if (chaseRignt) // ���������� ��°� ���� ��
        {
            if (neroButtonOn)   //��ź ��ư ������ ��
            {
                if (Math.Truncate(transform.position.x) <= -1)  // x�� -1���� �̵�
                {
                    transform.Translate(new Vector3(0.05f, 0, 0), Space.Self);
                }
                else    // x�� -1 ����
                {
                    chaseRignt = false;     //������ �̵� ����
                    collider.isTrigger = true;  //�׷ο� �浹 ����
                    rigid.constraints = RigidbodyConstraints2D.FreezePositionY; // y�� ����
                    gameObject.SetActive(false);    // �����̴� Ĺ�ؾ��ܸ� ��Ȱ��ȭ
                    storeCatEvent.SetActive(true);  // ������ Ĺ�ؾ��ܸ� Ȱ��ȭ
                }
                //neroButtonOn = false;
            }
            else
            {
                transform.Translate(new Vector3(0.05f, 0, 0), Space.Self);
            }
        }

        if (0.5f < nero.transform.position.x && nero.transform.position.x < 1.5f)   // �׷� ��ź��ư ������ ��ġ ����
        {
            if (nero.transform.position.y <= -7.5f)
            {
                Debug.Log("������ ��ź ��");
                neroButtonOn = true;    // ��ź ���� ��
                bomb3.SetActive(true);
            }
        }

    }
}
