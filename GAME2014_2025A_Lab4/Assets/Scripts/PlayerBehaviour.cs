using UnityEngine;
using UnityEngine.InputSystem;
using PinePie.SimpleJoystick;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    InputActionAsset inputAsset;
    InputAction moveInput;
    [SerializeField]
    JoystickController screenJoystick; 
    Rigidbody2D rb;

    [SerializeField]
    float horizontalSpeed;
    [SerializeField]
    float maxHorizontalSpeed;

    [SerializeField]
    float jumpPower;

    public bool isGrounded;

    [SerializeField]
    Transform groundPoint;
    [SerializeField]
    LayerMask groundLayerMask;

    [SerializeField]
    float groundCheckRadius;
    void Start()
    {
        moveInput = inputAsset.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundCheckRadius, groundLayerMask);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
    }
   
    void Move()
    {

        float xAxisValue = screenJoystick.InputDirection.x + moveInput.ReadValue<Vector2>().x ;

        if (xAxisValue != 0)
        {
            rb.AddForce(Vector2.right * xAxisValue * horizontalSpeed);
            rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -maxHorizontalSpeed, maxHorizontalSpeed);

            CheckLookingDirection(xAxisValue);
        }


   
    }
    void Jump()
    {
        float yAxisValue = screenJoystick.InputDirection.y + moveInput.ReadValue<Vector2>().y;

        if (isGrounded && yAxisValue > .7f)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    void CheckLookingDirection(float xValue)
    {
        if (xValue > 0)
        {
            transform.localScale = Vector3.one;

        }
        else if (xValue < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, groundCheckRadius);
    }
}
