using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    float timer = 0; 
    Boolean isRun = false;  // �� �̵� Ȯ�� ����

    public GameObject mouse;    // �� ������Ʈ

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        timer += Time.deltaTime;    // Ÿ�̸�

        if (Math.Truncate(timer) == 1)  // 1�� �Ǹ� �� �̵� ����
            isRun = true;

        if (isRun)  // �� �̵� ����
        {
            if (Math.Truncate(transform.position.x) > -18)  // x������ -18���� �̵� 
            {
                transform.Translate(new Vector3(-0.016f, 0, 0), Space.Self);
            }
            else    // x������ -18���� �̵� �Ϸ� ��
            {
                isRun = false;  // �̵� ����
                mouse.SetActive(false); // ������Ʈ �Ⱥ��̰� ��
            }
        }

    }
}
