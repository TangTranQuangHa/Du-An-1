using System;
using UnityEngine;

public abstract class CharacterStats : MonoBehaviour
{
    [SerializeField] private DataCharacter data;
    [SerializeField] private int currentHp;
    [SerializeField] private int maxHp;

    public Action OnChangeHP;
    public Action OnDeadCharacter;

    public DataCharacter Data => data;
    public int CurrentHP => currentHp;
    public int MaxHP => maxHp;

    private void Start()
    {
        maxHp = currentHp = SetHealth();
        OnChangeHP.Invoke();
    }

    protected abstract int SetHealth();

    public void ReceiverDamage(int damageReceive)
    {
        currentHp -= damageReceive;
        if (currentHp <= 0)
        {
            this.currentHp = 0;
            Dead();
        }
        else
        {
            this.OnChangeHP?.Invoke();
        }
    }

    protected void Dead()
    {
        this.OnDeadCharacter?.Invoke();
        transform.parent.gameObject.SetActive(false);
    }
}
