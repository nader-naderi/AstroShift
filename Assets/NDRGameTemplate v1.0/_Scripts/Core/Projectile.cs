using UnityEngine;

namespace NDRGameTemplate
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] new Rigidbody rigidbody;
        [SerializeField] float speed = 10;

        public void OnObjectSpawn()
        {
            rigidbody.velocity += Vector3.forward * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            gameObject.SetActive(false);
        }

    }
}
