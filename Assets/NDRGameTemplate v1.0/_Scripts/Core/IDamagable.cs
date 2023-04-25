namespace NDRGameTemplate
{
    public interface IDamagable
    {
        void TakeDamage(int damage = 1);
        bool IsAlive();
        void Death();
    }
}
