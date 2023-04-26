using UnityEngine;

namespace AstroShift
{
    public class Ability : ScriptableObject
    {
        public new string name;
        public float cooldownTime;
        public float activeTime;
        public int manaCost = 25;
        protected IAutomatonable controller;

        public virtual void Activate(IAutomatonable controller) { }
        public virtual void BeginCooldown(IAutomatonable controller)
        { 
            controller.IsDoingAbility = false;
        }

        public virtual void CooledDown(IAutomatonable controller) { }
        public virtual void Update() 
        {
            if (controller == null)
            {
                Debug.LogError("No Controller Assigend!");
                return;
            }
        }


    }
}