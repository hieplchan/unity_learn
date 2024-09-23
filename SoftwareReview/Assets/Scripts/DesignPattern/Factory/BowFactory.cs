using UnityEngine;

[CreateAssetMenu(fileName = "BowFactory", menuName = "Weapon/BowFactory")]
public class BowFactory : WeaponFactory
{
    public override IWeapon Create()
    {
        return new Bow();
    }
}