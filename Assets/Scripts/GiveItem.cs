using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GiveItem : MonoBehaviour, IPointerClickHandler
{
    public EventDialogue eventDialogue;
    Animator anim;

    public GameObject player;   // 네로 오브젝트
    public GameObject bagInven;      // 가방 인벤토리
    public GameObject bag;          // 가방 버튼
    public GameObject ivenHangover;     // 인벤토리 숙취제
    public GameObject ivenDrink;        // 인벤토리 음료
    public GameObject invenMarble1;     // 인벤토리 구슬조각1
    public GameObject girl;     // 우는 여자 아이

    public Boolean giveH = false;       // 숙취제 전달 가능 여부
    public Boolean finishH = false;     // 숙취제 전달 완료 여부
    public Boolean giveD = false;       // 음료 전달 가능 여부
    public Boolean finishD = false;     // 음료 전달 완료 여부


    void Arrive()   // 아저씨 or 여자아이에게 도착 시 함수
    {
        // 아저씨 위치에 도착 시 숙취제 전달 가능
        if(-1.5f <= player.transform.position.x && player.transform.position.x <= 0.5f)
        {
            if(player.transform.position.y <= 2f)
            {
                // Debug.Log("아저씨 닿음");
                giveH = true;

            }
        }
        else
        {
            giveH = false;
        }

        // 여자아이 위치에 도착 시 음료 전달 가능
        if (62.5f <= player.transform.position.x && player.transform.position.x <= 64.5f)
        {
            if (player.transform.position.y <= 3f)
            {
                Debug.Log("여자아이 닿음");
                giveD = true;

            }
        }
        else
        {
            giveD = false;
        }
    }

    void Update()
    {
        Arrive();
    }


    public void OnPointerClick(PointerEventData eventData)  // 터치 이벤트 함수
    {

        if (giveH)  // 숙취제 전달 가능
        {
            Debug.Log("숙취제 주기");
            finishH = true;     // 숙취제 줌
            invenMarble1.SetActive(true);   // 구슬조각 1 얻음
            ivenHangover.SetActive(false);  // 숙취제 사라짐 
            //bag.GetComponent<Bag2>().isBagOpen = false;     // 가방 열림 확인 변수 false
            bagInven.SetActive(false);   // 가방 인벤닫기

            eventDialogue.StartEvent(20, "mr.drunken event");
        }
        if (giveD)  // 음료 전달 가능
        {
            Debug.Log("음료 주기");
            finishD = true;     // 음료 줌
            ivenDrink.SetActive(false); // 음료 사라짐
            //bag.GetComponent<Bag2>().isBagOpen = false;     // 가방 열림 확인 변수 false
            bagInven.SetActive(false);   // 가방 인벤닫기
            anim = girl.GetComponent<Animator>();
            anim.SetBool("isHappy", true);  // 여자아이 웃음 애니메이션

            eventDialogue.StartEvent(9, "missingGirl event");
        }
    }
}
