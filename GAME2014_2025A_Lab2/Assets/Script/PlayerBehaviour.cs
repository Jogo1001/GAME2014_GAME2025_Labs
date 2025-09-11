using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehaviour : MonoBehaviour
{
    InputAction MoveInput;

   


    [SerializeField]
    InputActionAsset _playerController;

    public Vector2 Direction;   

    [SerializeField]
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveInput = _playerController.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Direction = MoveInput.ReadValue<Vector2>();
        Debug.Log(Direction);
        transform.position = new Vector3(transform.position.x + Direction.x * speed * Time.deltaTime,
                                          transform.position.y + Direction.y * speed * Time.deltaTime
                                         , transform.position.z);
    }
}
