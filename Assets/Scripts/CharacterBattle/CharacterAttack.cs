using System;
using UnityEngine;

public abstract class CharacterAttack : MonoBehaviour
{
    public Action OnAttack;
    [SerializeField] protected int damageCurrent;
    [SerializeField] protected BattleCharacter battleCharacter;

    protected void Awake()
    {
        battleCharacter = transform.parent.GetComponent<BattleCharacter>();
    }
    public void Attaking(BattleCharacter battleCharacter)
    {
        damageCurrent = Damage();
        battleCharacter.characterStats.ReceiverDamage(damageCurrent);
        OnAttack.Invoke();
    }
    protected abstract int Damage();
}
