using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void SceneChange()
    {
        Debug.Log("¿Ãµø!");
        SceneManager.LoadScene("NeroHouse");
    }
}
