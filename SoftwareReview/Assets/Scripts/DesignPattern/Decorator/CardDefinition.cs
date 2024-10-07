using UnityEngine;

public enum CardType
{
    Battle,
    Damage,
    Health
}

[CreateAssetMenu(menuName = "Card/CardDefinition", fileName = "New Card")]
public class CardDefinition : ScriptableObject
{
    public int value = 10;
    public CardType type = CardType.Battle;
}

public static class CardFactory
{
    public static ICard Create(CardDefinition definition)
    {
        return definition.type switch
        {
            CardType.Damage => new DamageDecorator(definition.value),
            CardType.Health => new HealthDecorator(definition.value), 
            _ => new BattleCard(definition.value)
        };
    }
}