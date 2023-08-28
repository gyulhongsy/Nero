using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAuto : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public GameObject playB;    // �̵� ��ư
    public GameObject momCat;   // �׷� ����
    public GameObject dadCat;   // �׷� �ƺ�

    public GameObject background1;  // ���� ���

    float timer = 0;
    Boolean chaseMouse = false; // �� �Ѵ� ����
    Boolean comeBack = false;   // �׷� ���ƿ��� ����

    void Start()
    {
        playB = GameObject.Find("Canvas");
        playB.SetActive(false);     // �̵� �Ⱥ��̰���
        momCat = GameObject.Find("momCat");
        dadCat = GameObject.Find("dadCat");
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);

        if (Math.Truncate(timer) == 2)  // �� ������ �� ����
            chaseMouse = true;

        if (chaseMouse)     // �� ���� ��
        {
            if (Math.Truncate(transform.position.x) > -17)  // x�� -17���� ����
            {
                transform.Translate(new Vector3(-0.01f, 0, 0), Space.Self);
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
                anim.SetBool("isAuto", true);
            }
            else    // x�� -17���� ������
            {
                chaseMouse = false;
                anim.SetBool("isAuto", false);
                momCat.SetActive(false);    // ���� �����
                dadCat.SetActive(false);    // �ƺ� �����
            }
        }

        if (Math.Truncate(timer) == 11) // 11�� ������ �׷� ���ƿ�
        {
            chaseMouse = false;
            comeBack = true;
            momCat.SetActive(false);    // ���� �����
            dadCat.SetActive(false);    // �ƺ� �����
        }

        if (comeBack)   // �׷� ���ƿ� ��
        {
            background1.SetActive(false);       // ���� ��� �����
            if (Math.Truncate(transform.position.x) < -2)   // x�� -2���� ����
            {
                //transform.Translate(Vector3.right * Time.deltaTime);
                transform.Translate(new Vector3(0.01f, 0, 0), Space.Self);
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 0;
                anim.SetBool("isAuto", true);
            }
            else // x�� -2���� ������
            {
                comeBack = false;
                playB.SetActive(true);      // �̵� ��Ÿ��
                anim.SetBool("isAuto", false);
            }
        }
    }
    void FixedUpdate()
    {
    }

}