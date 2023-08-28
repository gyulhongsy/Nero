using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMoveAuto2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject nero;     // �׷� ������Ʈ

    Boolean goUp = false;   // �ö󰡴��� ����

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        goUp = true;    // �ö󰡱� ��
    }

    // Update is called once per frame
    void Update()
    {

        if (goUp)   // �ö󰡱� ���̸�
        {
            if(Math.Truncate(transform.position.y) < 4)     // y�� 4���� �̵�
            {

                transform.Translate(new Vector3(0, 0.04f, 0), Space.Self);
                rigid.gravityScale = 0;
            }
            else  // y�� 4���� ������ 
            {
                goUp = false; // �ö󰡱� ����
                rigid.gravityScale = 4; // �߷� �ٽ� ����
            }
        }

    }
}
