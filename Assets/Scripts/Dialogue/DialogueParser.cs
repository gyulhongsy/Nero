using System; /* for Serializable */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{

    [Serializable]
    public class Dialogue
    {
        public int scene;
        public int index;
        public string name;
        public string line;

        public void printLine()
        {
            Debug.Log(name + " : " + line);
        }
    }

    [Serializable]
    public class Dialogues
    {
        public Dialogue[] dialogueDatas;
    }

    void Start()
    {
        string _FileName = "Dialogue";

        TextAsset dialogueString = Resources.Load<TextAsset>("Json/Dialogue");
        Dialogues dialogueList = JsonUtility.FromJson<Dialogues>(dialogueString.text);

        List<string> contextList = new List<string>();
        List<string> talkerList = new List<string>();
       
        foreach (Dialogue dialogueData in dialogueList.dialogueDatas)
        {
            dialogueData.printLine();

            contextList.Add(dialogueData.line);
            talkerList.Add(dialogueData.name);
        }

        /*
        for (int i = 0; i < dialogueData.Count; i++)
        {
            Dialogue dialogue = new Dialogue();
            Debug.Log(dialogue.text);


            dialogue.name = dialogueData[i]["name"].ToString(); //캐릭터 이름
            List<string> contextList = new List<string>();
            for (int j = 0; j < dialogue["line"].Count; j++)
            {
                contextList.Add(dialogue[j]["line"].ToString());
            }
            dialogue.contexts = contextList.ToArray();
            dialogueList.Add(dialogue);
        }
        return dialogueList.ToArray();//각 캐릭터의 대사들 배열로 리턴
        */
    }

    public List<string> GetTalkerData(List<string> d)
    {
        return d;
    }

    public List<string> GetTalkData(List<string> d)
    {
        return d;
    }
}