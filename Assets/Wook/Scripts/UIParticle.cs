using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIParticle : MonoBehaviour
{
    Image image;
    Animator ani;
    [SerializeField] CameraShake[] cameraShakes;
    private void Awake()
    {
        image = GetComponent<Image>();
        ani = GetComponent<Animator>();
    }
    public void ParticlsSHow(Transform trans)
    {
        transform.position = trans.position;
        ani.SetTrigger("Show");
        for(int i = 0; i< cameraShakes.Length; i++)
        {
            StartCoroutine(cameraShakes[i].Shake(0.2f, 0.2f));
        }
       //image.enabled = true;
    }
}
