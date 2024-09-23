using UnityEngine;

[CreateAssetMenu(fileName = "GenericShieldFatory", menuName = "Weapon/GenericShieldFatory")]
public class GenericShieldFatory : ShieldFactory
{
    public override IShield CreateShield()
    {
        return new Shield();
    }
}