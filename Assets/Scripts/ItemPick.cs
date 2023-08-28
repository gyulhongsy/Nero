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
            Debug.Log("�����ۿ� ����");
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
