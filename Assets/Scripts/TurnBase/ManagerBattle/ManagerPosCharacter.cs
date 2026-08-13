using System.Collections.Generic;
using UnityEngine;

public class ManagerPosCharacter : MonoBehaviour
{
    [SerializeField] private List<Transform> _enemiesPos;
    [SerializeField] private List<Transform> _heroesPos;

    public Transform GetEnemyPosition(int index)
    {
        return _enemiesPos[index];
    }

    public Transform GetHeroPosition(int index)
    {
        return _heroesPos[index];
    }
}
