using System.Collections.Generic;

public class BattleReward
{
    public List<DataItem> Items;
    public int Meat;
    public int Water;

    public BattleReward(
        List<DataItem> items,
        int meat,
        int water)
    {
        Items = items;
        Meat = meat;
        Water = water;
    }
}
