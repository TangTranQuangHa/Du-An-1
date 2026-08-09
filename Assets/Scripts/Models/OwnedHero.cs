using UnityEngine;

[System.Serializable]
public class OwnedHero
{
    public int ownedHeroID;
    public int equippedItem1ID;
    public int equippedItem2ID;

    public OwnedHero()
    {
        ownedHeroID = -1;
        equippedItem1ID = -1;
        equippedItem2ID = -1;

    }

    public OwnedHero(
        int heroId,
        int itemID1,
        int itemID2
    )
    {
        ownedHeroID = heroId;
        equippedItem1ID = itemID1;
        equippedItem2ID = itemID2;
    }

    public OwnedHero(HeroEquip heroEquip)
    {
        ownedHeroID = heroEquip.data.ID;
        equippedItem1ID = (heroEquip.item_1 != null) ? heroEquip.item_1.ID : -1;
        equippedItem2ID = (heroEquip.item_2 != null) ? heroEquip.item_2.ID : -1;
    }
}
