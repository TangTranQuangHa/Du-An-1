using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public ItemManager itemManager;
    public HeroManager heroManager;
    public ManagerUI managerUI;
    public ManagerRecruitHero managerRecruitHero;
    public SurvivalManager survivalManager;
    public RewardManager rewardManager;
    // Khai báo sự kiện thông báo khi load game xong
    public event Action OnGameLoaded;

    private Hashtable saveDataHT;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Load();
    }

    public void UpdateEquip(HeroEquip oldHE, HeroEquip newHE)
    {
        if (oldHE.item_1?.ID != newHE.item_1?.ID)
        {
            if (oldHE.item_1 != null)
                itemManager.AddItem(oldHE.item_1);

            if (newHE.item_1 != null)
                itemManager.SubItem(newHE.item_1);
        }

        if (oldHE.item_2?.ID != newHE.item_2?.ID)
        {
            if (oldHE.item_2 != null)
                itemManager.AddItem(oldHE.item_2);

            if (newHE.item_2 != null)
                itemManager.SubItem(newHE.item_2);
        }

        heroManager.UpdateHeroEquip(newHE);
    }

    public void Save()
    {
        saveDataHT[CommonConstants.SAVE_DATA_DAY] = survivalManager.TakeDay();
        saveDataHT[CommonConstants.SAVE_DATA_MEAT] = survivalManager.TakeOwnerMeat();
        saveDataHT[CommonConstants.SAVE_DATA_WATER] = survivalManager.TakeOwnerWater();
        saveDataHT[CommonConstants.SAVE_DATA_OWNED_ITEMS] = itemManager.GetOwnedItemIDs();
        saveDataHT[CommonConstants.SAVE_DATA_OWNED_HEROES] = heroManager.GetOwnedHeroes();
        // saveDataHT[CommonConstants.SAVE_DATA_PARTY] =

        var saveData = new SaveData(saveDataHT);
        
        SaveSystem.Save(saveData);
    }

    public void Load()
    {
        var saveData = SaveSystem.Load();
        ResetGameValues();

        if (saveData != null)
        {
            saveDataHT[CommonConstants.SAVE_DATA_DAY] = saveData.day;
            saveDataHT[CommonConstants.SAVE_DATA_MEAT] = saveData.meat;
            saveDataHT[CommonConstants.SAVE_DATA_WATER] = saveData.water;
            saveDataHT[CommonConstants.SAVE_DATA_OWNED_ITEMS] = saveData.ownedItems;
            saveDataHT[CommonConstants.SAVE_DATA_OWNED_HEROES] = saveData.ownedHeroes;
            // saveDataHT[CommonConstants.SAVE_DATA_PARTY] = saveData.party;
        }

        survivalManager.SetDay(saveData.day);
        survivalManager.SetOwnerMeat(saveData.meat);
        survivalManager.SetOwnerWater(saveData.water);

        foreach (var ownedHero in saveData.ownedHeroes)
        {
            var newOwnedHeroEquip = heroManager.GetOriginalHeroEquipByID(ownedHero.ownedHeroID);

            if (ownedHero.equippedItem1ID != -1)
            {
                newOwnedHeroEquip.item_1 = itemManager.GetDataItemByID(ownedHero.equippedItem1ID);
            }
            if (ownedHero.equippedItem1ID != -1)
            {
                newOwnedHeroEquip.item_2 = itemManager.GetDataItemByID(ownedHero.equippedItem2ID);
            }

            heroManager.AddNewHero(newOwnedHeroEquip);
        }

        foreach (var ownedItem in saveData.ownedItems)
        {
            var ownedDataItem = itemManager.GetDataItemByID(ownedItem);
            itemManager.AddItem(ownedDataItem);
        }

        // 3. Phát sóng sự kiện thông báo cho toàn bộ hệ thống (UI sẽ nghe thấy cái này)
        OnGameLoaded?.Invoke();
    }

    public void ResetGameValues()
    {
        saveDataHT = newGameSaveDataHT;
        survivalManager.Reset();
        heroManager.ClearOwnedHeroEquips();
        itemManager.ClearOwnedItems();
    }

    private Hashtable newGameSaveDataHT = new Hashtable()
        {
            { CommonConstants.SAVE_DATA_DAY , 1 },
            { CommonConstants.SAVE_DATA_MEAT , 20 },
            { CommonConstants.SAVE_DATA_WATER , 20 },
            { CommonConstants.SAVE_DATA_OWNED_ITEMS , new List<int>() },
            { CommonConstants.SAVE_DATA_OWNED_HEROES, new List<OwnedHero>() }
            // { CommonConstants.SAVE_DATA_PARTY, new OwnedHero[4]
            //     {
            //         new OwnedHero(),
            //         new OwnedHero(),
            //         new OwnedHero(),
            //         new OwnedHero(),
            //     }
            // }
        };
}
