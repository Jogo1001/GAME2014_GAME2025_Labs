using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField]
    Boundary speedRange;
    float speed;

    [SerializeField]
    Boundary screenHorizontalBoundary;

    [SerializeField]
    Boundary screenVerticalBoundary;


    bool IsDying = false;
  
    void Start()
    {
        speed = Random.Range(speedRange.min, speedRange.max);
        Reset();
        
    }

   
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        float xPos = Mathf.PingPong(Time.time * speed, screenHorizontalBoundary.max - screenHorizontalBoundary.min) + screenHorizontalBoundary.min;
        transform.position = new Vector3 (xPos, transform.position.y - speed  * Time.deltaTime);

        if(screenVerticalBoundary.min > transform.position.y)
        {

          Reset();

        }

  


    }

    private void FixedUpdate()
    {
        if (IsDying)
        {
            transform.Rotate(0, 0, 5);
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x - 0.05f, 0, 1),
                                                Mathf.Clamp(transform.localScale.y - 0.05f, 0, 1), 1);
        }
    }
    public void DestroyingSequence()
    {


      //  GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.red;
        IsDying = true;
        // collision.gameObject.SetActive(false);
    }
    private void Reset()
    {
        transform.position = new Vector3(Random.Range(screenHorizontalBoundary.min, screenHorizontalBoundary.max),
                                                        screenVerticalBoundary.max, transform.position.z);
        speed = Random.Range(speedRange.min, speedRange.max);

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        IsDying = false;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
 
}
