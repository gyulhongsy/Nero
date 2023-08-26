using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAuto : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public GameObject playB;    // 이동 버튼
    public GameObject momCat;   // 네로 엄마
    public GameObject dadCat;   // 네로 아빠

    float timer = 0;
    Boolean chaseMouse = false; // 쥐 쫓는 변수
    Boolean comeBack = false;   // 네로 돌아오는 변수

    void Start()
    {
        playB = GameObject.Find("Canvas");
        playB.SetActive(false);     // 이동 안보이게함
        momCat = GameObject.Find("momCat");
        dadCat = GameObject.Find("dadCat");
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);

        if (Math.Truncate(timer) == 2)  // 초 지나면 쥐 따라감
            chaseMouse = true;

        if (chaseMouse)     // 쥐 따라갈 때
        {
            if (Math.Truncate(transform.position.x) > -17)  // x축 -17까지 가기
            {
                //transform.Translate(Vector3.left * Time.deltaTime);
                transform.Translate(new Vector3(-0.01f, 0, 0), Space.Self);
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
                anim.SetBool("isAuto", true);
            }
            else    // x축 -17까지 도착시
            {
                chaseMouse = false;
                anim.SetBool("isAuto", false);
                momCat.SetActive(false);    // 엄마 사라짐
                dadCat.SetActive(false);    // 아빠 사라짐
            }
        }

        if (Math.Truncate(timer) == 11) // 11초 지나면 네로 돌아옴
        {
            chaseMouse = false;
            comeBack = true;
            momCat.SetActive(false);    // 엄마 사라짐
            dadCat.SetActive(false);    // 아빠 사라짐
        }

        if (comeBack)   // 네로 돌아올 떄
        {
            if (Math.Truncate(transform.position.x) < -2)   // x축 -2까지 가기
            {
                //transform.Translate(Vector3.right * Time.deltaTime);
                transform.Translate(new Vector3(0.01f, 0, 0), Space.Self);
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 0;
                anim.SetBool("isAuto", true);
            }
            else // x축 -2까지 도착시
            {
                comeBack = false;
                playB.SetActive(true);      // 이동 나타남
                anim.SetBool("isAuto", false);
            }
        }
    }
    void FixedUpdate()
    {
    }

}