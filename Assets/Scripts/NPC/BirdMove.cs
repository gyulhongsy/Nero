using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    Rigidbody2D rigid;
    //Animator anim;

    Boolean isFlying = false;   // 날 수 있는지 확인 변수

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFlying)   // 날기 변수 true면 날기
        {
            if (transform.position.x < 40)
                transform.Translate(new Vector3(0.02f, 0.02f, 0), Space.Self);
        }
    }

    void FixedUpdate()  
    {
        // player 레이어에 맞으면 날 수 있음
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, 1, LayerMask.GetMask("Player"));
        if (rayHit.collider != null)
        {
            if (rayHit.distance < 7.5f)
            {
                Debug.Log("새 날아감");
                isFlying = true;    // 날기 변수 true
            }

        }
    }
}
