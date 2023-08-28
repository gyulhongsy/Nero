using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GirlParentMove : MonoBehaviour
{
    SpriteRenderer rend;
    public Boolean comeIn = false;      // �θ�� ���� ���� ���� ����
    public Boolean comeOut = false;     // ����� ���� ���� ����
    //Boolean girlComeOut = false;

    void Start()
    {
        // ���� �� ����
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
    }

    void Update()
    {
        if (comeIn) // ���� ���� ��
        {
            StartCoroutine("FadeIn");
            comeIn = false;     // ���� �� ���� �ٲ�
            //comeOut = true;
        }

        if (comeOut)    // ����� ���� ��
        {
            StartCoroutine("FadeOut");
            comeOut = false;    // ����� �� ���� �ٲ�
        }
    }

    IEnumerator FadeOut()
    {
        for(float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        comeOut = true; // ����� ����
    }
}
