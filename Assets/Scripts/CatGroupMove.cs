using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGroupMove : MonoBehaviour
{
    Rigidbody2D rigid;

    Boolean catGroupWalk = false;
    public GameObject playB;

    void Start()
    {
        playB.SetActive(false);
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (catGroupWalk)
        {
            if (Math.Truncate(transform.position.x) > 3)
            {
                transform.Translate(new Vector3(-0.03f, 0, 0), Space.Self);
            }
            else
            {
                catGroupWalk = false;
                playB.SetActive(true);
            }
        }
    }
}
