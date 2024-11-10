using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SfxManager : MonoBehaviour
{
    public static SfxManager instance;

    public List<AudioClip> soundClips;


    public void PlaySound(int index) 
    {
        if (index >= 0 && index < soundClips.Count)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            AudioSource audioSource1 = GetComponentInParent<AudioSource>();
            AudioSource audioSource2 = GetComponentInChildren<AudioSource>();

            if (audioSource != null)
            {
                audioSource.clip = soundClips[index];
                audioSource.Play();
            }
            else
            {
                Debug.LogError("Audiosource no se encontró");
            }
        }
        else 
        {
            Debug.LogError("Clip inválido");
        }
    }

}
