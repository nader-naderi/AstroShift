using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace AstroShift
{
    public class ShipController : MonoBehaviour, IAutomatonable
    {
        [SerializeField] private bool isPlayer = false;
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private EquipmentsController equipments;
        [SerializeField] private InventoryController inventory;
        [SerializeField] private Transform fuselage;

        public bool IsOn { get; set; } = true;
        public Rigidbody2D Rigidbody { get => rigidbody; private set => rigidbody = value; }
        public List<IModule> Modules { get; private set; } = new List<IModule>();
        public Vector2 MovementDirection { get; private set; }
        public Vector3 RotateDirection { get; private set; }
        public new Transform transform { get; private set; }

        public bool IsPlayer { get => isPlayer; set => isPlayer = value; }
        public bool IsBoosting { get; set; }
        public bool IsDoingAbility { get; set; }

        public EquipmentsController Equipments { get; private set; }

        public InventoryController Inventory { get; private set; }
        public Transform Fuselage { get => fuselage; }

        private void Awake()
        {
            transform = base.transform;

            if (Rigidbody)
                Rigidbody = GetComponent<Rigidbody2D>();

            Modules = GetComponents<IModule>().ToList();

            foreach (IModule module in Modules)
            {
                module.Automaton = this;
                if (IsOn)
                    module.EnableModule();
                else
                    module.DisableModule();
            }
        }

        private void Start()
        {
            if (isPlayer)
                GameManager.Instance.Player = this;
        }

        private void Update()
        {
            UpdateModules();
        }

        public void Move(float horizontal, float vertical)
        {
            MovementDirection = new Vector2(horizontal, vertical);
        }

        public void Rotate(float horizontal)
        {
            RotateDirection = new Vector3(0f, 0f, -horizontal);
        }

        public void UpdateModules()
        {
            foreach (IModule module in Modules)
                    module.Perform();
        }
    }

}