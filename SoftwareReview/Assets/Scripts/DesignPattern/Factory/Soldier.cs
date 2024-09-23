using Sirenix.OdinInspector;
using UnityEngine;

namespace DesignPattern.Factory
{
    public class Soldier : MonoBehaviour
    {
        [SerializeField, Required] private EquipmentFactory equipmentFactory;
        private IWeapon weapon = IWeapon.CreateDefault();
        private IShield shield = IShield.CreateDefault();
        
        private void Start()
        {
            weapon = equipmentFactory.CreateWeapon();
            shield = equipmentFactory.CreateShield();
        }

        [Button("AttackTest")]
        void Attack() => weapon?.Attack();
        
        [Button("DefendTest")]
        void Defend() => shield?.Defend();
    }
}