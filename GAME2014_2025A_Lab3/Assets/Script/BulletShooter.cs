using System.Collections;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField]
    float shootingSpeed;
    [SerializeField]
    BulletTag tag;

    BulletManager bulletManager;
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        StartCoroutine(ShootingRoutine());
    }

    IEnumerator ShootingRoutine()
    {
        yield return new WaitForSeconds(shootingSpeed);
        // Instantiate(bulletPrefab).transform.position = transform.position;
        GameObject bullet = bulletManager.GetBullet();
        bullet.transform.position = transform.position;
        bullet.tag = tag.ToString();

        switch(tag)
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
       
        StartCoroutine(ShootingRoutine());
    }

    public void StopShooting()
    {
        StopAllCoroutines();
    }
    public void StartShooting()
    {
        StartCoroutine(ShootingRoutine());
    }
}
