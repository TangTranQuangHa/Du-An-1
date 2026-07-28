using UnityEngine;


[CreateAssetMenu(fileName = "DataItemEffect", menuName = "Item Data/Effects/DamagePlus")]
public class DamagePlusEffect : DataItemEffect
{
    public float damagePlus;

    public override void ApplyEffect(GameObject target)
    {
        // Modified this after hero object add
    }
}
