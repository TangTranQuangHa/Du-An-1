using System.Collections.Generic;
using System.Linq;
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

    public void ClearOwnedItems()
    {
        ownedItems.Clear();
    }

    public DataItem GetDataItemByID(int ID)
    {
        return ItemOrigins.FirstOrDefault(io => io.ID == ID);
    }

    public List<int> GetOwnedItemIDs()
    {
        return ownedItems.Select(oi => oi.ID).ToList();
    }
}