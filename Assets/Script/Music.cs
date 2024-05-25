using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public PlaayerController Controller;
    public AudioSource audioSource;

    void Update()
    {
        if (Controller != null)
        {
            Controller = FindObjectOfType<PlaayerController>();

        }
        if (Controller.Death && audioSource.isPlaying)
        {
            AudioManager.instance.PlaySound(transform.position, 1, Random.Range(1f, 1f), 1);

            audioSource.Stop(); 
        }
    }
}
