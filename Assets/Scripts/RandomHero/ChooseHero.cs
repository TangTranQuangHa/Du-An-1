using UnityEngine;

public class ChooseHero : MonoBehaviour
{
    [SerializeField] private HeroEquip heroEquip;
    public void UpdateCharacterEquip(HeroEquip heroEquip)
    {
        this.heroEquip = heroEquip;
    }
    public void Choose()
    {
        GameManager.Instance.heroManager.AddNewHero(heroEquip);
        GameManager.Instance.managerRecruitHero.FinishChoose();
        transform.parent.gameObject.SetActive(false);
    }
}
