using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Food;
    private void Awake()
    {
        txt_Food = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        SurvivalManager survivalManager = GameManager.Instance.survivalManager;
        survivalManager.UpdateConsumption();
        txt_Food.text = $"Food: {survivalManager.TakeMeatConsumption()} / {survivalManager.TakeOwnerMeat()}";
    }
}
