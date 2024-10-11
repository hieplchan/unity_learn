using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DesignPattern.Memento
{
    public class MouseDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Storage _storage;
        private UISlot _slot;
        private GameObject _dragInstance;

        public void SetupStorage(Storage storage, UISlot slot)
        {
            _storage = storage;
            _slot = slot;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _storage.SwapItem(_slot);

            _dragInstance = new GameObject("Drag " + _slot.name);
            var image = _dragInstance.AddComponent<Image>();

            image.sprite = _slot.itemImage.sprite;
            image.raycastTarget = false;
            
            _dragInstance.transform.SetParent(_storage.transform);
            _dragInstance.transform.localScale = Vector3.one;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_dragInstance != null)
                _dragInstance.transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject is GameObject targetObj)
            {
                var targetSlot = targetObj.GetComponentInParent<UISlot>();
                if (targetSlot != null)
                {
                    _storage.SwapItem(targetSlot);
                    EventSystem.current.SetSelectedGameObject(targetObj);
                }
            }
            
            _storage.ClearSwap();
            
            if (_dragInstance != null)
                Destroy(_dragInstance);
        }
    }
}