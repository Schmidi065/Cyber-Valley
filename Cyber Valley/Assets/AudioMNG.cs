using UnityEngine;

public class AudioMNG : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource FXSource;

    public AudioClip background;
    public AudioClip door;
    public AudioClip walk;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        FXSource.PlayOneShot(clip);
    }
}
