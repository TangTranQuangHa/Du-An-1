using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardUI : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject winPanel;

    [Header("Reward")]
    [SerializeField] private Image imgReward;
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtItemName;
    [SerializeField] private TMP_Text txtAmount;

    [Header("Scene")]
    [SerializeField] private string gameplaySceneName = "Gameplay";

    private void Awake()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void ShowWin(DataItem rewardItem, int amount)
    {
        if (rewardItem == null)
        {
            Debug.LogWarning("Reward item is null!");
            return;
        }

        if (txtTitle != null)
            txtTitle.text = "CHIẾN THẮNG!";

        if (txtItemName != null)
            txtItemName.text = rewardItem.Name;

        if (txtAmount != null)
            txtAmount.text = "x" + amount;

        if (imgReward != null)
        {
            imgReward.sprite = rewardItem.Icon;
            imgReward.enabled = rewardItem.Icon != null;
        }

        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void BackToGameplay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameplaySceneName);
    }
}