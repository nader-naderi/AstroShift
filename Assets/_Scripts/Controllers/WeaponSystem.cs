using UnityEngine;
namespace AstroShift
{
    public class WeaponSystem : MonoBehaviour, IWeaponSystem
    {
        public GameObject bulletPrefab;
        public Transform bulletSpawnPoint;
        public float bulletSpeed = 20f;

        public void Fire()
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}