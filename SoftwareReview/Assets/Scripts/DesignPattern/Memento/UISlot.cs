using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace DesignPattern.Memento
{
    public class UISlot : MonoBehaviour
    {
        public Image itemImage;
        private Storage _storage;
        private MouseDrag _mouseDrag;

        public void SetupStorage(Storage storage)
        {
            _storage = storage;
        }

        public Storage GetStorage()
        {
            return _storage;
        }

        public void UpdateUI(Item item)
        {
            if (item == null)
            {
                itemImage.sprite = null;
                return;
            }
            itemImage.sprite = item.itemSprite;
        }

        public void SetupMouseDrag(Storage storage)
        {
            _mouseDrag = gameObject.GetOrAdd<MouseDrag>();
            _mouseDrag.SetupStorage(_storage, this);
        }
    }
}