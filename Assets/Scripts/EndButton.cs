using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    void Update()
    {

    }

    // 처음부터 버튼 함수
    public void SceneChangeButton()
    {
        SceneManager.LoadScene("Chap12");   // 임시 전환. 추후 삭제
        //SceneManager.LoadScene("시작화면씬 이름");
        Debug.Log("처음으로 이동");
    }

    // 게임 종료 버튼 함수
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("게임 종료");
    }
}
