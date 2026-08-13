using System.Collections.Generic;
using UnityEngine;

public class StartBattle: MonoBehaviour
{
    [SerializeField] private ManagerEnemyBattle managerEnemyBattle;
    [SerializeField] private ManagerHeroBattle managerHeroBattle;
    [SerializeField] private ManagerUIBar managerUIBar;
    [SerializeField] private ManagerPosCharacter managerPos;

    public void SetBattle(ManagerEnemyBattle managerEnemyBattle, ManagerHeroBattle managerHeroBattle, ManagerUIBar managerUIBar, ManagerPosCharacter managerPos)
    {
        this.managerEnemyBattle = managerEnemyBattle;
        this.managerHeroBattle = managerHeroBattle;
        this.managerUIBar = managerUIBar;
        this.managerPos = managerPos;
    }

    public BoxDataBattle SetFight()
    {
        BattleCharacter[] heroes = SpawnHero();
        BattleCharacter[] enemies = SpawnEnemy();

        Queue<BattleCharacter> turnBase = AddQueue(heroes, enemies);

        return new BoxDataBattle( heroes, enemies, turnBase);
    }

    private BattleCharacter[] SpawnHero()
    {
        DataHero[] dataHeroes = managerHeroBattle.HeroBattle();

        BattleCharacter[] heroes = new BattleCharacter[dataHeroes.Length];

        for (int i = 0; i < dataHeroes.Length; i++)
        {
            if (dataHeroes[i] == null) continue;
            GameObject heroObject = Instantiate( dataHeroes[i].Enity, managerPos.GetHeroPosition(i));

            BattleCharacter battleCharacter =heroObject.GetComponent<BattleCharacter>();

            heroes[i] = battleCharacter;

            managerUIBar.AssignHeroBar( i, battleCharacter);
        }

        return heroes;
    }

    private BattleCharacter[] SpawnEnemy()
    {
        List<DataEnemy> dataEnemies = managerEnemyBattle.GetEnemyBattle();

        BattleCharacter[] enemies = new BattleCharacter[dataEnemies.Count];

        for (int i = 0; i < dataEnemies.Count; i++)
        {
            GameObject enemyObject = Instantiate( dataEnemies[i].Enity, managerPos.GetEnemyPosition(i));

            BattleCharacter battleCharacter = enemyObject.GetComponent<BattleCharacter>();

            enemies[i] = battleCharacter;

            managerUIBar.AssignEnemyBar( i, battleCharacter);
        }

        return enemies;
    }

    private Queue<BattleCharacter> AddQueue( BattleCharacter[] heroes, BattleCharacter[] enemies)
    {
        Queue<BattleCharacter> turnBase = new Queue<BattleCharacter>();

        foreach (BattleCharacter hero in heroes)
            turnBase.Enqueue(hero);

        foreach (BattleCharacter enemy in enemies)
            turnBase.Enqueue(enemy);

        return turnBase;
    }
}