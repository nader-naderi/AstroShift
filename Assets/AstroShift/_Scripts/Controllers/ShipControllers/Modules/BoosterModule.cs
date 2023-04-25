using UnityEngine;

namespace AstroShift
{
    public class BoosterModule : MonoBehaviour, IModule
    {
        [SerializeField] private float power = 2f;
        [SerializeField] private float boostDuration = 1.5f;

        public IAutomatonable Automaton { get; set; }

        public bool IsBootedUp { get; private set; }
        
        public void DisableModule()
        {

        }

        public void DismantleModule()
        {

        }

        public void EnableModule()
        {

        }

        public void Perform()
        {
            if (!Automaton.IsOn || !IsBootedUp)
                return;

            Automaton.Rigidbody.AddRelativeForce(power * Automaton.transform.up * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
}
