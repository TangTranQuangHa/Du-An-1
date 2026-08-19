using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardUI : MonoBehaviour
{
    [Header("Reward")]
    [SerializeField] private TMP_Text txt_ItemName;
    [SerializeField] private TMP_Text txt_Water;
    [SerializeField] private TMP_Text txt_Food;
    public void ShowWin(List<DataItem> rewardItem, int amountWater, int amountFood)
    {
        if (txt_Water != null)
            txt_Water.text = "WATER x" + amountWater;
        if (txt_Food != null)
            txt_Food.text = "FOOD x" + amountFood;
        if (rewardItem == null) return;
        foreach(DataItem member in rewardItem)
        {
            txt_ItemName.text += $"\n{member.name.ToUpper()}";
        }
    }
}