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
        ownedHeroEquips[
            ownedHeroEquips
                .FindIndex(hero => hero.data.ID == updateHero.data.ID)]
            = updateHero;
    }

    // Get Hero
    public HeroEquip TakeHero(int ID)
    {
        return ownedHeroEquips.FirstOrDefault(hero => hero.data.ID == ID);
    }
}
