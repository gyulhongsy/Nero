using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bag2 : MonoBehaviour
{
    public Boolean isBagOpen = false;
    
    public GameObject bag;

    public GameObject hangover;
    public GameObject drink;

    public GameObject invenHangover;
    public GameObject invenDrink;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*        if (Input.touchCount > 0)
                {
                    Debug.Log("가방 닫기");
                    //hangover.SetActive(false);
                }
                if(Input.touchCount > 0 && Input.touchCount % 2 != 0)
                {
                    Debug.Log("가방 열기");
                }*/
        /*        if (isBagOpen)
                {
                    BagClose();
                }
                else
                {
                    BagOpen();
                }*/
        //BagState();
    }



    public void BagState()
    {
/*        if (Input.touchCount > 0)
        {
            Debug.Log("가방 닫기");
            //hangover.SetActive(false);
        }
        if (Input.touchCount > 0 && Input.touchCount % 2 != 0)
        {
            Debug.Log("가방 열기");
        }*/
        if (isBagOpen)  //가방 닫기
        {
            isBagOpen = false;
            bag.SetActive(false);
            Debug.Log("가방 닫기");
        }
        else    // 가방 열기
        {
            isBagOpen = true;
            bag.SetActive(true);
            if(hangover.GetComponent<Item_Pick>().pick == true)
                if(invenHangover.GetComponent<GiveItem>().finishH == false)
                    invenHangover.gameObject.SetActive(true);
            
            if (drink.GetComponent<Item_Pick>().pick == true)
                if(invenDrink.GetComponent<GiveItem>().finishD == false)
                    invenDrink.gameObject.SetActive(true);

            Debug.Log("가방 열기");
        }
    }
}
