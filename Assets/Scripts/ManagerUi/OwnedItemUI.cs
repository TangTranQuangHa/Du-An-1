using UnityEngine;

public class OwnedItemUI : MonoBehaviour
{
    void Start()
    {
        RefreshOwnedItemsUI();
        GameManager.Instance.OnGameLoaded += RefreshOwnedItemsUI;
    }

    void OnDisable()
    {
        GameManager.Instance.OnGameLoaded -= RefreshOwnedItemsUI;
    }

    private void RefreshOwnedItemsUI()
    {
        ClearAllChildren();

        var gm = GameManager.Instance;
        var ownItems = gm.itemManager.ownedItems;
        
        foreach (var ownedItem in ownItems)
        {
            var originalItemCard = gm.managerUI.TakeItemCard(ownedItem.ID);
            Instantiate(originalItemCard, transform);
        }
    }

    private void ClearAllChildren()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
