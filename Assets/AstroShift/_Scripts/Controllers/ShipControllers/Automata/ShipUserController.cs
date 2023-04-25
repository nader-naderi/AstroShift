using UnityEngine;

namespace AstroShift
{
    public class ShipUserController : MonoBehaviour
    {
        ShipController controller;
        
        private void Awake()
        {
            controller = GetComponent<ShipController>();
            controller.IsPlayer = true;
        }
        
        private void Update()
        {
            controller.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            controller.Rotate(Input.GetAxis("Horizontal"));

            controller.IsBoosting = Input.GetKey(KeyCode.Space);
        }
    }
}