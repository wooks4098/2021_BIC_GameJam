using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameEnd : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particleSystems;

    [SerializeField] Image FadeOutImage;

    [SerializeField] Text[] EndText;

    [SerializeField] GameObject UI;

    public void End()
    {
        UI.SetActive(false);
        StartCoroutine(StartParticle());
    }

    IEnumerator StartParticle()
    {
        bool s = true;
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Play();
            particleSystems[i].Play();
            yield return new WaitForSeconds(0.25f);
        }
        StartCoroutine(FadeIn());



    }

    IEnumerator FadeIn()
    {
        float FadeOut_Time = 0f;
        float FadeOut_TimeCheck = 2f;
        Color alpha = new Color(0, 0, 0, 0);
        while (alpha.a < 1f)
        {
            FadeOut_Time += Time.deltaTime / FadeOut_TimeCheck;
            alpha.a = Mathf.Lerp(0, 1, FadeOut_Time);
            FadeOutImage.color = alpha;
            yield return null;
        }

        FadeOut_TimeCheck = 2f;
        int  Font = 0;
        while(FadeOut_TimeCheck> 0)
        {
            FadeOut_TimeCheck -= Time.deltaTime;
            for(int i = 0; i<EndText.Length; i++)
            {
                Font += 5;
                Debug.Log(Font);
                EndText[i].fontSize = Font;
            }
            yield return null;
        }
        Application.Quit();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
