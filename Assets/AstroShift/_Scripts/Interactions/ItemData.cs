using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace AstroShift
{
    [CreateAssetMenu(fileName = "New Item", menuName = "InteractionsData/New Item")]
    public class ItemData : ScriptableObject
    {
        public string name;
        public string description;
        public Sprite portrait;
    }

    public enum EPickupItemType { Coin, FuelTank, RepairKit, }
    [CreateAssetMenu(fileName = "New Pickupable", menuName = "InteractionsData/PickupableItems/New Pickupable")]
    public class PickupData : ItemData
    {
        [SerializeField] private EPickupItemType pickupType;
        public virtual void Use(IAutomatonable automatonable)
        {
            switch (pickupType)
            {
                case EPickupItemType.Coin:
                    
                    break;
                case EPickupItemType.FuelTank:
                    
                    break;
                case EPickupItemType.RepairKit:
                    
                    break;
                default:
                    break;
            }
        }
    }

}