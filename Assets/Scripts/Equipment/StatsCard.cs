using TMPro;
using UnityEngine;

public class StatsCard : MonoBehaviour
{
    [SerializeField] private DataHero data;

    [SerializeField] private TMP_Text txt_Name;
    [SerializeField] private TMP_Text txt_Hp;
    [SerializeField] private TMP_Text txt_Damage;

    public void SetStat(HeroEquip heroEquip)
    {
        if (heroEquip == null)
            return;

        data = heroEquip.data;

        txt_Name.text = data.Name;
        txt_Hp.text = CalculateEquipmentValue.CalHealth(heroEquip).ToString();
        txt_Damage.text = CalculateEquipmentValue.CalDamage(heroEquip).ToString();
    }

    public void UpdateStat(HeroEquip heroEquip)
    {
        if (heroEquip == null)
            return;

        txt_Hp.text = CalculateEquipmentValue.CalHealth(heroEquip).ToString();
        txt_Damage.text = CalculateEquipmentValue.CalDamage(heroEquip).ToString();
    }
}