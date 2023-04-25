using UnityEngine;

namespace AstroShift
{
    public class Pickupable : MonoBehaviour
    {
        public virtual void OnPickup()
        {
            Debug.Log("Picked Up");
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