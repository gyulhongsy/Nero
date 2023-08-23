using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GiveItem : MonoBehaviour, IPointerClickHandler
{
    public DialogueManager manager;

    public GameObject player;   // �׷� ������Ʈ
    public GameObject bagInven;      // ���� �κ��丮
    public GameObject bag;          // ���� ��ư
    public GameObject ivenHangover;     // �κ��丮 ������
    public GameObject ivenDrink;        // �κ��丮 ����
    public GameObject invenMarble1;     // �κ��丮 ��������1

    public Boolean giveH = false;       // ������ ���� ���� ����
    public Boolean finishH = false;     // ������ ���� �Ϸ� ����
    public Boolean giveD = false;       // ���� ���� ���� ����
    public Boolean finishD = false;     // ���� ���� �Ϸ� ����

    void Start()
    {
        
    }

    void Arrive()   // ������ or ���ھ��̿��� ���� �� �Լ�
    {
        // ������ ��ġ�� ���� �� ������ ���� ����
        if(-1.5f <= player.transform.position.x && player.transform.position.x <= 0.5f)
        {
            if(player.transform.position.y <= 2f)
            {
                Debug.Log("������ ����");
                giveH = true;

            }
        }
        else
        {
            giveH = false;
        }

        // ���ھ��� ��ġ�� ���� �� ���� ���� ����
        if (62.5f <= player.transform.position.x && player.transform.position.x <= 64.5f)
        {
            if (player.transform.position.y <= 3f)
            {
                Debug.Log("���ھ��� ����");
                giveD = true;

            }
        }
        else
        {
            giveD = false;
        }
    }

    void Update()
    {
        Arrive();
    }


    public void OnPointerClick(PointerEventData eventData)  // ��ġ �̺�Ʈ �Լ�
    {

        if (giveH)  // ������ ���� ����
        {
            Debug.Log("������ �ֱ�");
            finishH = true;     // ������ ��
            invenMarble1.SetActive(true);   // �������� 1 ����
            ivenHangover.SetActive(false);  // ������ ����� 
            bag.GetComponent<Bag2>().isBagOpen = false;     // ���� ���� Ȯ�� ���� false
            bagInven.SetActive(false);   // ���� �κ��ݱ�
            manager.Action("mr.drunken event");
        }
        if (giveD)  // ���� ���� ����
        {
            Debug.Log("���� �ֱ�");
            finishD = true;     // ���� ��
            ivenDrink.SetActive(false); // ���� �����
            bag.GetComponent<Bag2>().isBagOpen = false;     // ���� ���� Ȯ�� ���� false
            bagInven.SetActive(false);   // ���� �κ��ݱ�
            manager.Action("missingGirl event");
        }
    }
}