using System.Collections.Generic;
using UnityEngine;

public class CreateCardItem : MonoBehaviour
{
    public List<DataItem> lst_ItemOwner = new();

    private void Start()
    {
        lst_ItemOwner = GameManager.Instance.itemManager.ownedItems;
        CreateCard();
    }

    public void CreateCard()
    {
        foreach (DataItem item in lst_ItemOwner)
        {
            GameObject prefab =
                GameManager.Instance.managerUI.TakeItemCard(item.ID);

            if (prefab != null)
                Instantiate(prefab, transform);
        }
    }
}