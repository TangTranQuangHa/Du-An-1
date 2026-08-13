using UnityEngine;

public class ManagerUIBar : MonoBehaviour
{
    [SerializeField] private UIBar[] heroUIBars;
    [SerializeField] private UIBar[] enemyUIBars;

    public void AssignEnemyBar(int index, BattleCharacter battleCharacter)
    {
        enemyUIBars[index].gameObject.SetActive(true);
        enemyUIBars[index].GetCharacterStats(battleCharacter);
    }
    public void AssignHeroBar(int index, BattleCharacter battleCharacter)
    {
        heroUIBars[index].gameObject.SetActive(true);
        heroUIBars[index].GetCharacterStats(battleCharacter);
    }
}
