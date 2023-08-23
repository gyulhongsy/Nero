using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectManager : MonoBehaviour
{
    private GameObject target;
    string targetName;

    public DialogueManager manager;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CastRay();

            /*
            if (target == this.gameObject)
            {
                Debug.Log("target : " + this.gameObject.name);

                if (target.name == "house")
                {
                    dialogueManager.Talk(100, 0);
                }
            }
            */
            // Debug.Log("2 : " + targetName);
            manager.Action(targetName);
        }
    }

    void CastRay()
    {
        target = null;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

        if (hit.collider != null)
        {
            //Debug.Log("1 : " + hit.collider.name);
            target = hit.collider.gameObject;
            targetName = hit.collider.name;
        }
    }
}
