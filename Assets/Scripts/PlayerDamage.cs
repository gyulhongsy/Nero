using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    // cat1
                    dizzyCat1.GetComponent<DizzyCatMove1>().chaseLeft = true;
                    dizzyCat1.GetComponent<DizzyCatMove1>().transform.position = new Vector3(25f, -4.5f, 0);
                    dizzyCat1.GetComponent<DizzyCatMove1>().chaseStart = 1;

                    // cat2
                    dizzyCat2.GetComponent<DizzyCatMove2>().chaseLeft = true;
                    dizzyCat2.GetComponent<DizzyCatMove2>().transform.position = new Vector3(27f, -4.5f, 0);
                    dizzyCat2.GetComponent<DizzyCatMove2>().chaseStart = 1;

                    // cat3
                    dizzyCat3.GetComponent<DizzyCatMove3>().chaseLeft = true;
                    dizzyCat3.GetComponent<DizzyCatMove3>().transform.position = new Vector3(27.5f, -4.5f, 0);
                    dizzyCat3.GetComponent<DizzyCatMove3>().chaseStart = 1;

                    // cat4
                    dizzyCat4.GetComponent<DizzyCatMove4>().chaseLeft = true;
                    dizzyCat4.GetComponent<DizzyCatMove4>().transform.position = new Vector3(28f, -4.5f, 0);
                    dizzyCat4.GetComponent<DizzyCatMove4>().chaseStart = 1;

                    // cat5
                    dizzyCat5.GetComponent<DizzyCatMove5>().chaseLeft = true;
                    dizzyCat5.GetComponent<DizzyCatMove5>().transform.position = new Vector3(29f, -4.5f, 0);
                    dizzyCat5.GetComponent<DizzyCatMove5>().chaseStart = 1;

                    // cat6
                    dizzyCat6.GetComponent<DizzyCatMove6>().chaseLeft = true;
                    dizzyCat6.GetComponent<DizzyCatMove6>().transform.position = new Vector3(31f, -4.5f, 0);
                    dizzyCat6.GetComponent<DizzyCatMove6>().chaseStart = 1;

                    // storeCat
                    storeCat.GetComponent<StoreCatMove>().chaseLeft = true;
                    storeCat.GetComponent<StoreCatMove>().chaseRignt = false;
                    storeCat.GetComponent<StoreCatMove>().transform.position = new Vector3(26f, -4.5f, 0);
                    storeCat.GetComponent<StoreCatMove>().chaseStart = 1;
                }

            }
            if (dizzyCat3.GetComponent<DizzyCatMove3>().chaseStart >= 1)
            {
                if (dizzyCat3.GetComponent<DizzyCatMove3>().neroButtonOn2 == false)
                {
                    Debug.Log("맞음");
                    // cat1
                    dizzyCat1.GetComponent<DizzyCatMove1>().neroButtonOn1 = false;
                    dizzyCat1.GetComponent<DizzyCatMove1>().chaseLeft = true;
                    dizzyCat1.GetComponent<DizzyCatMove1>().transform.position = new Vector3(25f, -4.5f, 0);
                    dizzyCat1.GetComponent<DizzyCatMove1>().chaseStart = 1;

                    // cat2
                    dizzyCat2.GetComponent<DizzyCatMove2>().neroButtonOn1 = false;
                    dizzyCat2.GetComponent<DizzyCatMove2>().chaseLeft = true;
                    dizzyCat2.GetComponent<DizzyCatMove2>().transform.position = new Vector3(27f, -4.5f, 0);
                    dizzyCat2.GetComponent<DizzyCatMove2>().chaseStart = 1;
 
                    // cat3
                    dizzyCat3.GetComponent<DizzyCatMove3>().chaseLeft = true;
                    dizzyCat3.GetComponent<DizzyCatMove3>().transform.position = new Vector3(27.5f, -4.5f, 0);
                    dizzyCat3.GetComponent<DizzyCatMove3>().chaseStart = 1;

                    // cat4
                    dizzyCat4.GetComponent<DizzyCatMove4>().neroButtonOn1 = false;
                    dizzyCat4.GetComponent<DizzyCatMove4>().chaseLeft = true;
                    dizzyCat4.GetComponent<DizzyCatMove4>().transform.position = new Vector3(28f, -4.5f, 0);
                    dizzyCat4.GetComponent<DizzyCatMove4>().chaseStart = 1;

                    // cat5
                    dizzyCat5.GetComponent<DizzyCatMove5>().neroButtonOn2 = false;
                    dizzyCat5.GetComponent<DizzyCatMove5>().chaseLeft = true;
                    dizzyCat5.GetComponent<DizzyCatMove5>().transform.position = new Vector3(29f, -4.5f, 0);
                    dizzyCat5.GetComponent<DizzyCatMove5>().chaseStart = 1;

                    // cat6
                    dizzyCat6.GetComponent<DizzyCatMove6>().neroButtonOn2 = false;
                    dizzyCat6.GetComponent<DizzyCatMove6>().chaseLeft = true;
                    dizzyCat6.GetComponent<DizzyCatMove6>().transform.position = new Vector3(31f, -4.5f, 0);
                    dizzyCat6.GetComponent<DizzyCatMove6>().chaseStart = 1;

                    // storeCat
                    storeCat.GetComponent<StoreCatMove>().chaseLeft = true;
                    storeCat.GetComponent<StoreCatMove>().chaseRignt = false;
                    storeCat.GetComponent<StoreCatMove>().transform.position = new Vector3(26f, -4.5f, 0);
                    storeCat.GetComponent<StoreCatMove>().chaseStart = 1;
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
                    // cat1
                    dizzyCat1.GetComponent<DizzyCatMove1>().neroButtonOn1 = false;
                    dizzyCat1.GetComponent<DizzyCatMove1>().chaseLeft = true;
                    dizzyCat1.GetComponent<DizzyCatMove1>().transform.position = new Vector3(25f, -4.5f, 0);
                    dizzyCat1.GetComponent<DizzyCatMove1>().chaseStart = 1;

                    // cat2
                    dizzyCat2.GetComponent<DizzyCatMove2>().neroButtonOn1 = false;
                    dizzyCat2.GetComponent<DizzyCatMove2>().chaseLeft = true;
                    dizzyCat2.GetComponent<DizzyCatMove2>().transform.position = new Vector3(27f, -4.5f, 0);
                    dizzyCat2.GetComponent<DizzyCatMove2>().chaseStart = 1;

                    // cat3
                    dizzyCat3.GetComponent<DizzyCatMove3>().neroButtonOn2 = false;
                    dizzyCat3.GetComponent<DizzyCatMove3>().chaseLeft = true;
                    dizzyCat3.GetComponent<DizzyCatMove3>().transform.position = new Vector3(27.5f, -4.5f, 0);
                    dizzyCat3.GetComponent<DizzyCatMove3>().chaseStart = 1;

                    // cat4
                    dizzyCat4.GetComponent<DizzyCatMove4>().neroButtonOn1 = false;
                    dizzyCat4.GetComponent<DizzyCatMove4>().chaseLeft = true;
                    dizzyCat4.GetComponent<DizzyCatMove4>().transform.position = new Vector3(28f, -4.5f, 0);
                    dizzyCat4.GetComponent<DizzyCatMove4>().chaseStart = 1;

                    // cat5
                    dizzyCat5.GetComponent<DizzyCatMove5>().neroButtonOn2 = false;
                    dizzyCat5.GetComponent<DizzyCatMove5>().chaseLeft = true;
                    dizzyCat5.GetComponent<DizzyCatMove5>().transform.position = new Vector3(29f, -4.5f, 0);
                    dizzyCat5.GetComponent<DizzyCatMove5>().chaseStart = 1;

                    // cat6
                    dizzyCat6.GetComponent<DizzyCatMove6>().neroButtonOn2 = false;
                    dizzyCat6.GetComponent<DizzyCatMove6>().chaseLeft = true;
                    dizzyCat6.GetComponent<DizzyCatMove6>().transform.position = new Vector3(31f, -4.5f, 0);
                    dizzyCat6.GetComponent<DizzyCatMove6>().chaseStart = 1;

                    //storeCat.GetComponent<StoreCatMove>().neroButtonOn = false;
                    storeCat.GetComponent<StoreCatMove>().chaseLeft = true;
                    storeCat.GetComponent<StoreCatMove>().chaseRignt = false;
                    storeCat.GetComponent<StoreCatMove>().transform.position = new Vector3(26f, -4.5f, 0);
                    storeCat.GetComponent<StoreCatMove>().chaseStart = 1;
                }

            }

        }
    }
}
