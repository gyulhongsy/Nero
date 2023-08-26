using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmOption_Trigger : MonoBehaviour
{
    public GameObject Option_Page;
   // public AudioSource audioSource;

    void Start()
    {
       //audioSource = GetComponent<AudioSource>();
    }

    public void OptionDown()
    {
        Time.timeScale = 0; // 시간정지
        
        Option_Page.SetActive(true);
        //audioSource.Play();
    }

    public void OptionConfirm()
    {
       
        Option_Page.SetActive(false);
    }
}
