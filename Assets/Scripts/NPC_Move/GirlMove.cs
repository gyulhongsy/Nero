using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GirlMove : MonoBehaviour
{
    SpriteRenderer rend;
    GameObject obj;     // ���ھ��� ���� ������Ʈ ����
    Boolean girlComeOut = false;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        obj = GameObject.Find("GirlMom");   // ������Ʈ ������ ���ھ��� ���� ������Ʈ ã��
        girlComeOut = obj.GetComponent<GirlParentMove>().comeOut;   // ����� ���� ����
    }

    void Update()
    {
        girlComeOut = obj.GetComponent<GirlParentMove>().comeOut;   // ����� ���� ����

        if (girlComeOut)    // ����� �����ϸ� ���̵� �ƿ� ����
        {
            StartCoroutine("FadeOut");
            girlComeOut = false;
        }
    }
    IEnumerator FadeOut()   // ���̵� �ƿ�
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

}
