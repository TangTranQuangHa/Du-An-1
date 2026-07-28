using UnityEngine;

[CreateAssetMenu(fileName = "DataItemEffect", menuName = "Item Data/Effects/MaxHealthPlus")]
public class MaxHealthPlus : DataItemEffect
{
    
    public int maxHealthPlus;

    public override void ApplyEffect(GameObject target)
    {
        // Modified this after hero object add
    }
}
