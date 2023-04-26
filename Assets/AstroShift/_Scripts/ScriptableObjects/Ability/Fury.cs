using UnityEngine;

namespace AstroShift
{
    [CreateAssetMenu(fileName = "Fury", menuName = "SOE/Characters/Abilities/Fury", order = 0)]
    public class Fury : Ability
    {
        public float rotateSpeed = 150;

        public override void Activate(IAutomatonable controller)
        {
            this.controller = controller;
        }

        public override void Update()
        {
            base.Update();
            controller.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        public override void BeginCooldown(IAutomatonable controller)
        {
            base.BeginCooldown(controller); 
        }
    }
}
