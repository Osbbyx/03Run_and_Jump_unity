using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    //CONST
    private const string SPEED_F = "Speed_f";
    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string GROUND_TAG = "Ground";
    private const string DEATHTYPE_INT = "DeathType_int";
    //VAR
    public float jumpForce;
    public float gravityMultiplier;
    private bool _isOnGround = true;
    private bool _gameOver = false; // si se esta usando aunque el ide diga que no
    //Get and Set
    public bool GameOver { get => _gameOver; }
    //Components Privados
    private Rigidbody _playerRb;
    [SerializeField] private InputActionReference _jumpInput;
    private Animator _animator;
    //Componentes Publicos
    public ParticleSystem explosion;


    void Start()
    {
        
        _animator = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMultiplier;
    }

    private void Update()
    {
        if(Time.time < 1)
        _animator.SetFloat(SPEED_F, 1+ Time.time/10);
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
            _animator.SetTrigger(JUMP_TRIG);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == GROUND_TAG && !_gameOver)
            _isOnGround = true;

        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            _isOnGround = false;
            explosion.Play();
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATHTYPE_INT, Random.Range(1,3));
            Debug.Log("GameOver!" + GameOver);
            //Time.timeScale = 0;
        }


       
    }
}
