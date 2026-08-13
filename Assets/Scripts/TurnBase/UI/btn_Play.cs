using System;
using UnityEngine;

public class btn_Play : MonoBehaviour
{
    [SerializeField] public Action startBattle;
    [SerializeField] private GameObject scrollViewHero;
    [SerializeField] private GameObject managerSlotBatlle;
    public void OnPlay()
    {
        scrollViewHero.SetActive(false);
        managerSlotBatlle.SetActive(false);
        gameObject.SetActive(false);
        startBattle.Invoke();
    }
}
