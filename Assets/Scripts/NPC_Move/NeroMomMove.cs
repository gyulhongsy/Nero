using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeroMomMove : MonoBehaviour
{
    float timer = 0;    // Ÿ�̸�
    Boolean goToNero = false;   // �׷ο��� ������ ���� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;    

        if (Math.Truncate(timer) == 2)  // 2�� ������
            goToNero = true;    // �׷ο��� ���� ��

        if (goToNero)   // �׷ο��� ���� ���̸�
        {
            if (Math.Truncate(transform.position.x) > -5)   // x������ -5���� �̵�
            {
                transform.Translate(new Vector3(-0.005f, 0, 0), Space.Self);
            }
            else // ���� ��
            {
                goToNero = false; //�׷ο��� ���� ����
            }
        }

    }
}
