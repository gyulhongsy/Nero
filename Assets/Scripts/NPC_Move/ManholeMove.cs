using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManholeMove : MonoBehaviour
{
    float timer = 0;    // 타이머
    public GameObject manhole;  // 맨홀 오브젝트

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Truncate(transform.position.y) < 10)   // y축 10으로 이동
        {
            transform.Translate(new Vector3(0, 0.06f, 0), Space.Self);
        }
        else    // y축 10으로 도착 시 비활성화
        {
            manhole.SetActive(false);
        }
    }
}
