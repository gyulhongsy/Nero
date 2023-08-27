using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    float timer = 0; 
    Boolean isRun = false;  // 쥐 이동 확인 변수

    public GameObject mouse;    // 쥐 오브젝트

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        timer += Time.deltaTime;    // 타이머

        if (Math.Truncate(timer) == 1)  // 1초 되면 쥐 이동 시작
            isRun = true;

        if (isRun)  // 쥐 이동 시작
        {
            if (Math.Truncate(transform.position.x) > -18)  // x축으로 -18까지 이동 
            {
                transform.Translate(new Vector3(-0.016f, 0, 0), Space.Self);
            }
            else    // x축으로 -18까지 이동 완료 시
            {
                isRun = false;  // 이동 멈춤
                mouse.SetActive(false); // 오브젝트 안보이게 함
            }
        }

    }
}
