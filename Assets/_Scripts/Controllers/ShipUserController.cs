using UnityEngine;

namespace AstroShift
{
    public class ShipUserController : MonoBehaviour
    {
        ShipController controller;
        
        private void Awake()
        {
            controller = GetComponent<ShipController>();   
        }
        
        private void Update()
        {
            controller.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            controller.Rotate(Input.GetAxis("Horizontal"));
            
            if(Input.GetKey(KeyCode.Space))
                controller.Boost();
        }
    }
}