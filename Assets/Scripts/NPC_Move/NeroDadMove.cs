using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeroDadMove : MonoBehaviour
{
    float timer = 0;    // 타이머
    Boolean goToNero = false;   // 네로에게 가기 여부 변수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Math.Truncate(timer) == 2)  // 2초 지났으면
            goToNero = true;    // 네로에게 가기 참

        if (goToNero) // 네로에게 가기 참일때
        {
            if (Math.Truncate(transform.position.x) > -4)   // x축 -4까지 이동
            {
                transform.Translate(new Vector3(-0.005f, 0, 0), Space.Self);
            }
            else  // x축 -4까지 도착
            {
                goToNero = false;   // 네로에게 가기 거짓
            }
        }

    }
}
