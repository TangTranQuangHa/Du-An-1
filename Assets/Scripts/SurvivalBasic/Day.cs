using TMPro;
using UnityEngine;

public class Day : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt_Day;
    private void Awake()
    {
        txt_Day = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        txt_Day.text = "Day: " + GameManager.Instance.survivalManager.TakeDay();
    }
}
