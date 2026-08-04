using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Sources-----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    // [Header("-----Audio Clips-----")]
    // public AudioClip[] background;
    // public AudioClip[] attack;
    // public AudioClip[] dmg;
    // public AudioClip[] death;
    // public AudioClip[] gun;

    private void Start()
    {
        // musicSource.clip = background[Random.Range(0, background.Length)];
        // musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}