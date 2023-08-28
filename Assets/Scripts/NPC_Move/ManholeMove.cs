using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeMove : MonoBehaviour
{
    float timer = 0;    // Ÿ�̸�
    public GameObject manhole;  // ��Ȧ ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Truncate(transform.position.y) < 10)   // y�� 10���� �̵�
        {
            transform.Translate(new Vector3(0, 0.06f, 0), Space.Self);
        }
        else    // y�� 10���� ���� �� ��Ȱ��ȭ
        {
            manhole.SetActive(false);
        }
    }
}
