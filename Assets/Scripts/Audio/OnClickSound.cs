using UnityEngine;

public class OnClickSound : MonoBehaviour
{
    [SerializeField] private AudioClip onClick;
    [SerializeField] private AudioManager audioSource;

    private void Start()
    {
        audioSource = GameManager.Instance.audioManager;
    }
    public void ClickSound()
    {
        audioSource.PlaySFX(onClick);
    }
}
