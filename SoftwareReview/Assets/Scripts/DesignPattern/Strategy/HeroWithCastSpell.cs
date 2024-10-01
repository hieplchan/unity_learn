using System;
using UnityEngine;

namespace DesignPattern.Strategy
{
    public class HeroWithCastSpell : MonoBehaviour
    {
        [SerializeField] private SpellStrategy[] spells;

        private void OnEnable()
        {
            CastSpellView.OnButtonPressed += CastSpell;
        }

        private void OnDestroy()
        {
            CastSpellView.OnButtonPressed -= CastSpell;
        }

        private void CastSpell(int index)
        {
            spells[index].CastSpell(transform);
        }
    }
}