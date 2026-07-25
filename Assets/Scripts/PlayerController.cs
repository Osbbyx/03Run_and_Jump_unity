using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    [SerializeField] private InputActionReference _jumpInput;
    public float jumpForce;
    public float gravityMultiplier;
    private bool _isOnGround = true;
    private bool _gameOver = false; // si se esta usando aunque el ide diga que no
    public bool GameOver { get; }
    void Start()
    {

        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    private void OnEnable()
    {
        _jumpInput.action.started += Jump;
    }

    private void OnDisable()
    {
        _jumpInput.action.started -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_isOnGround)
        {
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
            _isOnGround = true;

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("GameOver!");
            //Time.timeScale = 0;
        }


       
    }
}
