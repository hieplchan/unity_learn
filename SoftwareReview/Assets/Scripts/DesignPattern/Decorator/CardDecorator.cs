using System;
using UnityEngine;

public abstract class CardDecorator : ICard
{
    protected readonly int _value;
    protected ICard _card;

    protected CardDecorator(int value)
    {
        _value = value;
    }

    public void Decorate(ICard card)
    {
        if (ReferenceEquals(this, card))
        {
            // throw new InvalidOperationException("Cannot decorate self");
            Debug.LogWarning("Cannot decorate card");
            return;
        }
        
        if (_card is CardDecorator decorator)
        {
            decorator.Decorate(card);
        }
        else
        {
            _card = card;
        }
    }

    public virtual int Play()
    {
        Debug.Log("Playing Decorator card with value: " + _value);
        return _card?.Play() + _value ?? _value;
    }
}

public class DamageDecorator : CardDecorator
{
    public DamageDecorator(int value) : base(value)
    {
    }

    public override int Play()
    {
        Debug.Log("Double damage of decorated card");
        return _card?.Play() * 2 ?? 0;
    }
}

public class HealthDecorator : CardDecorator
{
    public HealthDecorator(int value) : base(value)
    {
    }

    public override int Play()
    {
        Debug.Log("Playing Health Decorator card with value: " + _value);
        HealthPlayer();
        return _card?.Play() ?? 0;
    }

    private void HealthPlayer()
    {
    }
}