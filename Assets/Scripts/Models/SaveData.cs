using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int day;
    public int meat;
    public int water;
    public List<int> ownedItems;
    public List<OwnedHero> ownedHeroes;
    public OwnedHero[] party;

    public SaveData(Hashtable saveDataHT)
    {
        day = (int)saveDataHT[CommonConstants.SAVE_DATA_DAY];
        meat = (int)saveDataHT[CommonConstants.SAVE_DATA_MEAT];
        water = (int)saveDataHT[CommonConstants.SAVE_DATA_WATER];
        ownedItems = (List<int>)saveDataHT[CommonConstants.SAVE_DATA_OWNED_ITEMS];
        ownedHeroes = (List<OwnedHero>)saveDataHT[CommonConstants.SAVE_DATA_OWNED_HEROES];
        party = (OwnedHero[])saveDataHT[CommonConstants.SAVE_DATA_PARTY];
    }
}
