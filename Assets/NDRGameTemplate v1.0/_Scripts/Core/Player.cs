using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NDRGameTemplate
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [SerializeField] Weapon weapon;

        private int coinAmount;

        CharacterController controller;

        float speed = 3;

        Vector3 moveDirection;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            HandleMovement();

            if(Input.GetKeyDown(KeyCode.Space))
            {
                weapon.Fire();
            }
        }

        private void HandleMovement()
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (moveDirection.magnitude != 0)
                controller.SimpleMove(moveDirection.normalized * speed);
        }

        public void AddCoin(int amount = 1)
        {
            coinAmount = amount;
            LevelManager.instance.UpdateCoinUI(coinAmount);
            // Play Audio.
        }
    }
    [System.Serializable]
    public class Weapon
    {
        public string name;
        public AudioClip fireClip;
        [SerializeField] Transform weaponMuzzle;

        public void Fire()
        {
            ObjectPooler.instance.SpawnFromPool("Projectile", weaponMuzzle.position, weaponMuzzle.rotation);
        }
    }
}