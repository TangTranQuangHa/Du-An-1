using System;
using System.Collections.Generic;

[Serializable]
public class EnvironmentReward
{
    public EnvironmentType environment;

    public List<RewardRule> rewardRules;
}
