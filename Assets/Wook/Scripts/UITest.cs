using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{

    [SerializeField] UIParticle UIParticle;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            UIParticle.ParticlsSHow(transform);
        }
    }
}
