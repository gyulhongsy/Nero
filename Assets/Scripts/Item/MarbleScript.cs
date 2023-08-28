using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleScript : MonoBehaviour
{
    Animator anim;

    GameObject warmHole;     // ��Ȧ
    GameObject marble;      // ��ģ ����
    GameObject marble1;     //���� ����1
    GameObject marble2;     // ���� ����2
    public GameObject storeCatEvent;    // ��հŸ��� �������ܸ�
    public GameObject invenMarble1;     // �κ��� �ִ� ��������1 
    public GameObject invenMarble;     // �κ��� �ִ� ��������  


    float timer = 0;

    public Boolean combine = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = storeCatEvent.GetComponent<Animator>();
        warmHole = GameObject.Find("warmHole");
        warmHole.SetActive(false);
        marble = GameObject.Find("marble");
        marble.SetActive(false);
        marble1 = GameObject.Find("marble1");
        marble1.SetActive(false);
        marble2 = GameObject.Find("marble2");
        marble2.SetActive(false);
        //combine = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (combine)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
        }

        if (Math.Truncate(timer) == 1)
        {
            invenMarble1.SetActive(false);
            marble1.SetActive(true);
            anim.SetBool("isTaken", true);  // �������ܸ��κ��� ��������2 ������
            Debug.Log(timer + "��������1");
        }
        if (Math.Truncate(timer) == 2)
        {
            marble2.SetActive(true);
            Debug.Log(timer + "��������2");
        }
        if (Math.Truncate(timer) == 3)
        {
            Debug.Log(timer + "���� ��ħ");
            marble1.SetActive(false);
            marble2.SetActive(false);
            marble.SetActive(true);
        }
        if (Math.Truncate(timer) == 4)
        {
            marble.SetActive(false);
            invenMarble.SetActive(true);
            Debug.Log(timer + "���� �����");
            warmHole.SetActive(true);   // ��Ȧ ��Ÿ��
        }
    }
}
