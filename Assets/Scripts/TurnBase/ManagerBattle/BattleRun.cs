using System;
using System.Collections;
using UnityEngine;

public class BattleRun : MonoBehaviour
{
    private BoxDataBattle boxDataBattle;
    public Action<bool> IsResult;

    public void RunBattle(BoxDataBattle boxDataBattle)
    {
        this.boxDataBattle = boxDataBattle;
        StartCoroutine(RunTurn());
    }

    private IEnumerator RunTurn()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            // Kiểm tra trận đấu kết thúc
            if (CheckBattleEnd())
                yield break;

            BattleCharacter attacker =
                boxDataBattle.TurnBase.Dequeue();

            // Nếu nhân vật đã chết thì bỏ lượt
            if (attacker == null || !attacker.gameObject.activeSelf)
            {
                continue;
            }

            BattleCharacter target = GetTarget(attacker);

            if (target == null)
            {
                yield break;
            }

            // Đánh
            attacker.characterAttack.Attaking(target);

            // Chờ để nhìn thấy hành động
            yield return new WaitForSeconds(1.5f);

            // Đưa người còn sống trở lại Queue
            AddBackQueue(attacker);
        }
    }

    private BattleCharacter GetTarget(BattleCharacter attacker)
    {
        if (IsHero(attacker))
        {
            return GetAliveCharacter(boxDataBattle.Enemy);
        }

        return GetAliveCharacter(boxDataBattle.Heros);
    }

    private BattleCharacter GetAliveCharacter(BattleCharacter[] characters)
    {
        foreach (BattleCharacter character in characters)
        {
            if (character != null && character.gameObject.activeSelf)
            {
                return character;
            }
        }

        return null;
    }

    private bool IsHero(BattleCharacter character)
    {
        foreach (BattleCharacter hero in boxDataBattle.Heros)
        {
            if (hero == character)
                return true;
        }

        return false;
    }

    private void AddBackQueue(BattleCharacter character)
    {
        if (character != null && character.gameObject.activeSelf)
        {
            boxDataBattle.TurnBase.Enqueue(character);
        }
    }

    private bool CheckBattleEnd()
    {
        bool heroAlive = GetAliveCharacter(boxDataBattle.Heros) != null;

        bool enemyAlive = GetAliveCharacter(boxDataBattle.Enemy) != null;

        if (!heroAlive)
        {
            Debug.Log("Battle Lose");
            IsResult.Invoke(false);
            return true;            
        }

        if (!enemyAlive)
        {
            Debug.Log("Battle Win");
            IsResult.Invoke(true);
            return true;
        }

        return false;
    }
}