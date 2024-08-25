using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    public GameObject bulletPrefab;
    public int defaultCapacity = 10;
    public int maxSize = 20;

    private ObjectPool<GameObject> pool;

    private void Awake()
    {
        Instance = this;
        pool = new ObjectPool<GameObject>(
            CreateBullet,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyPoolObject,
            true,
            defaultCapacity,
            maxSize
        );
    }

    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        return bullet;
    }

    private void OnTakeFromPool(GameObject bullet)
    {
        bullet.SetActive(true);
    }

    private void OnReturnedToPool(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject bullet)
    {
        Destroy(bullet);
    }

    public GameObject GetBullet()
    {
        return pool.Get();
    }

    public void ReleaseBullet(GameObject bullet)
    {
        pool.Release(bullet);
    }
}
