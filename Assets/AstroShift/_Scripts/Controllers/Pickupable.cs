using UnityEngine;

namespace AstroShift
{
    public class Pickupable : MonoBehaviour
    {
        public virtual void OnPickup()
        {
            Destroy(gameObject);
        }        

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.GetComponent<Collider2D>().CompareTag("Player"))
            {
                OnPickup();
            }
        }
    }
}