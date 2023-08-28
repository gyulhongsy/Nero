using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TalkManager talkManager;
    public EventManager eventManager;

    public GameObject talkPanel;
    public Text talkText;
    public Text talkerText;
    private string talkData;
    private string talkerData;

    public bool isAction;
    public int talkIndex;

    Coroutine typingCoroutine;

    void Update()
    {
        if (isAction)
            if (Input.GetMouseButtonDown(0))
            {
                StopCoroutine(typingCoroutine);
                talkText.text = talkData;
                AudioSource textpanel = GetComponent<AudioSource>();
                textpanel.Play();
            }
    }

    public void Action(string name)
    {
        isAction = true;
        talkPanel.SetActive(true);

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
            case "storeCat event":
                Talk(500, 0);
                break;
            case "space":
                Talk(600, 0);
                break;
            case "ending":
                Talk(700, 0);
                break;
        }

        talkPanel.SetActive(isAction);
    }

    public void Talk(int id, int talkerId)
    {
        talkData = talkManager.GetTalk(id, talkIndex);
        talkerData = talkManager.GetTalker(talkerId);


        // ��ȭ ����
        if (talkData == null)
        {
            isAction = false;

            switch (id)
            {
                // scene 1 : ����� ���� �ٰ���
                case 101:
                    eventManager.catsCome();
                    break;
                // scene 1 : �Ҿƹ��� ���� ȹ��
                case 120:
                    eventManager.addBag();
                    break;
                // scene 2 : ���ھ��� �����
                case 311:
                    eventManager.girlParent();
                    break;
                //scene 3 : ���� ����
                case 420:
                    eventManager.catChase();
                    break;
                //scene 3 : ���� ��ġ��
                case 500:
                    eventManager.combineMarble();
                    break;
            }

            talkIndex = 0;

            return;
        }

        StartTyping(talkData);

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

    private void StartTyping(string text)
    {
        typingCoroutine = StartCoroutine(Typing(text));
    }

    IEnumerator Typing(string text)
    {
        talkText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            talkText.text += letter;
            yield return new WaitForSeconds(0.06f);
        }
    }
}
