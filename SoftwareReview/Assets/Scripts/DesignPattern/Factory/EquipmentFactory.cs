using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentFactory", menuName = "Weapon/EquipmentFactory")]
public class EquipmentFactory : ScriptableObject
{
    [SerializeField] private WeaponFactory weaponFactory;
    [SerializeField] private ShieldFactory shieldFactory;

    public IWeapon CreateWeapon() => weaponFactory.Create();
    public IShield CreateShield() => shieldFactory.CreateShield();
}