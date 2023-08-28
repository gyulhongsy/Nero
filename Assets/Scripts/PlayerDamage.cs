using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    public GameObject storeCat;
    public GameObject dizzyCat1;
    public GameObject dizzyCat2;
    public GameObject dizzyCat3;
    public GameObject dizzyCat4;
    public GameObject dizzyCat5;
    public GameObject dizzyCat6;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DizzyCat")
        {
            if (dizzyCat1.GetComponent<DizzyCatMove1>().chaseStart >= 1)
            {
                if (dizzyCat1.GetComponent<DizzyCatMove1>().neroButtonOn1 == false)
                {
                    Debug.Log("맞음");
                    SceneManager.LoadScene("Chap3");    // 처음부터
                }

            }
            if (dizzyCat3.GetComponent<DizzyCatMove3>().chaseStart >= 1)
            {
                if (dizzyCat3.GetComponent<DizzyCatMove3>().neroButtonOn2 == false)
                {
                    Debug.Log("맞음");
                    SceneManager.LoadScene("Chap3");    // 처음부터
                }

            }

        }

        if(collision.gameObject.tag == "StoreCat")
        {
            if (storeCat.GetComponent<StoreCatMove>().chaseStart >= 1)
            {
                if (storeCat.GetComponent<StoreCatMove>().neroButtonOn == false)
                {
                    Debug.Log("맞음");
                    SceneManager.LoadScene("Chap3");    // 처음부터
                }

            }

        }
    }
}
