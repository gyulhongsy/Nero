using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traffic : MonoBehaviour
{
    private bool state;
    public GameObject Target;

    void Start()
    {
        state = true;
    }

    void StairsOff()
    {
        Target.SetActive(true);
        state = true;
        AudioSource off = GetComponent<AudioSource>();
        off.Play();
    }

    void StairsOn()
    {
        Target.SetActive(false);
        state = false;
        AudioSource on = GetComponent<AudioSource>();
        on.Play();
    }



}
