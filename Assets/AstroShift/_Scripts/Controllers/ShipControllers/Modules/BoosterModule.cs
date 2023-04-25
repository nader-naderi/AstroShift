using UnityEngine;

namespace AstroShift
{
    public class BoosterModule : MonoBehaviour, IModule
    {
        [SerializeField] private float power = 2f;
        [SerializeField] private float boostDuration = 1.5f;
        [SerializeField] private FuelModule fuel;
        public IAutomatonable Automaton { get; set; }

        public bool IsBootedUp { get; private set; }

        public void DisableModule()
        {
            IsBootedUp = false;
        }

        public void DismantleModule()
        {

        }

        public void EnableModule()
        {
            IsBootedUp = true;
        }

        public void Perform()
        {
            if (!Automaton.IsOn || !IsBootedUp)
                return;

            if (fuel.IsFuelTankEmpty())
                return;

            if (!Automaton.IsBoosting)
                return;

            Automaton.Rigidbody.AddRelativeForce(power * Time.fixedDeltaTime * Automaton.transform.up, ForceMode2D.Impulse);
            fuel.ConsumeFuel();

            Debug.Log("!!");
        }
    }
}
