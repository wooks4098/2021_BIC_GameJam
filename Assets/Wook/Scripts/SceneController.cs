using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            SoundManager.instance.PlayBGM("InGame");
        }
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
