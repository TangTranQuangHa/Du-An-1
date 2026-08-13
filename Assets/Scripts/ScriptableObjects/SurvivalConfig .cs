using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SurvivalConfig", menuName = "Data/SurvivalConfig")]
public class SurvivalConfig : ScriptableObject
{
    public List<DayMultiplier> dayMultipliers;
    public List<EnvironmentMultiplier> environmentMultipliers;
}
