using UnityEngine;

namespace AstroShift
{
    public class EngineModule : MonoBehaviour, IModule
    {
        [SerializeField] private float moveSpeed = 100f;
        [SerializeField] private float rotateSpeed = 25f;

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
            if (!IsBootedUp || !Automaton.IsOn)
                return;

            HandleMovementLogic();
            HandleRotationLogic();
        }

        private void HandleRotationLogic()
        {
            if (Automaton.RotateDirection == Vector3.zero)
                return;

            Rotate(Automaton.RotateDirection);
        }

        private void HandleMovementLogic()
        {
            if (Automaton.MovementDirection == Vector2.zero)
                return;

            Move(Automaton.MovementDirection);
        }

        public void Move(Vector2 direction)
        {
            Debug.Log(100 * moveSpeed * Time.deltaTime * direction);
            Automaton.Rigidbody.AddForce(100 * moveSpeed * Time.deltaTime * direction);
        }

        public void Rotate(Vector3 direction)
        {
            Debug.Log(100 * rotateSpeed * Time.deltaTime * direction);
            Automaton.transform.Rotate(100 * rotateSpeed * Time.deltaTime * direction);
        }
    }
}
