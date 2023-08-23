using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GirlMove : MonoBehaviour
{
    SpriteRenderer rend;
    GameObject obj;     // 여자아이 엄마 오브젝트 변수
    Boolean girlComeOut = false;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        obj = GameObject.Find("GirlMom");   // 오브젝트 명으로 여자아이 엄마 오브젝트 찾음
        girlComeOut = obj.GetComponent<GirlParentMove>().comeOut;   // 사라짐 여부 변수
    }

    void Update()
    {
        girlComeOut = obj.GetComponent<GirlParentMove>().comeOut;   // 사라짐 여부 변수

        if (girlComeOut)    // 사라짐 시작하면 페이드 아웃 시작
        {
            StartCoroutine("FadeOut");
            girlComeOut = false;
        }
    }
    IEnumerator FadeOut()   // 페이드 아웃
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
