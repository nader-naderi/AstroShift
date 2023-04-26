using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AstroShift
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField] int baseValue;

        private List<int> modifiers = new List<int>();

        public int Value {
            get
            {
                int finalValue = baseValue;
                modifiers.ForEach(x => finalValue += x);
                return finalValue;
            }
        }

        /// <summary>
        /// Percent of the Final Value.
        /// </summary>
        public float ValueF
        {
            get => (Value) * 0.01f;
        }

        public int AddModifier (int modifier)
        {
            if (modifier != 0)
                modifiers.Add(modifier);

            return modifier;
        }

        public void RemoveModifier(int modifier)
        {
            if (modifier != 0)
                modifiers.Remove(modifier);
        }
    }
}