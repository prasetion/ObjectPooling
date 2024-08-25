using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 0.5f;
    private float nextFireTime;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject bullet = BulletPool.Instance.GetBullet();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
    }
}