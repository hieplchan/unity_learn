using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DesignPattern.Factory
{
    public class Knight : MonoBehaviour
    {
        [SerializeField, Required] private WeaponFactory weaponFactory;
        private IWeapon weapon = IWeapon.CreateDefault();
        
        private void Start()
        {
            if (weaponFactory != null)
                weapon = weaponFactory.Create();
        }

        [Button("AttackTest")]
        void Attack() => weapon?.Attack();
    }
}