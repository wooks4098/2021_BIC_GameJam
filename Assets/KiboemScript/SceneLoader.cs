using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    static string nextScene;
    public static float minTime = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while(!op.isDone || timer < minTime)
        {
            yield return null;
            timer += Time.deltaTime;
            if(op.progress < 0.9f)
            {
                slider.value = Mathf.Lerp(slider.value, op.progress, timer);
                if(slider.value >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                slider.value = Mathf.Lerp(slider.value, 1f, timer / 2);
                if(slider.value == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
    // Update is called once per frame
}
