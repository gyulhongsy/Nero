using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class EventManager : MonoBehaviour
{
    GameObject bag; //°¡¹æ ¿ÀºêÁ§Æ®
    GameObject girlMom;    // ¿©ÀÚ¾ÆÀÌ¾ö¸¶ ¿ÀºêÁ§Æ®
    GameObject storeCat;    // »óÁ¡ ¾ÆÁÜ¸¶
    GameObject cat1; // Ä¹ÀÙ °í¾çÀÌ1
    GameObject cat2; // Ä¹ÀÙ °í¾çÀÌ2
    GameObject cat3; // Ä¹ÀÙ °í¾çÀÌ3
    GameObject cat4; // Ä¹ÀÙ °í¾çÀÌ4
    GameObject cat5; // Ä¹ÀÙ °í¾çÀÌ5
    GameObject cat6; // Ä¹ÀÙ °í¾çÀÌ6

    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "NeroHouse":
                // scene1
                bag = GameObject.Find("item");
                bag.SetActive(false);
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
                break;
        }

    }

    public void addBag()
    {
        Debug.Log("°¡¹æ È¹µæ");
        bag.SetActive(true);
    }

    public void girlParent()
    {
        Debug.Log("¿©ÀÚ¾ÆÀÌ »ç¶óÁü");
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
}
