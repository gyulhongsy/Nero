using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spaceMove : MonoBehaviour
{
    public float speed;
    public GameObject canvas;

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

    public DialogueManager manager;
    public EventDialogue eventDialogue;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    
    }

    void Start()
    {
        eventDialogue.StartEvent(3, "space");
    }
    
    void Update()
    {
       // h = Input.GetAxisRaw("Horizontal");
       if (manager.isAction == false)
            v = Input.GetAxisRaw("Vertical") + up_Value + down_Value;
       

    }


    void FixedUpdate()
    {
        if (transform.position.x < 57)  //�׷� ������ �̵�
        {
            rigid.velocity = new Vector2(0.8f, v) * speed;   
            if(transform.position.x > 54)
            {
                canvas.SetActive(false);
            }
        }
        else  // �׷� ����
        {
            rigid.velocity = new Vector2(0, v);
            SceneManager.LoadScene("CatPlanet");
        }

    }

    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 1;
                AudioSource up = GetComponent<AudioSource>();
                up.Play();
                //up_down = true;
                break;
            case "D":
                down_Value = -1;
                AudioSource down = GetComponent<AudioSource>();
                down.Play();
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
                AudioSource up = GetComponent<AudioSource>();
                up.Play();
                //up_Up = true;
                break;
            case "D":
                down_Value = 0;
                AudioSource down = GetComponent<AudioSource>();
                down.Play();
                //down_Up = true;
                break;
        }
    }
}
