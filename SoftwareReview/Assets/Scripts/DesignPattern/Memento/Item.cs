using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace DesignPattern.Memento
{
    [CreateAssetMenu(fileName = "Item", menuName = "Memento/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        [Required] public Sprite itemSprite;
    }
}