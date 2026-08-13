using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerHeroBattle : MonoBehaviour
{
    [SerializeField] private SlotHero[] _SlotHeroes;

    public DataHero[] HeroBattle()
    {
        DataHero[] dataHeroes = new DataHero[4];
        
        for(int i = 0; i < dataHeroes.Length; i++)
        {
            if (_SlotHeroes[i].DragCurrent == null) continue;
            dataHeroes[i] = _SlotHeroes[i].DragCurrent.GetComponent<StatsCard>().Data;
        }
        
        return dataHeroes;
    }
}
