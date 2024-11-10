using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSFX : MonoBehaviour
{
    [Header("Sfx Clips")]
    public List<AudioClip> soundClips;

    public AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(int index)
    {
        if (index >= 0 && index < soundClips.Count)
        {
            audiosource = GetComponent<AudioSource>();
            if (audiosource != null)
            {                
                audiosource.PlayOneShot(soundClips[index]);
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
