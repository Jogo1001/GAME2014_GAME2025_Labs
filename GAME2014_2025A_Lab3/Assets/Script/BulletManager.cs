using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    int bulletTotal = 50;

    GameObject bulletPrefab;
    Queue<GameObject> bulletPool = new Queue<GameObject>();
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");

        for(int i = 0; i< bulletTotal; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullet.transform.parent = transform;
            bulletPool.Enqueue(bullet); 
        }    
    }
   public GameObject GetBullet()
    {
        GameObject bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;

    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
