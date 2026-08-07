using UnityEngine;

public class ManagerEquip : Singleton<ManagerEquip>
{
    public SlotHero slotHero;
    public SlotItem[] slotItems;
    public HeroEquip currentHeroEquip;

    void Start()
    {
        // Subscribe to the OnCharacterAssigned event of slotHero
        slotHero.OnCharacterAssigned += UpdateSlotHero;
        // Subscribe to the OnItemAssigned event of each slotItem
        foreach (SlotItem slotItem in slotItems)
        {
            slotItem.OnItemAssigned += UpdateSlotItem;
        }
    }

    void OnDestroy()
    {
        slotHero.OnCharacterAssigned -= UpdateSlotHero;
        foreach (SlotItem slotItem in slotItems)
        {
            slotItem.OnItemAssigned -= UpdateSlotItem;
        }
    }

    public void UpdateSlotHero(SlotHero slotHero, DragHero dragHero)
    {
        // check if there is an existing hero in the slot, then move it back to the scroll view
        if (slotHero.DragCurrent != null)
        {
            MoveTheDragged(slotHero.DragCurrent, dragHero.transform.parent);
        }
        // set the new hero to the slot
        MoveTheDragged(dragHero, slotHero.transform);

        // get the stats card from the drag hero and update currentHeroEquip
        StatsCard statsCard = dragHero.gameObject.GetComponent<StatsCard>();
        if (statsCard != null)
        {
            var newHeroEquip = GameManager.Instance.heroManager.TakeHero(statsCard.Data.ID);
            if ((newHeroEquip != null)
                && (newHeroEquip.data != null))
            {
                currentHeroEquip = newHeroEquip;
                SetItemUIs();
            }
        }

        slotHero.SetCharacter(dragHero);
    }

    private void SetItemUIs()
    {
        // check if slotItems has only 2 elements
        if (slotItems.Length != 2)
        {
            Debug.LogWarning("slotItems array does not have exactly 2 elements.");
            return;
        }

        SetItemUI(currentHeroEquip.item_1, slotItems[0]);
        SetItemUI(currentHeroEquip.item_2, slotItems[1]);
    }

    public void SetItemUI(DataItem dataItem, SlotItem slotItem)
    {
        var gameManager = GameManager.Instance;
        
        // Always clear child items first
        for (int i = slotItem.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(slotItem.transform.GetChild(i).gameObject);
        }
        
        // Then instantiate new item if data exists
        if (dataItem != null)
        {
            var item = gameManager.managerUI.TakeItemCard(dataItem.ID);
            if (item != null)
            {
                var itemUI = Instantiate(item, slotItem.transform);
                itemUI.transform.localPosition = Vector3.zero;
                var newDragItem = itemUI.GetComponent<DragItem>();
                if (newDragItem != null)
                {
                    slotItem.SetItem(newDragItem);
                }
            }
        }
    }

    public void UpdateSlotItem(
        SlotItem slotItem,
        DragItem dragItem,
        EquipSlotType equipSlotType)
    {
        // check if there is an existing item in the slot, then move it back to the scroll view
        if (slotItem.DragCurrent != null)
        {
            MoveTheDragged(slotItem.DragCurrent, dragItem.transform.parent);
        }
        // set the new item to the slot
        MoveTheDragged(dragItem, slotItem.transform);

        UpdateDataEquip(dragItem, equipSlotType);

        slotItem.SetItem(dragItem);
    }
    
    private void MoveTheDragged(CommonDrag drag, Transform parent)
    {
        Transform frame = drag.transform.parent;

        frame.SetParent(parent);
        frame.localPosition = Vector3.zero;
    }

    private void UpdateDataEquip(DragItem dragItem, EquipSlotType equipSlotType)
    {
        if (currentHeroEquip == null || currentHeroEquip.data == null)
        {
            Debug.LogWarning("No hero equipped. Cannot update item.");
            return;
        }

        // Clone currentHeroEquip to a new variable
        var newHeroEquip = currentHeroEquip.Clone();
        // Update the newHeroEquip based on the equipSlotType
        switch (equipSlotType)
        {
            case EquipSlotType.Weapon1:
                newHeroEquip.item_1 = dragItem.Data;
                break;
            case EquipSlotType.Weapon2:
                newHeroEquip.item_2 = dragItem.Data;
                break;
        }
        // Update the hero equip in the GameManager
        GameManager.Instance.UpdateEquip(currentHeroEquip, newHeroEquip);
        
        currentHeroEquip = newHeroEquip;
    }
}
