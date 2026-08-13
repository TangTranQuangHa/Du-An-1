using System.Collections.Generic;
using UnityEngine;

public class BoxDataBattle 
{
    public BattleCharacter[] Heros;
    public BattleCharacter[] Enemy;
    public Queue<BattleCharacter> TurnBase;

    public BoxDataBattle(BattleCharacter[] heros, BattleCharacter[] enemy, Queue<BattleCharacter> turnBase)
    {
        Heros = heros;
        Enemy = enemy;
        TurnBase = turnBase;
    }
}
