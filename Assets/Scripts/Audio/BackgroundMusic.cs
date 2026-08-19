using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioClip musicBackground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.audioManager.PlayMusic(musicBackground);
    }
}
