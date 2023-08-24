using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class DialogueManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;

    GameObject bag; //°¡¹æ ¿ÀºêÁ§Æ®
    GameObject girlMom;    // ¿©ÀÚ¾ÆÀÌ¾ö¸¶ ¿ÀºêÁ§Æ®
    GameObject storeCat;    // »óÁ¡ ¾ÆÁÜ¸¶
    GameObject cat1; // Ä¹ÀÙ °í¾çÀÌ1
    GameObject cat2; // Ä¹ÀÙ °í¾çÀÌ2
    GameObject cat3; // Ä¹ÀÙ °í¾çÀÌ3
    GameObject cat4; // Ä¹ÀÙ °í¾çÀÌ4
    GameObject cat5; // Ä¹ÀÙ °í¾çÀÌ5
    GameObject cat6; // Ä¹ÀÙ °í¾çÀÌ6

    // public GameObject obj;
    public Text talkText;
    public Text talkerText;

    public bool isAction;
    public int talkIndex;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "NeroHouse")
        {
            // scene1
            bag = GameObject.Find("item");
            bag.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "Chap12")
        {
            // scene2
            girlMom = GameObject.Find("GirlMom");
        }
        if (SceneManager.GetActiveScene().name == "Chap3")
        {
            // scene3
            storeCat = GameObject.Find("storeCat");
            cat1 = GameObject.Find("cat1");
            cat2 = GameObject.Find("cat2");
            cat3 = GameObject.Find("cat3");
            cat4 = GameObject.Find("cat4");
            cat5 = GameObject.Find("cat5");
            cat6 = GameObject.Find("cat6");
        }
    }

    public void Action(string name)
    {
        isAction = true;
        talkPanel.SetActive(true);

        // ObjData objData = obj.GetComponent<ObjData>();

        switch (name)
        {
            case "house":
                Talk(100, 0);
                break;
            case "box":
                Talk(101, 0);
                break;
            case "cats event":
                Talk(110, 0);
                break;
            case "grandpaCat":
                Talk(120, 113);
                break;
            case "mr.drunken":
                Talk(210, 200);
                break;
            case "mr.drunken event":
                Talk(211, 0);
                break;
            case "missingGirl":
                Talk(310, 210);
                break;
            case "missingGirl event":
                Talk(311, 210);
                break;
            case "cats":
                Talk(410, 0);
                break;
            case "storeCat":
                Talk(420, 226);
                break;
        }


        talkPanel.SetActive(isAction);

    }

    public void Talk(int id, int talkerId)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        string talkerData = talkManager.GetTalker(talkerId);

        // scene2
        if (id == 311 && talkData == null)  // ¿©ÀÚ¾ÆÀÌ »ç¶óÁü
        {
            Debug.Log("¿©ÀÚ¾ÆÀÌ »ç¶óÁü");
            girlMom.GetComponent<GirlParentMove>().comeIn = true;
        }

        // scene3
        if (id == 420 && talkData == null)  // µµ¸Á°¡±â ½ÃÀÛ
        {
            storeCat.GetComponent<StoreCatMove>().chaseStart = 1;
            cat1.GetComponent<DizzyCatMove1>().chaseStart = 1;
            cat2.GetComponent<DizzyCatMove2>().chaseStart = 1;
            cat3.GetComponent<DizzyCatMove3>().chaseStart = 1;
            cat4.GetComponent<DizzyCatMove4>().chaseStart = 1;
            cat5.GetComponent<DizzyCatMove5>().chaseStart = 1;
            cat6.GetComponent<DizzyCatMove6>().chaseStart = 1;
        }

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }


        StartCoroutine(Typing(talkData));

        switch (id)
        {
            case 110:
                if (talkIndex == 1 || talkIndex == 7 || talkIndex == 9)
                    talkerText.text = talkManager.GetTalker(110);
                else if (talkIndex == 3 || talkIndex == 12)
                    talkerText.text = talkManager.GetTalker(111);
                else if (talkIndex == 5 || talkIndex == 10 || talkIndex == 14)
                    talkerText.text = talkManager.GetTalker(112);
                else
                    talkerText.text = talkerData;
                break;
            case 120:
                if ((talkIndex + 1) % 2 == 0)
                    talkerText.text = talkManager.GetTalker(0);
                else
                    talkerText.text = talkerData;

                if (talkIndex == 25)
                {
                    Debug.Log("°¡¹æ È¹µæ");
                    bag.SetActive(true);
                }
                break;
            case 210:
                if (talkIndex == 1)
                    talkerText.text = talkManager.GetTalker(0);
                else
                    talkerText.text = talkerData;
                break;
            case 211:
                if ((talkIndex + 1) % 2 == 0)
                    talkerText.text = talkManager.GetTalker(200);
                else
                    talkerText.text = talkerData;
                break;
            case 311:
                if ((talkIndex + 1) % 2 == 0)
                    talkerText.text = talkManager.GetTalker(0);
                else
                    talkerText.text = talkerData;
                break;
            case 410:
                switch(talkIndex)
                {
                    case 0:
                        talkerText.text = talkManager.GetTalker(220);
                        break;
                    case 1:
                        talkerText.text = talkManager.GetTalker(221);
                        break;
                    case 2:
                        talkerText.text = talkManager.GetTalker(222);
                        break;
                    case 3:
                        talkerText.text = talkManager.GetTalker(223);
                        break;
                    case 4:
                        talkerText.text = talkManager.GetTalker(224);
                        break;
                    case 5:
                        talkerText.text = talkManager.GetTalker(225);
                        break;
                }
                break;
            case 420:
                if ((talkIndex + 1) % 2 == 0)
                    talkerText.text = talkManager.GetTalker(0);
                else
                    talkerText.text = talkerData;
                break;
            case 700:
                if (talkIndex == 2)
                    talkerText.text = talkManager.GetTalker(300);
                else if (talkIndex == 4)
                    talkerText.text = talkManager.GetTalker(301);
                else if (talkIndex == 5)
                    talkerText.text = talkManager.GetTalker(302);
                else
                    talkerText.text = talkerData;
                break;
            default:
                talkerText.text = talkerData;
                break;
        }

        Debug.Log("talkIndex : " + talkIndex);


        isAction = true;
        talkIndex++;
    }

    IEnumerator Typing(string text)
    {
        talkText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            talkText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
