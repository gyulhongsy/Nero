using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public float jumpPower;
    //Mobile key var
    int left_Value;
    int right_Value;
    bool up_down;
    bool left_down;
    bool right_down;
    bool left_Up;
    bool right_Up;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //PC
        //Jump
        if (Input.GetButtonDown("Jump")) {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        //Stop Speed
        if (Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //Direction Sprite
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
        }

        //Moblie
        //Jump
        if (up_down) {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        //Stop Speed
        if (right_Up && left_Up) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //Direction Sprite
        if (left_down || right_down)
        {
            spriteRenderer.flipX = (right_Value + left_Value) == 1;
        }
        //Mobile Var Init
        up_down = false;
        left_down = false;
        right_down = false;
        left_Up = false;
        right_Up = false;
    }
    void FixedUpdate()
    {
        //PC
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Mobile
        //Move Speed
        h = right_Value + left_Value;
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if (rigid.velocity.x > maxSpeed) //Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }
    //Mobile
    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_down = true;
                break;
            case "L":
                left_Value = -1;
                left_down = true;
                break;
            case "R":
                right_Value = 1;
                right_down = true;
                break;
        }
    }
    public void ButtonUp(string type)
    {
        switch (type) {
            case "U":
                up_down = false;
                break;
            case "L":
                left_Value = 0;
                left_Up = true;
                break;
            case "R":
                right_Value = 0;
                right_Up = true;
                break;
        }
    }
}
