using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCatMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Collider2D collider;

    public GameObject nero;     // 네로 오브젝트
    GameObject storeCatEvent;   // 쓰러진 상점 아줌마
    GameObject bomb3;

    public Boolean neroButtonOn = false;    // 네로 마지막 폭탄 눌렀는지 여부
    public int chaseStart = 0;      // 네로 잡으러 가는지 여부 0: 시작 안함, 1: 시작
    public Boolean chaseLeft = false;   // 발판 2층 왼쪽으로 이동 여부 변수
    public Boolean chaseRignt = false;  //발판 맨 아래 오른쪽 이동 여부 변수

    void Start()
    {
        bomb3 = GameObject.Find("bomb3");
        bomb3.SetActive(false);
        storeCatEvent = GameObject.Find("storeCat event");
        storeCatEvent.SetActive(false);     // 쓰러진 상점 아줌마 비활성화
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
        if(chaseStart == 1)     // 네로 잡으러 가기 시작
        {
            collider.isTrigger = false;     // 충돌 일어나게 함
            rigid.constraints = RigidbodyConstraints2D.None;    //y축 고정 해제
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;  // z축 고정
            nero.transform.position = new Vector3(21f, -4.5f, 0);   // 네로 2층으로 이동
            chaseStart += 1;    // 시작했으니 변수 바꿈
            if (transform.position.y >= 0.5f)   
            {
                transform.position = new Vector3(26f, -4.5f, 0);    // 상점 아줌마 2층으로
                chaseLeft  = true;  //왼쪽 잡으러 가기
            }
        }

        if(chaseLeft)   // 왼쪽 잡는거 참일 때
        {
            if (Math.Truncate(transform.position.x) > -5)   // x축 -5까지 이동
            {
                transform.Translate(new Vector3(-0.05f, 0, 0), Space.Self);
            }
            else    // x축 -5까지 도착
            {
                chaseLeft = false;  // 왼쪽 잡으러 가기 끝
                if(transform.position.y <= 7.5f)
                    chaseRignt = true;  // 오른쪽으로 잡으러 가기 시작
            }
        }

        if (chaseRignt) // 오른쪽으로 잡는거 참일 때
        {
            if (neroButtonOn)   //폭탄 버튼 눌렀을 때
            {
                if (Math.Truncate(transform.position.x) <= -1)  // x축 -1까지 이동
                {
                    transform.Translate(new Vector3(0.05f, 0, 0), Space.Self);
                }
                else    // x축 -1 도착
                {
                    chaseRignt = false;     //오른쪽 이동 멈춤
                    collider.isTrigger = true;  //네로와 충돌 멈춤
                    rigid.constraints = RigidbodyConstraints2D.FreezePositionY; // y축 고정
                    gameObject.SetActive(false);    // 움직이던 캣닢아줌마 비활성화
                    storeCatEvent.SetActive(true);  // 쓰러진 캣닢아줌마 활성화
                }
                //neroButtonOn = false;
            }
            else
            {
                transform.Translate(new Vector3(0.05f, 0, 0), Space.Self);
            }
        }

        if (0.5f < nero.transform.position.x && nero.transform.position.x < 1.5f)   // 네로 폭탄버튼 지나는 위치 감지
        {
            if (nero.transform.position.y <= -7.5f)
            {
                Debug.Log("마지막 폭탄 펑");
                neroButtonOn = true;    // 폭탄 터짐 참
                bomb3.SetActive(true);
            }
        }

    }
}
