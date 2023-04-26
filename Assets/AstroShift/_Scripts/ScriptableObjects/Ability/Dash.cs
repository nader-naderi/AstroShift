using UnityEngine;

namespace AstroShift
{
    [CreateAssetMenu(fileName = "Dash", menuName = "SOE/Characters/Abilities/Dash", order = 0)]
    public class Dash : Ability
    {
        public float dashVelocity;
        IAutomatonable controller;
        public override void Activate(IAutomatonable controller)
        {
            this.controller = controller;
            // TODO: Play SFX.
            // TODO: Play VFX.
        }

        public override void Update()
        {
            base.Update();
            controller.Rigidbody.AddRelativeForce(Vector3.forward * dashVelocity * Time.deltaTime,
                ForceMode2D.Impulse);

            //controller.Velocity = controller.transform.position.normalized * dashVelocity * 100 * Time.deltaTime;
            //controller.transform.forward *= dashVelocity * Time.deltaTime;
            //controller.transform.Translate(controller.transform.forward * dashVelocity * Time.deltaTime);
        }

        public override void BeginCooldown(IAutomatonable controller)
        {
            controller.Rigidbody.velocity = controller.transform.position;
        }
    }
}
