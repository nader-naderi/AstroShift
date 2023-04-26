using UnityEngine;

namespace AstroShift
{
    public enum EEquipemntTypes { Weapon = 0, Head = 1, Chest = 2, Hands = 3, Legs = 4 }
    [CreateAssetMenu(fileName = "Equipment", menuName = "SOE/Inventory/Equipment", order = 0)]
    public class Equipment : Item
    {
        public bool visualizeit = false;
        public EEquipemntTypes equipemntType;
        public GameObject model;

        public int armorModifier;
        public int damageModifier;


        public override void Use(IAutomatonable agent)
        {
            base.Use(agent);

            // Equip it.
            agent.Equipments.Equip(this, agent.Inventory);

            // Remove it from the inventory.
            // RemoveFromInventory();
        }
    }
}