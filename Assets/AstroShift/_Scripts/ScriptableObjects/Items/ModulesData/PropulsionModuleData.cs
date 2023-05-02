using UnityEngine;

namespace AstroShift
{
    [CreateAssetMenu(fileName = "New Propulsion Module", menuName = "Astroshift/Modules/New Propulsion Module")]
    public class PropulsionModuleData : ModuleData
    {
        public float propulsionModifier = 1;
        public float allocatedFuel = 50;
    }
}