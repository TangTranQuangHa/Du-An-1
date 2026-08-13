using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : CharacterStats
{
    protected override int SetHealth()
    {
        SurvivalManager survivalManager = GameManager.Instance.survivalManager;
        float hpDay = survivalManager.TakeDayMultiplier().hp;
        float hpEnvironment = survivalManager.TakeEnvironmentMultiplier(SceneManager.GetActiveScene().name).hp;

        return Mathf.RoundToInt(Data.Health * hpDay * hpEnvironment);
    }
}
