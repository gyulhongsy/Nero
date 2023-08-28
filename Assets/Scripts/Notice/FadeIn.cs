using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    float time = 0;

    void Update()
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

    public void resetAnim()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        this.gameObject.SetActive(true);
        time = 0;
    }
}
