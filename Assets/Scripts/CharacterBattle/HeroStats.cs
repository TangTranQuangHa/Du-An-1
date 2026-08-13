using UnityEngine;

public class HeroStats : CharacterStats
{
    protected override int SetHealth()
    {
        HeroEquip heroEquip = GameManager.Instance.heroManager.TakeHero(Data.ID);
        return CalculateEquipmentValue.CalHealth(heroEquip);
    }
}
