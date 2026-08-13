using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerEnemyBattle : MonoBehaviour
{
    [SerializeField] private List<DataEnemy> _enemyDatabase;
    [SerializeField] private List<DataEnemy> _enemyBattle;

    private void Start()
    {
        GenerateEnemyBattle();
    }
    
    private void GenerateEnemyBattle()
    {
        int day = GameManager.Instance.survivalManager.TakeDay();
        List<int> pointDanagers = GenerateDangerPoints(day);
        CreateEnemyBattle(pointDanagers);
    }

    private List<int> GenerateDangerPoints(int day)
    {
        List<int> pointDangers = new List<int>{ 1, 1, 1, 1};
        int limitPointDanger = Mathf.Min(day + 4, 10); ;
        while(true)
        {
            if(pointDangers.Sum() >= limitPointDanger)
                return pointDangers;
            int index = Random.Range(0, pointDangers.Count);
            if (pointDangers[index] >= 3)
                continue;
            if (pointDangers[index] == 2 && day < 4)
                continue;
            else if (pointDangers[index] == 2 && pointDangers.Count(x => x == 3) == 1 && day < 7)
                continue;
            else if (pointDangers[index] == 2 && pointDangers.Count(x => x == 3) == 2 && day < 9)
                continue;
            pointDangers[index] += 1;
        } 
    }

    private void CreateEnemyBattle(List<int> PointDangers)
    {
        for(int i = 0; i < PointDangers.Count; i++)
        {
            _enemyBattle.Add(RollEnemy(PointDangers[i]));
        }
    }

    private DataEnemy RollEnemy(int dangePoint)
    {
        List<DataEnemy> lst_rollEnemy = new List<DataEnemy>();
        foreach(DataEnemy member in _enemyDatabase)
        {
            if (dangePoint == member.PointDanger)
                lst_rollEnemy.Add(member);
        }
        int index = Random.Range(0, lst_rollEnemy.Count);
        return lst_rollEnemy[index];
    }

    public List<DataEnemy> GetEnemyBattle()
    {
        return _enemyBattle;
    }
}
