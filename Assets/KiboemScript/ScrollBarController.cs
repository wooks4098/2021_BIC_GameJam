using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarController : MonoBehaviour
{
    [SerializeField]
    private float offset = 3.4f;
    public Slider slider;
    public ScrollRect scrollRect;

    // Use this for initialization
    // float wheelInput = Input.GetAxis("Mouse ScrollWheel");




    void Update()
    {
        Vector3 wheelInput = Input.mouseScrollDelta;
        if (wheelInput.y != 0)
            slider.value += wheelInput.y * Time.deltaTime * offset;

    }
    public void ChangeScrollPos()
    {

        scrollRect.verticalNormalizedPosition = slider.value;

    }
    public void MakeScrollZero()
    {
        scrollRect.verticalNormalizedPosition = -100;
        slider.value = scrollRect.verticalNormalizedPosition;
       // StartCoroutine(ValueChnageDelay());
        
    }
    /*
    IEnumerator ValueChnageDelay()
    {
        yield return new WaitForSeconds(0.3f);
        scrollRect.verticalNormalizedPosition = -100;
        slider.value = scrollRect.verticalNormalizedPosition;
    }
    */
}
