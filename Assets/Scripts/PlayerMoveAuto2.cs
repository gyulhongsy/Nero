using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMoveAuto2 : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject nero;     // 네로 오브젝트

    Boolean goUp = false;   // 올라가는지 여부

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        goUp = true;    // 올라가기 참
    }

    // Update is called once per frame
    void Update()
    {

        if (goUp)   // 올라가기 참이면
        {
            if(Math.Truncate(transform.position.y) < 2)     // y축 4까지 이동
            {

                transform.Translate(new Vector3(0, 0.04f, 0), Space.Self);
                rigid.gravityScale = 0;
            }
            else  // y축 4까지 도착시 
            {
                goUp = false; // 올라가기 거짓
                rigid.gravityScale = 4; // 중력 다시 만듦
            }
        }

    }
}
