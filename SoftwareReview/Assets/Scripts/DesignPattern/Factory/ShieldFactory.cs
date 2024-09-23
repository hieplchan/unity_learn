using UnityEngine;

public interface IShield
{
    public void Defend();

    static IShield CreateDefault()
    {
        return new Shield();
    }
}

public class Shield : IShield
{
    public void Defend()
    {
        Debug.Log("Shield Defend");
    }
}

public abstract class ShieldFactory : ScriptableObject
{
    public abstract IShield CreateShield();
}