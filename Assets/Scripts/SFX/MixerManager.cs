using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerManager : MonoBehaviour
{
    private static MixerManager instance;

    [SerializeField] private AudioMixer _audiomixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }
    public void SetMusicVolume()
    {
        float volume = _musicSlider.value;
        _audiomixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    public void SetSfxVolume()
    {
        float volume = _sfxSlider.value;
        _audiomixer.SetFloat("sfxVol", Mathf.Log10(volume) * 20);
    }
}
