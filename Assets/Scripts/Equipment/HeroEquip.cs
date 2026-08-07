#nullable enable
using UnityEngine;

[System.Serializable]
public class HeroEquip
{
    // Nhân vật
    public DataHero data;

    // Hai món trang bị
    public DataItem? item_1;
    public DataItem? item_2;

    public HeroEquip(DataHero heroData)
    {
        data = heroData;
        item_1 = null;
        item_2 = null;
    }

    public HeroEquip Clone()
    {
        return (HeroEquip)this.MemberwiseClone();
    }
}