using UnityEngine;

namespace NDRGameTemplate
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        private int health;


        public bool IsAlive()
        {
            return health > 0;
        }

        public void TakeDamage(int damage = 1)
        {
            health -= damage;
            if(!IsAlive())
            {
                Death();
            }
        }

        public void Death()
        {

        }
    }
}
