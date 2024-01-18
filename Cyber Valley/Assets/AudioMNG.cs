using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMNG : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource FXsource;

    public AudioClip background;
    public AudioClip walk;
    public AudioClip door;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlayFX(AudioClip clip)
    {
        FXsource.PlayOneShot(clip);
    }
}
