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


    [SerializeField]
    Boundary VerticalBoundary;

    [SerializeField]
    Boundary HorizontalBoundary;

    [SerializeField]
    public float speed;

    GameController gamecontroller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveInput = _playerController.FindAction("Move");
        camera = Camera.main;

        gamecontroller = FindObjectOfType<GameController>();
    }
    private void Update()
    {

        TouchScreenMove();
        //TraditionalMove();
        CheckBoundaries();
    }

    // Update is called once per frame
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
    /*    old input system
        foreach(Touch touch in Input.touches)
        {
            Destination = camera.ScreenToWorldPoint(touch.position);
        }*/
        Destination = camera.ScreenToWorldPoint(MoveInput.ReadValue<Vector2>());
        transform.position = Vector3.Lerp(transform.position, Destination, speed * Time.deltaTime);
        //transform.position = Destination;

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


            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.enabled = false;
           // collision.gameObject.SetActive(false);
        }


    }

}
