using System.Collections.Generic;
using UnityEngine;

public class CreateCardCharacter : MonoBehaviour
{
    public List<HeroEquip> lst_OwnerHero = new();

    private void Start()
    {
        lst_OwnerHero = GameManager.Instance.heroManager.ownedHeroEquips;
        CreateCard();
    }

    public void CreateCard()
    {
        foreach (HeroEquip hero in lst_OwnerHero)
        {
            GameObject prefab =
                GameManager.Instance.managerUI.TakeHeroCard(hero.data.ID);

            if (prefab != null)
                Instantiate(prefab, transform);
        }
    }
}