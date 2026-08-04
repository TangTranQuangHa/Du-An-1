using UnityEngine;

public static class CalculateEquipmentValue
{
    public static int CalDamage(CharacterEquip characterEquip)
    {
        if (characterEquip == null || characterEquip.data == null)
            return 0;

        float totalDamage = characterEquip.data.Damage;

        if (characterEquip.item_1 != null)
            totalDamage += characterEquip.item_1.Damage;

        if (characterEquip.item_2 != null)
            totalDamage += characterEquip.item_2.Damage;

        return Mathf.RoundToInt(totalDamage);
    }

    public static int CalHealth(CharacterEquip characterEquip)
    {
        if (characterEquip == null || characterEquip.data == null)
            return 0;

        float totalHealth = characterEquip.data.Health;

        if (characterEquip.item_1 != null)
            totalHealth += characterEquip.item_1.Health;

        if (characterEquip.item_2 != null)
            totalHealth += characterEquip.item_2.Health;

        return Mathf.RoundToInt(totalHealth);
    }
}