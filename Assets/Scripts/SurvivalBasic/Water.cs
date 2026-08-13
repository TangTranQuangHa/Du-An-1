using TMPro;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Water;
    private void Awake()
    {
        txt_Water = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        SurvivalManager survivalManager = GameManager.Instance.survivalManager;
        survivalManager.UpdateConsumption();
        txt_Water.text = $"Water: {survivalManager.TakeWaterConsumption()} / {survivalManager.TakeOwnerWater()}";
    }
}
