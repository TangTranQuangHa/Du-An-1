using UnityEngine;

public class TagetShown : MonoBehaviour
{
    [SerializeField] private BattleCharacter battleCharacter;
    [SerializeField] private SpriteRenderer target;

    private void Awake()
    {
        battleCharacter = transform.parent.GetComponentInParent<BattleCharacter>();
        target = GetComponent<SpriteRenderer>();
        target.enabled = false;
    }

    private void OnEnable()
    {
        battleCharacter.characterStats.OnChangeHP += AnimHurt;
        battleCharacter.characterAttack.OnAttack += AnimAttack;
    }
    private void OnDisable()
    {
        battleCharacter.characterStats.OnChangeHP -= AnimHurt;
        battleCharacter.characterAttack.OnAttack -= AnimAttack;
    }
    public void AnimHurt()
    {
        target.enabled = true;
        target.color = Color.red;
        Invoke(nameof(HideTarget), 1.3f);
    }
    public void AnimAttack()
    {
        target.enabled = true;
        target.color = Color.blue;
        Invoke(nameof(HideTarget), 1.3f);
    }

    public void HideTarget()
    {
        target.enabled = false;
    }
}
