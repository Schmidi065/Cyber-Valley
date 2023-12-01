using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider audioSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            MusicVolume();
            AudioVolume();
        }

        
    }

    public void MusicVolume()
    {
        float volume = musicSlider.value;
        AudioMixer.SetFloat("ExposedTitleMusic", Mathf.Log10(volume)*15);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void AudioVolume()
    {
        float volume = audioSlider.value;
        AudioMixer.SetFloat("ExposedTitleAudio", Mathf.Log10(volume) * 15);
        PlayerPrefs.SetFloat("audioVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        audioSlider.value = PlayerPrefs.GetFloat("audioVolume");

        MusicVolume();
        AudioVolume();
    }
}
