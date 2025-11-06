using UnityEngine;

public class DeadPlane : MonoBehaviour
{

    Vector3 spawnpoint = new Vector3(3, 3, 0);
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.CompareTag("Player"))
         {
            collision.transform.position = spawnpoint;
         }
    }

    public void UpdateSpawnPoint(Vector3 checkpoint)
    {
        spawnpoint = checkpoint;    
    }
}
