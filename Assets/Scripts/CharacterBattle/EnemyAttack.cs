using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : CharacterAttack
{
    protected override int Damage()
    {
        SurvivalManager survivalManager = GameManager.Instance.survivalManager;
        float damageDay = survivalManager.TakeDayMultiplier().damage;
        float damageEnvironment = survivalManager.TakeEnvironmentMultiplier(SceneManager.GetActiveScene().name).damage;

        return Mathf.RoundToInt(battleCharacter.characterStats.Data.Health * damageDay * damageEnvironment);
    }
}
