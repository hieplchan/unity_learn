using System.Collections.Generic;

namespace DesignPattern.Memento
{
    public class HotBar : Storage
    {
        public Memento CreateMemento() => new Memento(new List<Item>(items));

        public void SetMemento(Memento memento)
        {
            items = memento.GetItem();
            for (int i = 0; i < items.Count; i++)
            {
                slots[i].UpdateUI(items[i]);
            }
        }
        
        public class Memento
        {
            List<Item> Items { get; }

            public Memento(List<Item> items)
            {
                Items = items;
            }

            public List<Item> GetItem() => Items;
        }
    }
}