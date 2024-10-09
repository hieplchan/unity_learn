using UnityEngine.Serialization;

public interface IVisitable
{
    void Accept(IVisitor visitor);
}