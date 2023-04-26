using UnityEngine;

namespace AstroShift
{
    [CreateAssetMenu(fileName = "Item", menuName = "SOE/Inventory/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public new string name = "New Item";
        public bool isDefaultItem = false;
        public Sprite iconSprite = null;

        public virtual void Use(IAutomatonable agent)
        {
            Debug.Log("Using the " + name);
        }

        public virtual void RemoveFromInventory(InventoryController inventory)
        {
            inventory.Remove(this);
        }
    }
}