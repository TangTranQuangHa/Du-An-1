using System;

[Serializable]
public class RewardRule
{
    public int minDay;
    public int maxDay;

    public int minItem;
    public int maxItem;

    public float bronzeRate;
    public float silverRate;
    public float goldRate;
    public float legendaryRate;

    public int minMeat;
    public int maxMeat;

    public int minWater;
    public int maxWater;
}