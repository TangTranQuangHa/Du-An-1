using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Danh sách toàn bộ Item trong game
    public List<DataItem> ItemOrigins = new List<DataItem>();

    // Danh sách Item người chơi đang sở hữu
    public List<DataItem> EquippedItems = new List<DataItem>();

    // Thêm Item vào kho của người chơi
    public void AddItem(DataItem item)
    {
        if (item == null)
            return;

        EquippedItems.Add(item);

        Debug.Log($"Đã thêm {item.Name}");
    }

    // Xóa Item khỏi kho
    public void SubItem(DataItem item)
    {
        if (item == null)
            return;

        if (EquippedItems.Contains(item))
        {
            EquippedItems.Remove(item);
            Debug.Log($"Đã xóa {item.Name}");
        }
    }
}