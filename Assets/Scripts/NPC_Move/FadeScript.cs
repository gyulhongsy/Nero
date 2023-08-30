using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    Image rend;
    public GameObject fadeObj;  // 페이드인/아웃용 오브젝트

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 시작 전 투명
        rend = GetComponent<Image>();
        Color c = rend.color;
        c.a = 0f;
        rend.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

/*        if (Math.Round(timer, 2) == 3)
        {
            StartCoroutine("FadeOut");
        }*/

        if (Math.Round(timer, 2) == 8)
        {
            StartCoroutine("FadeIn");
        }

    }

    IEnumerator FadeIn()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.005f)
        {
            Color c = rend.color;
            c.a = f;
            rend.color = c;
            yield return new WaitForSeconds(0.005f);
        }
        fadeObj.SetActive(false);
    }
    /*IEnumerator FadeOut()
    {
        for (float f = 0.05f; f <= 1; f += 0.005f)
        {
            Color c = rend.color;
            c.a = f;
            rend.color = c;
            yield return new WaitForSeconds(0.005f);
        }

    }*/
}