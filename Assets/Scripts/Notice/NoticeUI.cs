using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NoticeUI : MonoBehaviour
{
    public GameObject subBox;
    public Text subText;

    float time = 0;
    bool isActive = false; 

    void Start()
    {
        subBox.SetActive(isActive);
    }

    void Update()
    {
        if (isActive)
        {
            if (time < 2f)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / 3);
            }
            else
            {
                time = 0;
                this.gameObject.SetActive(false);
            }
            time += Time.deltaTime;
        }
    }

    public void Notice(string msg)
    {
        subText.text = msg;
        isActive = true;
    }
}
