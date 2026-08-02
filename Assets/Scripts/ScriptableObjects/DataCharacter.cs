using UnityEngine;
[CreateAssetMenu(fileName = "Character",menuName ="Data/Character")]
public class DataCharacter : ScriptableObject
{
    public int ID;
    public string Name;
    [TextAreaAttribute]
    public string Describe;
    public float Health;
    public float Damage;
    public Rarity _rarity;
}
