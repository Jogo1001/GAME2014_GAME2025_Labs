using Unity.VisualScripting;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<DeadPlane>().UpdateSpawnPoint(transform.position);

        }
    }
}
