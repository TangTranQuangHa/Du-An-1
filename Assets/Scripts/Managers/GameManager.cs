using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public ItemManager itemManager;
    public HeroManager heroManager;
    public ManagerUI managerUI;
    public ManagerRecruitHero managerRecruitHero;
    public SurvivalManager survivalManager;
    public RewardManager rewardManager;
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
}