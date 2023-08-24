using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 다음 씬의 이름을 저장할 변수
    public string nextSceneName;

    // 플레이어가 다음 씬으로 이동하는 메서드
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
