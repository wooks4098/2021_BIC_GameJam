using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitleCamera : MonoBehaviour
{
    public float Speed;

    public GameObject StartToClickImage;

    bool isBig;
    public float time;
    float timeCheck;
    public float StartToClickSpeed;
    Vector3 sc;

    private void Start()
    {
        timeCheck = time;
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, -Speed * Time.deltaTime, 0));

        if(isBig)
        {
            sc = StartToClickImage.transform.localScale;
            StartToClickImage.transform.localScale = new Vector3(sc.x + Time.deltaTime * StartToClickSpeed, sc.y + Time.deltaTime * StartToClickSpeed, sc.z + Time.deltaTime * StartToClickSpeed);
        }
        else
        {
            sc = StartToClickImage.transform.localScale;
            StartToClickImage.transform.localScale = new Vector3(sc.x - Time.deltaTime* StartToClickSpeed, sc.y - Time.deltaTime* StartToClickSpeed, sc.z - Time.deltaTime* StartToClickSpeed);
        }

        timeCheck -= Time.deltaTime;
        if(timeCheck <= 0)
        {
            timeCheck = time;
            isBig = !isBig;
        }
    }
}
