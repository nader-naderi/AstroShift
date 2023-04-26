using UnityEngine;
using System.Collections;

namespace AstroShift
{
    public class EquipmentsController : MonoBehaviour
    {
        [SerializeField] Transform weaponHolderBone;
        GameObject equipedWeapon;

        public delegate void OnEquipmentChanged(Equipment newItem, Equipment OldItem);
        public OnEquipmentChanged onEquipmentChanged;

        public Equipment[] CurrentEquipments { get; private set; }

        public void Start()
        {
            int numSlot = System.Enum.GetNames(typeof(EEquipemntTypes)).Length;
            CurrentEquipments = new Equipment[numSlot];
        }

        public void Equip(Equipment newItem, InventoryController inventory)
        {
            // find the slot position of the equipment.
            int slotIndex = (int)newItem.equipemntType;

            Equipment oldItem = null;

            CurrentEquipments ??= new Equipment[System.Enum.GetNames(typeof(EEquipemntTypes)).Length];

            // we had something.
            if (CurrentEquipments[slotIndex])
            {
                oldItem = CurrentEquipments[slotIndex];

                // Place it back to the inventory.
                inventory.AddItem(oldItem);
            }

            onEquipmentChanged?.Invoke(newItem, oldItem);

            // init the equipment.
            CurrentEquipments[slotIndex] = newItem;
            // is this equipemnt should be show on the Agent's body?
            if (newItem.visualizeit)
            {
                if (!weaponHolderBone) return;

                // TODO: Check if it's Weapon.
                // Create the weapon object and put in the corrent bone.
                equipedWeapon = Instantiate(newItem.model, weaponHolderBone.position, weaponHolderBone.rotation, weaponHolderBone);
                //DamageVolume damageVolume = equipedWeapon.GetComponentInChildren<DamageVolume>();
                //character.DamageVolume = damageVolume;
            }
        }

        public void Unequip(int slotIndex)
        {
            if (CurrentEquipments[slotIndex] == null) return;

            Equipment oldItem = CurrentEquipments[slotIndex];

            onEquipmentChanged?.Invoke(null, oldItem);

            CurrentEquipments[slotIndex] = null;

            if (equipedWeapon)
            {
                Destroy(equipedWeapon);
            }
        }

        public void UnequipAll()
        {
            for (int i = 0; i < CurrentEquipments.Length; i++)
                Unequip(i);
        }

    }
}