using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEarning : MonoBehaviour
{
    private float earnRate = 1f;
    private float CountClock;

    
    // Start is called before the first frame update
    void Start()
    {
        CountClock = earnRate;
    }

    // Update is called once per frame
    void Update()
    {
        CountClock -= Time.deltaTime;
        if (CountClock < 0)
        {
            GlobalResource.globalGold += Mathf.Pow(GlobalResource.globalPeople, 1.3f);
            CountClock = earnRate;
        }
    }

    
    

}
