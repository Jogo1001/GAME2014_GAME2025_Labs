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
      
        GameObject bullet = bulletManager.GetBullet(tag);
        bullet.transform.position = transform.position;

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
