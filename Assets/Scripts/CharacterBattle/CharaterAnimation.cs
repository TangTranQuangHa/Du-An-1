using UnityEngine;

public class CharaterAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private BattleCharacter battleCharacter;

    private void Awake()
    {
        battleCharacter = transform.parent.GetComponentInParent<BattleCharacter>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        battleCharacter.characterStats.OnChangeHP += AnimHurt;
        battleCharacter.characterStats.OnDeadCharacter += AnimDead;
        battleCharacter.characterAttack.OnAttack += AnimAttack;
    }
    private void OnDisable()
    {
        battleCharacter.characterStats.OnChangeHP -= AnimHurt;
        battleCharacter.characterStats.OnDeadCharacter -= AnimDead;
        battleCharacter.characterAttack.OnAttack -= AnimAttack;
    }

    public void AnimDead()
    {
        anim.Play("Dead");
    }
    public void AnimHurt()
    {
        anim.Play("Hurt");
    }
    public void AnimAttack()
    {
        anim.Play("Attack");
    }

}
