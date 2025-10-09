using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehaviour : MonoBehaviour
{
    InputAction MoveInput;

   


    [SerializeField]
    InputActionAsset _playerController;

    public Vector2 Direction;
    public Vector2 Destination;
    Camera camera;
    GameController gamecontroller;
    BulletManager bulletManager;

    [SerializeField]
    Boundary VerticalBoundary;

    [SerializeField]
    Boundary HorizontalBoundary;

    [SerializeField]
    public float speed;



    GameObject bulletPrefab;

    [SerializeField]
    float shootingSpeed;



    void Start()
    {
        MoveInput = _playerController.FindAction("Move");
        camera = Camera.main;
        bulletManager = FindObjectOfType<BulletManager>();
        gamecontroller = FindObjectOfType<GameController>();
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");

        StartCoroutine(ShootingRoutine());
    }
    private void Update()
    {

        TouchScreenMove();
       // TraditionalMove();
        CheckBoundaries();
     
    }
    IEnumerator ShootingRoutine()
    {
        yield return new WaitForSeconds(shootingSpeed);
        // Instantiate(bulletPrefab).transform.position = transform.position;
        bulletManager.GetBullet().transform.position = transform.position;
        StartCoroutine(ShootingRoutine());
    }
  
    void TraditionalMove() // Keyboard
    {
        Direction = MoveInput.ReadValue<Vector2>();
        Debug.Log(Direction);
        transform.position = new Vector3(transform.position.x + Direction.x * speed * Time.deltaTime
                                         , transform.position.y + Direction.y * speed * Time.deltaTime
                                         , transform.position.z);


        
    }

    void TouchScreenMove() //Touchscreen
    {
  
        Destination = camera.ScreenToWorldPoint(MoveInput.ReadValue<Vector2>());
        transform.position = Vector3.Lerp(transform.position, Destination, speed * Time.deltaTime);
  

    }
    public void CheckBoundaries()
    {
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, HorizontalBoundary.min, HorizontalBoundary.max),
                                          Mathf.Clamp(transform.position.y, VerticalBoundary.min, VerticalBoundary.max),
                                          transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("You Got Hit!");
            gamecontroller.ChangeScore(-5);

            collision.GetComponent<EnemyBehaviour>().DestroyingSequence();


        }


    }

}
