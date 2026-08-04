using UnityEngine;

public static class CalculateEquipmentValue
{
    public static int CalDamage(HeroEquip heroEquip)
    {
        if (heroEquip == null || heroEquip.data == null)
            return 0;

        float totalDamage = heroEquip.data.Damage;

        if (heroEquip.item_1 != null)
            totalDamage += heroEquip.item_1.Damage;

        if (heroEquip.item_2 != null)
            totalDamage += heroEquip.item_2.Damage;

        return Mathf.RoundToInt(totalDamage);
    }

    public static int CalHealth(HeroEquip heroEquip)
    {
        if (heroEquip == null || heroEquip.data == null)
            return 0;

        float totalHealth = heroEquip.data.Health;

        if (heroEquip.item_1 != null)
            totalHealth += heroEquip.item_1.Health;

        if (heroEquip.item_2 != null)
            totalHealth += heroEquip.item_2.Health;

        return Mathf.RoundToInt(totalHealth);
    }
}