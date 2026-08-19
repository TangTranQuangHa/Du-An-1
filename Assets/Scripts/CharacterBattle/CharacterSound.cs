using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [SerializeField] private AudioClip soundHurt;
    [SerializeField] private AudioClip soundAttack;
    [SerializeField] private AudioClip soundDead;
    [SerializeField] private BattleCharacter battleCharacter;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        battleCharacter = transform.parent.GetComponentInParent<BattleCharacter>();
    }
    private void Start()
    {
        this.audioManager = GameManager.Instance.audioManager;
    }
    private void OnEnable()
    {
        battleCharacter.characterStats.OnChangeHP += SoundHurt;
        battleCharacter.characterStats.OnDeadCharacter += SoundDead;
        battleCharacter.characterAttack.OnAttack += SoundAttack;
    }
    private void OnDisable()
    {
        battleCharacter.characterStats.OnChangeHP -= SoundHurt;
        battleCharacter.characterStats.OnDeadCharacter -= SoundDead;
        battleCharacter.characterAttack.OnAttack -= SoundAttack;
    }

    public void SoundDead()
    {
        GameManager.Instance.audioManager.PlaySFX(soundDead);
    }
    public void SoundHurt()
    {
        GameManager.Instance.audioManager.PlaySFX(soundHurt);
    }
    public void SoundAttack()
    {
        GameManager.Instance.audioManager.PlaySFX(soundAttack);
    }
}
