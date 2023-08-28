using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ���� ���� �̸��� ������ ����
    public string nextSceneName;

    // �÷��̾ ���� ������ �̵��ϴ� �޼���
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
