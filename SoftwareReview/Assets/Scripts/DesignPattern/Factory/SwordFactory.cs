using UnityEngine;

[CreateAssetMenu(fileName = "SwordFactory", menuName = "Weapon/SwordFactory")]
public class SwordFactory : WeaponFactory
{
    public override IWeapon Create()
    {
        return new Sword();
    }
}