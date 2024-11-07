using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType 
{
    SLING,
    SPIDERIDLE,
    SPIDERATK,
    SPIDERDEATH,
    WASPFLY,
    WASPDEATH,
    STEPGRASS
}



public class SfxManager : MonoBehaviour
{
    public static SfxManager instance;

    [SerializeField] public AudioSource _sfxObj;
    [SerializeField] private AudioClip[] soundlist;
    [SerializeField] public float volume = 1.0f;

    private void Awake()
    {
        instance = this;
        
    }


    public static void PlaySFXClip(SoundType sound, float volume = 1) 
    {
         
        instance._sfxObj.PlayOneShot(instance.soundlist[(int)sound],volume);
        




        //AudioSource audioSource = Instantiate(_sfxObj, spawnPoint.position, Quaternion.identity);

        //audioSource.clip = ;  

        //audioSource.volume = volume;

        //audioSource.Play(instance.soundlist[(int)sound]);

        //float clipLength = audioSource.clip.length;

        //Destroy(audioSource.gameObject, clipLength);
    }
}
