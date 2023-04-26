using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AstroShift
{
    [System.Serializable]
    public class InventoryController
    {
        [SerializeField] int Space = 20;
        [SerializeField] List<Item> items = new List<Item>();

        public bool AddItem(Item item)
        {
            if (item.isDefaultItem) return false;

            if (items.Count >= Space) return false;

            items.Add(item);

            return true;
        }

        public void Remove(Item item)
        {
            items.Remove(item);
        }
    }
}