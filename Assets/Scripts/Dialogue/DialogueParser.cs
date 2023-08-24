using System; /* for Serializable */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public TextAsset jsonFile;

    [System.Serializable]
    public class Line
    {
        public int talkerId;
        public string line;
    }

    [System.Serializable]
    public class DialogueData
    {
        public int id;
        public Line[] lines;
    }

    [System.Serializable]
    public class DialogueDataContainer
    {
        public DialogueData[] dialogueDatas;
    }

    void Start()
    {
        string jsonText = jsonFile.text;
        DialogueDataContainer dataContainer = JsonUtility.FromJson<DialogueDataContainer>(jsonText);

        /*
        foreach (DialogueData dialogueData in dataContainer.dialogueDatas)
        {
            Debug.Log("Dialogue ID: " + dialogueData.id);

            foreach (Line line in dialogueData.lines)
            {
                Debug.Log("Talker ID: " + line.talkerId + ", Line: " + line.line);
            }
        }
        */
    }
    
}