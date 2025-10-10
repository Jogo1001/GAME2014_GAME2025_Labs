using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    GameObject bulletPrefab;
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }



    public GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        return bullet;
    }
}
