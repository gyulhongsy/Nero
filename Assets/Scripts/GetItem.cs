using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    GameObject item; //æ∆¿Ã≈€ ø¿∫Í¡ß∆Æ

    void Start()
    {
        item = GameObject.FindWithTag("Item");
        item.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("æ∆¿Ã≈€ »πµÊ");
            item.SetActive(true);
        }
    }

    //test code
    private void OnMouseDown()
    {
        Debug.Log("æ∆¿Ã≈€ »πµÊ");
        item.SetActive(true);
    }
}
