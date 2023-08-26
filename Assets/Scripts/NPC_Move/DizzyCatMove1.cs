using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyCatMove1 : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Collider2D collider;

    public GameObject nero;     // 네로 오브젝트
    GameObject bomb2;   // 첫번째 폭탄
    
    public Boolean neroButtonOn1 = false;   // 네로 첫번째 폭탄 눌렀는지 여부
    public int chaseStart = 0;  // 네로 잡으러 가는지 여부 0: 시작 안함, 1: 시작
    public Boolean chaseLeft = false;   //발판 맨 아래 오른쪽 이동 여부 변수

    void Start()
    {
        bomb2 = GameObject.Find("bomb2");
        bomb2.SetActive(false);
        //chaseStart = 1;
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if (chaseStart == 1)    // 네로 잡는거 참
        {
            anim.SetBool("isCatRun", true);     // 달리는 애니메이션 시작
            collider.isTrigger = false; // 네로와 충돌 일어나게 함
            //nero.transform.position = new Vector3(21f, -4.5f, 0);
            chaseStart += 1;    // 시작했으니 변수 바꿈
            if (transform.position.y >= 0.5f)
            {
                transform.position = new Vector3(25f, -4.5f, 0);
                chaseLeft = true;   // 왼쪽으로 잡으러 가기
            }
        }

        if (chaseLeft)  // 왼쪽 잡는거 참을 때
        {
            if (neroButtonOn1)  // 첫번째 버튼 눌렀을 때
            {
                if (Math.Truncate(transform.position.x) >= 8.5) // 첫번쨰 폭탄까지 이동
                {
                    transform.Translate(new Vector3(-0.05f, 0, 0), Space.Self);
                }
                else // 폭탄 도착시 멈춤
                {
                    chaseLeft = false;  // 왼쪽 이동 끝
                    collider.isTrigger = true;  // 충돌 없애기
                    anim.SetBool("isCatRun", false);    // 달리는 애니메이션 끝
                }
            }
            else    // 계속 이동
            {
                transform.Translate(new Vector3(-0.05f, 0, 0), Space.Self);
            }
        }

        if (6f < nero.transform.position.x && nero.transform.position.x < 7f)   // 네로 폭탄버튼 지나는 위치 감지
        {
            if (nero.transform.position.y <= -2.5f)
            {
                Debug.Log("첫번째 폭탄 펑");
                neroButtonOn1 = true;   // 폭탄 터짐 참
                bomb2.SetActive(true);  // 폭탄 터짐 나타남
            }
        }

    }
}
