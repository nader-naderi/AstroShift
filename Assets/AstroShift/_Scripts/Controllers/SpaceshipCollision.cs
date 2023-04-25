using UnityEngine;
namespace AstroShift
{
    public class SpaceshipCollision : MonoBehaviour, ICollidable
    {
        public float maxHealth = 100f;

        private float currentHealth;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            float speed = collision.relativeVelocity.magnitude;
            float damage = speed / 2f;

            if (damage > 0f)
            {
                ICollidable collidable = collision.gameObject.GetComponent<ICollidable>();

                if (collidable != null)
                {
                    collidable.TakeDamage(damage);
                }
            }
        }
    }
}