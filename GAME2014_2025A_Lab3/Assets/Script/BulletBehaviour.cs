using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Boundary verticalboundry;

    Vector3 direction;

    void Start()
    {
        direction = transform.up;
    }


    void Update()
    {
        transform.Translate(direction* speed * Time.deltaTime);
        if(transform.position.y > verticalboundry.max)
        {
            Destroy(gameObject);
        }
    }
}
