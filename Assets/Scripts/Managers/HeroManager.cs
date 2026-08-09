using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public HeroEquip heroEquip;
    public List<HeroEquip> ownedHeroEquips = new List<HeroEquip>();
    public List<HeroEquip> allHeroEquips = new List<HeroEquip>();
    [SerializeField] private List<DataHero> allHeroes = new List<DataHero>();

    private void Start()
    {
        SetAllHeroEquips();
    }

    //Set Reserve Heroes
    public void SetAllHeroEquips()
    {
        foreach (DataHero hero in allHeroes)
        {
            allHeroEquips.Add(new HeroEquip(hero));
        }
    }

    public void AddNewHero(HeroEquip newHero)
    {
        if (!ownedHeroEquips.Any(hero => hero.data.ID == newHero.data.ID))
        {
            ownedHeroEquips.Add(newHero);
        }
        else
        {
            Debug.LogWarning("Hero with ID " + newHero.data.ID + " already exists in the owned list.");
        }
    }

    // Update Hero
    public void UpdateHeroEquip(HeroEquip updateHero)
    {
        int index = ownedHeroEquips.FindIndex(
            hero => hero.data.ID == updateHero.data.ID);

        if (index >= 0)
        {
            ownedHeroEquips[index] = updateHero;
        }
    }

    // Get Hero
    public HeroEquip TakeHero(int ID)
    {
        return ownedHeroEquips.FirstOrDefault(hero => hero.data.ID == ID);
    }

    public void ClearOwnedHeroEquips()
    {
        ownedHeroEquips.Clear();
    }

    public HeroEquip GetOriginalHeroEquipByID(int ID)
    {
        return allHeroEquips.FirstOrDefault(he => he.data.ID == ID);
    }

    public List<OwnedHero> GetOwnedHeroes()
    {
        var result = new List<OwnedHero>();
        foreach (var ownedHeroEquip in ownedHeroEquips)
        {
            var newOwnedHero = new OwnedHero(
                ownedHeroEquip.data.ID,
                (ownedHeroEquip.item_1 != null) ? ownedHeroEquip.item_1.ID : -1,
                (ownedHeroEquip.item_2 != null) ? ownedHeroEquip.item_2.ID : -1
            );
            result.Add(newOwnedHero);
        }
        return result;
    }
}
