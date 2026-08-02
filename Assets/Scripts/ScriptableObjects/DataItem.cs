using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DataItem", menuName = "Item Data/Item")]
public class DataItem : ScriptableObject
{
    //
    public int ID;
    //
    public string Name;
    // describe the item
    [TextAreaAttribute]
    public string Description;
    //
    public Rarity _rarity;
    // Damage+
    public float Damage;
    // Max Health +
    public float Health;

    public void Equip(GameObject target)
    {
        // change this after hero handle add
        // target.TotalDamage += Damage
        // target.TotalHealth += Health
    }

    public void Unequip(GameObject target)
    {
        // target.TotalDamage += Damage
        // target.TotalHealth += Health
    }

}
