using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Memento
{
    public class Storage : MonoBehaviour
    {
        [Tooltip("Static storage cannot be swapped out - like Spellbooks")] 
        [SerializeField] public bool staticStorage;
        
        [SerializeField] protected List<UISlot> slots = new List<UISlot>();
        [SerializeField] protected List<Item> items = new List<Item>();

        private UISlot _swapeUISlot;

        private void Start()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].UpdateUI(items[i]);
                slots[i].SetupStorage(this);
                slots[i].SetupMouseDrag(this);
            }
        }

        public void SwapItem(UISlot slot)
        {
            if (_swapeUISlot == null)
            {
                _swapeUISlot = slot;
            }
            else if (_swapeUISlot == slot)
            {
                _swapeUISlot = null;
            }
            else
            {
                Storage storage1 = _swapeUISlot.GetStorage();
                int index1 = storage1.GetItemIndex(_swapeUISlot);
                Item item1 = storage1.GetItem(index1);

                Storage storage2 = slot.GetStorage();
                int index2 = storage2.GetItemIndex(slot);
                Item item2 = storage2.GetItem(index2);
                
                if (!storage1.staticStorage)
                {
                    storage1.SetItemSlot(index1, item2);
                    _swapeUISlot.UpdateUI(item2);
                }

                if (!storage2.staticStorage)
                {
                    storage2.SetItemSlot(index2, item1);
                    slot.UpdateUI(item1);
                }

                _swapeUISlot = null;
            }
        }

        public void ClearSwap() => _swapeUISlot = null;

        int GetItemIndex(UISlot slot) => slots.IndexOf(slot);
        Item GetItem(int index) => items[index];
        void SetItemSlot(int index, Item item) => items[index] = item;
    }
}