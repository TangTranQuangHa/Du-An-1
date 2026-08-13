using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "RewardConfig",
    menuName = "Data/Reward Config"
)]
public class RewardConfig : ScriptableObject
{
    public List<EnvironmentReward> environments;
}
