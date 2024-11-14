using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SfxManager : MonoBehaviour
{
    public static SfxManager instance;

    public List<AudioClip> soundClips;

    private void Awake()
    {
        instance = this;

    }



    public void PlaySound(int index, AudioSource audioSource) 
    {
        if (index >= 0 && index < soundClips.Count)        {
                      

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
