using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DataItem", menuName = "Item Data/Item")]
public class DataItem : ScriptableObject
{
    public int ID;
    public string Name;
    // describe the item
    public string Description;
    public DataItemEffect Effect; // Delegate effect

    public void Use(GameObject target)
    {
        if (Effect != null)
        {
            Effect.ApplyEffect(target);
        }
        else
        {
            Debug.LogWarning($"Item {Name} has no effect assigned.");
        }
    }

}
