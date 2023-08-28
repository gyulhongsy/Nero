using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class EventManager : MonoBehaviour
{
    GameObject bag; //���� ������Ʈ
    GameObject catGroup;    // ����� ���� ������Ʈ
    GameObject girlMom;    // ���ھ��̾��� ������Ʈ
    GameObject storeCat;    // ���� ���ܸ�
    GameObject cat1; // Ĺ�� �����1
    GameObject cat2; // Ĺ�� �����2
    GameObject cat3; // Ĺ�� �����3
    GameObject cat4; // Ĺ�� �����4
    GameObject cat5; // Ĺ�� �����5
    GameObject cat6; // Ĺ�� �����6
    GameObject marbleGroup;     // ���� ���� �׷�

    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "NeroHouse":
                // scene1
                bag = GameObject.Find("item");
                bag.SetActive(false);
                catGroup = GameObject.Find("cats event");
                break;
            case "Chap12":
                // scene2
                girlMom = GameObject.Find("GirlMom");
                break;
            case "Chap3":
                // scene3
                storeCat = GameObject.Find("storeCat");
                cat1 = GameObject.Find("cat1");
                cat2 = GameObject.Find("cat2");
                cat3 = GameObject.Find("cat3");
                cat4 = GameObject.Find("cat4");
                cat5 = GameObject.Find("cat5");
                cat6 = GameObject.Find("cat6");
                marbleGroup = GameObject.Find("marbleGroup");
                break;
        }

    }

    public void addBag()
    {
        Debug.Log("���� ȹ��");
        bag.SetActive(true);
    }

    public void catsCome()
    {
        Debug.Log("����� ���� �ٰ���");
        catGroup.GetComponent<CatGroupMove>().catGroupWalk = true;
    }

    public void girlParent()
    {
        Debug.Log("���ھ��� �����");
        girlMom.GetComponent<GirlParentMove>().comeIn = true;
    }

    public void catChase()
    {
        storeCat.GetComponent<StoreCatMove>().chaseStart = 1;
        cat1.GetComponent<DizzyCatMove1>().chaseStart = 1;
        cat2.GetComponent<DizzyCatMove2>().chaseStart = 1;
        cat3.GetComponent<DizzyCatMove3>().chaseStart = 1;
        cat4.GetComponent<DizzyCatMove4>().chaseStart = 1;
        cat5.GetComponent<DizzyCatMove5>().chaseStart = 1;
        cat6.GetComponent<DizzyCatMove6>().chaseStart = 1;
    }
    public void combineMarble()
    {
        marbleGroup.GetComponent<MarbleScript>().combine = true;
    }
}
