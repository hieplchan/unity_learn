using UnityEngine;

public class ManaComponent : MonoBehaviour, IVisitable
{
    public int mana = 50;
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        Debug.Log("ManaComponent.Accept");
    }
}