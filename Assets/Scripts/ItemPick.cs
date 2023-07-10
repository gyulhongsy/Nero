using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPick : MonoBehaviour
{
    public bool itemFlag = false;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("아이템에 닿음");
            itemFlag = true;
        }
    }

    void Update()
    {
        if (itemFlag && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            itemFlag = false;
        }
    }
}
