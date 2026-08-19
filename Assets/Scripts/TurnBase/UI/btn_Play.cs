using System;
using UnityEngine;

public class btn_Play : MonoBehaviour
{
    [SerializeField] public Action startBattle;
    [SerializeField] private GameObject pnl_ChoseHero;
    public void OnPlay()
    {
        pnl_ChoseHero.SetActive(false);
        gameObject.SetActive(false);
        startBattle.Invoke();
    }
}
