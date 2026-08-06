using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Toàn bộ Item trong game
    public List<DataItem> ItemOrigins = new();

    // Item người chơi sở hữu
    public List<DataItem> ownedItems = new();

    // Thêm Item
    public void AddItem(DataItem item)
    {
        if (item == null)
            return;

        ownedItems.Add(item);
    }

    // Xóa Item
    public void SubItem(DataItem item)
    {
        if (item == null)
            return;

        ownedItems.Remove(item);
    }
}