using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace AstroShift
{
    [CreateAssetMenu(fileName = "New Module", menuName = "Astroshift/Modules/New Module")]
    public class ModuleData : Item
    {
        public float mass = 1;

        public virtual void Attach()
        {

        }

        public virtual void Detach()
        {

        }
    }
}