using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceMove : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigid;
    //float h;
    float v;
    
    //Mobile Key Var
    int up_Value;
    int down_Value;
/*    bool up_down;
    bool down_down;
    bool up_Up;
    bool down_Up;*/

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    
    }
    
    void Update()
    {
       // h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical") + up_Value + down_Value;

    }


    void FixedUpdate()
    {
        if (transform.position.x < 57)  //네로 오른쪽 이동
        {
            rigid.velocity = new Vector2(0.8f, v) * speed;   
        }
        else  // 네로 멈춤
        {
            rigid.velocity = new Vector2(0, v);  
        }

    }

    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 1;
                //up_down = true;
                break;
            case "D":
                down_Value = -1;
                //down_down = true;
                break;
        }
    }

    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 0;
                //up_Up = true;
                break;
            case "D":
                down_Value = 0;
                //down_Up = true;
                break;
        }
    }
}
