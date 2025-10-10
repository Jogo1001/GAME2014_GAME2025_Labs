using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Boundary verticalboundry;

    Vector3 direction;

    BulletManager manager;
    public BulletTag bulletTag;

    void Start()
    {
        if (direction == Vector3.zero)
            direction = transform.up;
        manager = FindObjectOfType<BulletManager>();
    }


    void Update()
    {
        transform.Translate(direction* speed * Time.deltaTime, Space.World);
        if (transform.position.y > verticalboundry.max || transform.position.y < verticalboundry.min)
        {
            manager.ReturnBullet(gameObject, bulletTag);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }
    public void SetTag(BulletTag btag)
    {
        bulletTag = btag;
    }
}
