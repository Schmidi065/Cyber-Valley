using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] private Slider musicSlider;

    private void PlayMusic()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            MusicVolume();
        }
    }

    public void MusicVolume()
    {
        float volume = musicSlider.value;
        AudioMixer.SetFloat("ExposedTitleMusic", Mathf.Log10(volume)*15);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");

        MusicVolume();
    }
}
