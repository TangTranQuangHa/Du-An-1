using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private RewardConfig rewardConfig;

    private ItemManager itemManager;

    private void Awake()
    {
        itemManager = GameManager.Instance.itemManager;
    }
    //Main Method
    public BattleReward GenerateReward( int day, string sceneName)
    {
        //Find evironment and rule
        EnvironmentType environment = GetEnvironment(sceneName);
        RewardRule rule = GetRewardRule(day, environment);

        if (rule == null)
        {
            Debug.LogWarning($"Không tìm thấy RewardRule - Day: {day}, Environment: {environment}");
            return new BattleReward(new List<DataItem>(),0,0);
        }
        
        //Random amount can take item
        int amount = Random.Range(rule.minItem, rule.maxItem + 1);

        //List return
        List<DataItem> items = new List<DataItem>();

        //random Rarity => random Item(rarity) => add return lst
        for (int i = 0; i < amount; i++)
        {
            Rarity rarity =
                RollRarity(rule);

            DataItem item =
                RollItem(rarity);

            if (item != null)
            {
                items.Add(item);
            }
        }

        int meat = Random.Range(rule.minMeat, rule.maxMeat + 1);

        int water = Random.Range( rule.minWater, rule.maxWater + 1);

        return new BattleReward(items,meat,water);
    }

    //Take environmentType from RewardConfig
    private EnvironmentType GetEnvironment(string sceneName)
    {
        switch (sceneName)
        {
            case "AquaArea":
                return EnvironmentType.Lake;

            case "ForestArea":
                return EnvironmentType.Forest;

            case "CityArea":
                return EnvironmentType.City;

            default:

                Debug.LogError(
                    $"Không tìm thấy Environment cho Scene: {sceneName}"
                );

                return EnvironmentType.Lake;
        }
    }

    //Take RewardRule from RewardConfig follows day and environment
    private RewardRule GetRewardRule( int day, EnvironmentType environment)
    {
        EnvironmentReward environmentReward = rewardConfig.environments.FirstOrDefault(x => x.environment == environment);

        if (environmentReward == null)
            return null;

        return environmentReward.rewardRules.FirstOrDefault(x => day >= x.minDay && day <= x.maxDay);
    }


    //Base on rule take Rarity
    private Rarity RollRarity(RewardRule rule)
    {
        float randomPoint = Random.Range(0f, 100f);

        float cumulative = 0f;

        cumulative += rule.bronzeRate;

        if (randomPoint < cumulative)
            return Rarity.Bronze;

        cumulative += rule.silverRate;

        if (randomPoint < cumulative)
            return Rarity.Silver;

        cumulative += rule.goldRate;

        if (randomPoint < cumulative)
            return Rarity.Gold;

        return Rarity.Legendary;
    }


    //Take Item same rarity 
    private DataItem RollItem(Rarity rarity)
    {
        List<DataItem> candidates = itemManager.ItemOrigins.Where(item => item._rarity == rarity).ToList();

        if (candidates.Count == 0)
        {
            Debug.LogWarning(
                $"Không có Item thuộc rarity {rarity}"
            );

            return null;
        }

        int index = Random.Range(0, candidates.Count);

        return candidates[index];
    }
}

