using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager bgMusic;

    private void Awake()
    {
        if (bgMusic != null) { Destroy(gameObject); }
        else { bgMusic = this; }

        DontDestroyOnLoad(this.gameObject);
    }

}
