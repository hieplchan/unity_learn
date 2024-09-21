using System;
using UnityEngine;

namespace AbilitySystem
{
    public class AbilitySystem : MonoBehaviour
    {
        [SerializeField] private AbilityView view;
        [SerializeField] private AbilityData[] datas;
        private AbilityController abilityController;

        private void Awake()
        {
            abilityController = new AbilityController.Builder()
                .WithAbility(datas)
                .Build(view);
        }

        private void Update()
        {
            abilityController.Update(Time.deltaTime);
        }
    }
}