using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public ItemManager itemManager;
    public HeroManager heroManager;
    public ManagerUI managerUI;
    
    public void UpdateEquip(HeroEquip oldHE, HeroEquip newHE)
    {
        if (oldHE.item_1.ID != newHE.item_1.ID)
        {
            itemManager.AddItem(oldHE.item_1);
            itemManager.SubItem(newHE.item_1);
        }

        if (oldHE.item_2.ID != newHE.item_2.ID)
        {
            itemManager.AddItem(oldHE.item_2);
            itemManager.SubItem(newHE.item_2);
        }

        heroManager.UpdateHeroEquip(newHE);
    }
}
