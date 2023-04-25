using System.Collections.Generic;
using UnityEngine;

namespace AstroShift
{
    public class ShipController : MonoBehaviour
    {
        public float moveSpeed = 10f;
        public float rotateSpeed = 5f;
        public float boostSpeed = 20f;
        public float boostDuration = 1.5f;
        public float fuel = 100f;
        public float fuelDepletionRate = 10f;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Move(float horizontal, float vertical)
        {
            Vector2 movement = new Vector2(horizontal, vertical);
            rb.AddForce(movement * moveSpeed);
            GameControl.Instance.IsFlying = (horizontal != 0 || vertical != 0);
        }

        public void Rotate(float horizontal)
        {
            transform.Rotate(0f, 0f, -horizontal * rotateSpeed * Time.deltaTime);
        }

        public void Boost(float amount = 100)
        {
            if (fuel > 0)
            {
                rb.AddRelativeForce(transform.up * boostSpeed * amount, ForceMode2D.Impulse);
                fuel -= fuelDepletionRate * Time.deltaTime;
                fuel = Mathf.Clamp(fuel, 0f, 100);
               // UIManager.Instance.UpdateFuelBar(fuel, 100);
            }
        }
    }

}