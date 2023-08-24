using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GirlParentMove : MonoBehaviour
{
    SpriteRenderer rend;
    public Boolean comeIn = false;      // 부모님 등장 가능 여부 변수
    public Boolean comeOut = false;     // 사라짐 가능 여부 변수
    //Boolean girlComeOut = false;

    void Start()
    {
        // 등장 전 투명
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
    }

    void Update()
    {
        if (comeIn) // 등장 가능 시
        {
            StartCoroutine("FadeIn");
            comeIn = false;     // 등장 끝 변수 바꿈
            //comeOut = true;
        }

        if (comeOut)    // 사라짐 가능 시
        {
            StartCoroutine("FadeOut");
            comeOut = false;    // 사라짐 끝 변수 바꿈
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
        comeOut = true; // 사라짐 가능
    }
}
