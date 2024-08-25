using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Deactivate), lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void Deactivate()
    {
        BulletPool.Instance.ReleaseBullet(gameObject);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
