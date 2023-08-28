using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GiveItem : MonoBehaviour, IPointerClickHandler
{
    public EventDialogue eventDialogue;
    Animator anim;

    public GameObject player;   // �׷� ������Ʈ
    public GameObject bagInven;      // ���� �κ��丮
    public GameObject bag;          // ���� ��ư
    public GameObject ivenHangover;     // �κ��丮 ������
    public GameObject ivenDrink;        // �κ��丮 ����
    public GameObject invenMarble1;     // �κ��丮 ��������1
    public GameObject girl;     // ��� ���� ����

    public Boolean giveH = false;       // ������ ���� ���� ����
    public Boolean finishH = false;     // ������ ���� �Ϸ� ����
    public Boolean giveD = false;       // ���� ���� ���� ����
    public Boolean finishD = false;     // ���� ���� �Ϸ� ����


    void Arrive()   // ������ or ���ھ��̿��� ���� �� �Լ�
    {
        // ������ ��ġ�� ���� �� ������ ���� ����
        if(-4f <= player.transform.position.x && player.transform.position.x <= -2f)
        {
            if(player.transform.position.y <= 2f)
            {
                // Debug.Log("������ ����");
                giveH = true;

            }
        }
        else
        {
            giveH = false;
        }

        // ���ھ��� ��ġ�� ���� �� ���� ���� ����
        if (62f <= player.transform.position.x && player.transform.position.x <= 65f)
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
            //bag.GetComponent<Bag2>().isBagOpen = false;     // ���� ���� Ȯ�� ���� false
            bagInven.SetActive(false);   // ���� �κ��ݱ�

            eventDialogue.StartEvent(20, "mr.drunken event");
        }
        if (giveD)  // ���� ���� ����
        {
            Debug.Log("���� �ֱ�");
            finishD = true;     // ���� ��
            ivenDrink.SetActive(false); // ���� �����
            //bag.GetComponent<Bag2>().isBagOpen = false;     // ���� ���� Ȯ�� ���� false
            bagInven.SetActive(false);   // ���� �κ��ݱ�
            anim = girl.GetComponent<Animator>();
            anim.SetBool("isHappy", true);  // ���ھ��� ���� �ִϸ��̼�

            eventDialogue.StartEvent(9, "missingGirl event");
        }
    }
}
