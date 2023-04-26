using UnityEngine;

namespace AstroShift
{
    public enum EConsumptionType { HEALTH, MANA, XP }
    [CreateAssetMenu(fileName = "Consumption", menuName = "SOE/Inventory/Consumption", order = 0)]
    public class Consumption : Item
    {
        /// <summary>
        /// What is the type of the Consumption Item.
        /// </summary>
        public EConsumptionType consumptionType;

        /// <summary>
        /// Amount of Gain.
        /// </summary>
        public float consumeGain = 15f;
        
        /// <summary>
        /// should be destroy on Use?
        /// </summary>
        public bool destroyOnUse = true;

        /// <summary>
        /// Prefab of the Current consumption item for spawning in the world.
        /// </summary>
        public GameObject consumptionSpawnObject;
    }
}
