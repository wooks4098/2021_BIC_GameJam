using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEarning : MonoBehaviour
{
    [SerializeField]
    private float earnRate ;
    
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
            GlobalResource.globalGold += System.Math.Pow(GlobalResource.globalPeople, (double)1.33f);
            CountClock = earnRate;
        }
    }

    
    

}
