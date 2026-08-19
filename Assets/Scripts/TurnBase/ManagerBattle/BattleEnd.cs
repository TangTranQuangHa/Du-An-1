using UnityEngine.SceneManagement;
using UnityEngine;

public class BattleEnd : MonoBehaviour
{
    public void Win(RewardUI rewardUI)
    {
        GiveReward(rewardUI);
    }

    public void Lose()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void GiveReward(RewardUI rewardUI)
    {
        int day =
            GameManager.Instance.survivalManager.TakeDay();

        string sceneName =
            SceneManager.GetActiveScene().name;
        GameManager gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManager NULL");
            return;
        }

        if (gameManager.rewardManager == null)
        {
            Debug.LogError("RewardManager NULL");
            return;
        }

        if (gameManager.survivalManager == null)
        {
            Debug.LogError("SurvivalManager NULL");
            return;
        }

        if (gameManager.itemManager == null)
        {
            Debug.LogError("ItemManager NULL");
            return;
        }

        BattleReward reward =
            gameManager.rewardManager.GenerateReward(
                day,
                sceneName
            );

        foreach (DataItem item in reward.Items)
        {
            gameManager.itemManager.AddItem(item);
        }

        gameManager.survivalManager.PassDay(
            reward.Meat,
            reward.Water
        );

        gameManager.Save();

        rewardUI.gameObject.SetActive(true);
        rewardUI.ShowWin(reward.Items, reward.Water, reward.Meat);
    }
}
