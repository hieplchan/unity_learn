using UnityEngine;

namespace StatsAndModifiers
{
    [CreateAssetMenu(fileName = "BaseStats", menuName = "Stats/Base Stats", order = 0)]
    public class BaseStats : ScriptableObject
    {
        public int attack = 10;
        public int defense = 20;
    }
}