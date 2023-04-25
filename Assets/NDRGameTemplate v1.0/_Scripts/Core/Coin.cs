using UnityEngine;

namespace NDRGameTemplate
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                if(other.TryGetComponent(out Player player))
                    player.AddCoin();

                Destroy(gameObject);
            }
        }
    }
}
