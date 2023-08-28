using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    GameObject item; //������ ������Ʈ

    void Start()
    {
        item = GameObject.FindWithTag("Item");
        item.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("������ ȹ��");
            item.SetActive(true);
        }
    }

    //test code
    private void OnMouseDown()
    {
        AudioSource itemget = GetComponent<AudioSource>();
        itemget.Play();
        Debug.Log("������ ȹ��");
        item.SetActive(true);
    }
}
