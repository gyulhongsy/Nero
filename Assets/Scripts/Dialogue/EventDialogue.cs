using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialogue : MonoBehaviour
{
    public DialogueManager manager;

    IEnumerator ActionEvent(int count, string eventName)
    {
        Debug.Log(eventName + " : action");

        float delayBetweenCalls = 3.2f;

        for (int i = 0; i < count; i++)
        {
            manager.Action(eventName);
            yield return new WaitForSeconds(delayBetweenCalls);
        }
    }

    public void StartEvent(int count, string eventName)
    {
        StartCoroutine(ActionEvent(count, eventName));
        Debug.Log("start event");
    }
}
