using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoadEvent : MonoBehaviour
{
    
    [SerializeField]
    private Canvas TutorialCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene , LoadSceneMode mode)
    {
        Instantiate(TutorialCanvas);
        TutorialCanvas.gameObject.SetActive(true);
    }

}
