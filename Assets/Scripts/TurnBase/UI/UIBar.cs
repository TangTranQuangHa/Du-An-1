using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    [SerializeField] private Image img_Fill;
    [SerializeField] private CharacterStats characterStats;
    private void OnDisable()
    {
        characterStats.OnChangeHP -= UpdateChangeBar;
        characterStats.OnDeadCharacter -= TakeOffBar;
    }
    public void GetCharacterStats(BattleCharacter battleCharacter)
    {
        characterStats = battleCharacter.characterStats;
        characterStats.OnChangeHP += UpdateChangeBar;
        characterStats.OnDeadCharacter += TakeOffBar;
        UpdateChangeBar();
    }

    private void UpdateChangeBar()
    {
        img_Fill.fillAmount = (float)characterStats.CurrentHP / characterStats.MaxHP;
    }

    private void TakeOffBar()
    {
        gameObject.SetActive(false);
    }
}
