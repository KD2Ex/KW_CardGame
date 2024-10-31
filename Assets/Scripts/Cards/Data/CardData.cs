using UnityEngine;

[CreateAssetMenu]
public class CardData : ScriptableObject
{
    public int Health;
    public int Damage;
    public string Name;
    public StatusEffect[] Effects;
    public int[] AttackDirections;

    [Header("Number in the Deck")] public int Number;
}
