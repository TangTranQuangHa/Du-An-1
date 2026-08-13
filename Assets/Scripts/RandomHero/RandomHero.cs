using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomHero 
{
    private readonly float[] day1 = { 0, 100f, 0, 0 };
    private readonly float[] day2To3Rates = { 50f, 40f, 10f, 0f };
    private readonly float[] day4To7Rates = { 40f, 30f, 29f, 1f };
    private readonly float[] day8To10Rates = { 40f, 30f, 20f, 10f };

    private HeroEquip[] results = new HeroEquip[3];

    public HeroEquip[] StartRandom(int currentDay)
    {
        for(int i = 0; i < results.Length; i++)
        {
            Rarity rare = GetRandomRarity(currentDay);
            results[i] = RollHero(rare);
        }
        return results;
    }

    // Hàm quay ngẫu nhiên Phẩm chất (Rarity)
    private Rarity GetRandomRarity(int currentDay)
    {
        float[] currentRates;

        if (currentDay <= 1) currentRates = day1;
        else if (currentDay <= 3) currentRates = day2To3Rates;
        else if (currentDay <= 7) currentRates = day4To7Rates;
        else currentRates = day8To10Rates;

        float randomPoint = Random.Range(0f, 100f);
        float cumulative = 0f;

        for (int i = 0; i < currentRates.Length; i++)
        {
            cumulative += currentRates[i];
            if (randomPoint <= cumulative)
            {
                return (Rarity)i;
            }
        }

        return Rarity.Bronze;
    }
    // Roll nhân vật theo Phẩm chất đã cho
    private HeroEquip RollHero(Rarity rare)
    {
        //Lấy Hero theo phẩm chất và không trùng
        List<HeroEquip> Heros = GameManager.Instance.heroManager.GetUnownedHeroes().Where(hero => hero.data._rarity == rare).ToList();

        //Random chọn 1 Tướng trong danh sách đã lọc
        while (true)
        {
            int randomIndex = Random.Range(0, Heros.Count-1);
            HeroEquip selectedHero = Heros[randomIndex];
            if (results.Contains(selectedHero)) continue;
            return selectedHero;
        }
    }
}
