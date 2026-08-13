using UnityEngine;

public class HeroAttack : CharacterAttack
{
    protected override int Damage()
    {
        DataCharacter dataHero = battleCharacter.characterStats.Data;
        HeroEquip heroEquip = GameManager.Instance.heroManager.TakeHero(dataHero.ID);
        return CalculateEquipmentValue.CalHealth(heroEquip);
    }
}
