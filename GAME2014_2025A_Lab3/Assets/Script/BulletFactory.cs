using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField]
    GameObject playerBulletPrefab;
    [SerializeField]
    GameObject enemyBulletPrefab;
/*    void Start()
    {
        playerBulletPrefab = Resources.Load<GameObject>("Prefabs/PlayerBullet");
        enemyBulletPrefab = Resources.Load<GameObject>("Prefabs/EnemyBullet");
    }*/



    public GameObject CreateBullet(BulletTag tag)
    {
        GameObject bullet;

     
    

        switch (tag)
        {
            case BulletTag.PlayerBullet:
                bullet = Instantiate(playerBulletPrefab);
                bullet.GetComponent<BulletBehaviour>().SetDirection(Vector3.up);
                // bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
                //  bullet.GetComponent<SpriteRenderer>().color = Color.white;
                bullet.tag = tag.ToString();
                return bullet;
            case BulletTag.EnemyBullet:
                bullet = Instantiate(enemyBulletPrefab);
                bullet.GetComponent<BulletBehaviour>().SetDirection(Vector3.down);
                //  bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
                // bullet.GetComponent<SpriteRenderer>().color = Color.green;
                bullet.tag = tag.ToString();
                return bullet;

        }
   return null;
    }
}
