using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public List<GameObject> lst_CharacterCard = new();
    public List<GameObject> lst_ItemCard = new();

    // Lấy prefab Hero Card
    public GameObject TakeHeroCard(int id)
    {
        return lst_CharacterCard.Find(card =>
        {
            StatsCard stats = card.GetComponent<StatsCard>();
            return stats != null && stats.Data.ID == id;
        });
    }

    // Lấy prefab Item Card
    public GameObject TakeItemCard(int id)
    {
        return lst_ItemCard.Find(card =>
        {
            DragItem drag = card.GetComponent<DragItem>();
            return drag != null && drag.Data.ID == id;
        });
    }
}