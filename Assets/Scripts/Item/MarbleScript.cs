using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleScript : MonoBehaviour
{
    Animator anim;

    GameObject warmHole;     // 웜홀
    GameObject marble;      // 합친 구슬
    GameObject marble1;     //조각 구슬1
    GameObject marble2;     // 조각 구슬2
    public GameObject storeCatEvent;    // 헤롱거리는 상점아줌마
    public GameObject invenMarble1;     // 인벤에 있는 구슬조각1 
    public GameObject invenMarble;     // 인벤에 있는 구슬조각  


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
            anim.SetBool("isTaken", true);  // 상점아줌마로부터 구슬조각2 가져감
            Debug.Log(timer + "구슬조각1");
        }
        if (Math.Truncate(timer) == 2)
        {
            marble2.SetActive(true);
            Debug.Log(timer + "구슬조각2");
        }
        if (Math.Truncate(timer) == 3)
        {
            Debug.Log(timer + "구슬 합침");
            marble1.SetActive(false);
            marble2.SetActive(false);
            marble.SetActive(true);
        }
        if (Math.Truncate(timer) == 4)
        {
            marble.SetActive(false);
            invenMarble.SetActive(true);
            Debug.Log(timer + "구슬 사라짐");
            warmHole.SetActive(true);   // 웜홀 나타남
        }
    }
}
