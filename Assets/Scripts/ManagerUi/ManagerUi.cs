using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    [Header("Danh sách Character Card")]
    public List<GameObject> lst_CharacterCard = new List<GameObject>();

    [Header("Danh sách Item Card")]
    public List<GameObject> lst_ItemCard = new List<GameObject>();

    /// <summary>
    /// Lấy Character Card theo ID
    /// </summary>
    public GameObject TakeCharacterCard(int id)
    {
        foreach (GameObject card in lst_CharacterCard)
        {
            if (card == null)
                continue;

            CharacterCard character = card.GetComponent<CharacterCard>();

            if (character != null && character.ID == id)
            {
                return card;
            }
        }

        Debug.LogWarning("Không tìm thấy Character Card có ID = " + id);
        return null;
    }

    /// <summary>
    /// Lấy Item Card theo ID
    /// </summary>
    public GameObject TakeItemCard(int id)
    {
        foreach (GameObject card in lst_ItemCard)
        {
            if (card == null)
                continue;

            ItemCard item = card.GetComponent<ItemCard>();

            if (item != null && item.ID == id)
            {
                return card;
            }
        }

        Debug.LogWarning("Không tìm thấy Item Card có ID = " + id);
        return null;
    }
}