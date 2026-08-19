using TMPro;
using UnityEngine;

public class StatsCard : MonoBehaviour
{
    [SerializeField] private DataHero data;
    [SerializeField] private HeroEquip heroEquip;

    [SerializeField] private TMP_Text txt_Name;
    [SerializeField] private TMP_Text txt_Hp;
    [SerializeField] private TMP_Text txt_Damage;

    public DataHero Data => data;

    private void Start()
    {
        heroEquip = GameManager.Instance.heroManager.TakeHero(Data.ID);
        SetStat();
    }

    public void SetStat()
    {
        if (heroEquip == null)
            return;

        txt_Name.text = data.Name;
        txt_Hp.text = CalculateEquipmentValue.CalHealth(heroEquip).ToString();
        txt_Damage.text = CalculateEquipmentValue.CalDamage(heroEquip).ToString();
    }

    public void UpdateStat(HeroEquip heroEquip)
    {
        if (heroEquip == null)
            return;

        txt_Name.text = data.Name;
        txt_Hp.text = CalculateEquipmentValue.CalHealth(heroEquip).ToString();
        txt_Damage.text = CalculateEquipmentValue.CalDamage(heroEquip).ToString();
    }
}