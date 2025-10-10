using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    GameObject bulletPrefab;
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
    }



    public GameObject CreateBullet(BulletTag tag)
    {
        GameObject bullet = Instantiate(bulletPrefab);

     
        bullet.tag = tag.ToString();

        switch (tag)
        {
            case BulletTag.PlayerBullet:
                bullet.GetComponent<BulletBehaviour>().SetDirection(Vector3.up);
                bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
                bullet.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case BulletTag.EnemyBullet:
                bullet.GetComponent<BulletBehaviour>().SetDirection(Vector3.down);
                bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
                bullet.GetComponent<SpriteRenderer>().color = Color.green;
                break;

        }
        return bullet;
    }
}
