using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalManager : MonoBehaviour
{
    [SerializeField] private int DayCurrent;
    [SerializeField] private int WaterCurrent;
    [SerializeField] private int MeatCurrent;
    [SerializeField] private int WaterConsumption;
    [SerializeField] private int MeatConsumption;
    [SerializeField] private SurvivalConfig survivalConfig;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Reset();
    }
    public void UpdateConsumption()
    {
        WaterConsumption = 0;
        MeatConsumption = 0;

        foreach (HeroEquip hero in GameManager.Instance.heroManager.ownedHeroEquips)
        {
            WaterConsumption += hero.data.Water;
            MeatConsumption += hero.data.Meat;
        }
    }
    public void PassDay(int meatReward, int waterReward)
    {
        DayCurrent++;
        UpdateConsumption();
        this.WaterCurrent += waterReward - WaterConsumption;
        this.MeatCurrent += meatReward - MeatConsumption;
        if (WaterCurrent <= 0 || MeatCurrent <= 0)
            SceneManager.LoadScene("GameOver");
        else if (DayCurrent == 9)
            SceneManager.LoadScene("GameVictory");
    }
    public int TakeDay()
    {
        return DayCurrent;
    }
    public int TakeOwnerWater()
    {
        return WaterCurrent;
    }
    public int TakeOwnerMeat()
    {
        return MeatCurrent;
    }
    public int TakeWaterConsumption()
    {
        return WaterConsumption;
    }
    public int TakeMeatConsumption()
    {
        return MeatConsumption;
    }
    public DayMultiplier TakeDayMultiplier()
    {
        foreach(DayMultiplier member in survivalConfig.dayMultipliers)
        {
            if (DayCurrent == member.day)
                return member;
        }
        return null;
    }
    public EnvironmentMultiplier TakeEnvironmentMultiplier(string sceneName)
    {
        EnvironmentType environment;
        switch (sceneName)
        {
            case "AquaArea":
                environment = EnvironmentType.Lake;
                break;

            case "ForestArea":
                environment = EnvironmentType.Forest;
                break;

            case "CityArea":
                environment = EnvironmentType.City;
                break;

            default:
                Debug.LogError($"Không tìm thấy Environment cho Scene: {sceneName}");
                return null;
        }

        foreach (EnvironmentMultiplier member in survivalConfig.environmentMultipliers)
        {
            if (member.environment == environment)
            {
                return member;
            }
        }
        return null;
    }

    public void Reset()
    {
        WaterCurrent = 20;
        MeatCurrent = 20;
        DayCurrent = 1;
    }

    public void SetDay(int day)
    {
        DayCurrent = day;
    }

    public void SetOwnerWater(int water)
    {
        WaterCurrent = water;
    }
    public void SetOwnerMeat(int meat)
    {
        MeatCurrent = meat;
    }
}
