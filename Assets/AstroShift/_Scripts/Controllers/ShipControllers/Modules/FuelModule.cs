using UnityEngine;

namespace AstroShift
{
    public class FuelModule : MonoBehaviour, IModule
    {
        [SerializeField] private int initialFuel = 100;
        [SerializeField] private float currentFuel = 100f;
        [SerializeField] private int fuelDrainRate = 1;
        [SerializeField] private int maximumFuel = 200;

        public IAutomatonable Automaton { get; set; }

        public bool IsBootedUp { get; private set; }

        public bool IsFuelTankEmpty() => currentFuel <= 0;

        public float ConsumeFuel()
        {
            currentFuel -= fuelDrainRate * Time.deltaTime;
            currentFuel = Mathf.Clamp(currentFuel, 0f, maximumFuel);

            if (Automaton.IsPlayer)
            {
                UIManager.Instance.UpdateFuelBar(currentFuel);
                UIManager.Instance.NoFuelAlert.SetActive(IsFuelTankEmpty());
            }

            return currentFuel;
        }

        public void EnableModule()
        {
            IsBootedUp = true;
        }

        public void DisableModule()
        {
            IsBootedUp = false;
        }

        public void DismantleModule()
        {

        }

        public void Perform()
        {
            if (!Automaton.IsOn)
                return;
            
            if (Automaton.MovementDirection == Vector2.zero)
                return;

            Automaton.IsOn = ConsumeFuel() > 0;
        }
    }
}
