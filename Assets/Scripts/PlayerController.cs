using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    //CONST
    private const string SPEED_F = "Speed_f";
    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string GROUND_TAG = "Ground";
    private const string DEATHTYPE_INT = "DeathType_int";
    private const string PROTOTYPE_3 = "Prototype 3";

    //VAR
    public float jumpForce, gravityMultiplier;
    private bool _isOnGround = true;
    private bool _gameOver = false; // si se esta usando aunque el ide diga que no
    //Get and Set
    public bool GameOver { get => _gameOver; }

    //Components Privados
    private Rigidbody _playerRb;
    [SerializeField] private InputActionReference _jumpInput;
    private Animator _animator;
    private AudioSource _audioSource;
    private float _speedMultiplayer = 1;

    //Componentes Publicos
    public ParticleSystem explosion, dirtyAnim;
    public AudioClip jumpSound, crashSound;
    [Range(0,1)] public float audioVolume = 1;
    

    void Start()
    {
        //declaraciones de componentes
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
        //manejo de la gravedad en physics
        Physics.gravity = gravityMultiplier * new Vector3(0,-9.81f, 0);
    }

    private void Update()
    {
        _speedMultiplayer += Time.deltaTime / 10;
        if (_speedMultiplayer < 1.40f)
            _animator.SetFloat(SPEED_F, _speedMultiplayer);
    }

    private void OnEnable()
    {
        //suscribo al presionar space
        _jumpInput.action.started += Jump;
    }

    private void OnDisable()
    {
        //al terminar la accion desuscribo la key space
        _jumpInput.action.started -= Jump;
    }

    //si la tecla Space fue precionada
    private void Jump(InputAction.CallbackContext context)
    {
        if (_isOnGround)
        {
            //manejo de booleanos
            _isOnGround = false;
            //manejo de animacion
            dirtyAnim.Stop();
            //manejor de componentes
            _audioSource.PlayOneShot(jumpSound, audioVolume);
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _animator.SetTrigger(JUMP_TRIG);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == GROUND_TAG && !_gameOver)
        {
            //manejo bool
            _isOnGround = true;
            //manejo de animacion
            dirtyAnim.Play();
        }
           

        else if (collision.gameObject.CompareTag("Obstacle") && !_gameOver)
        {
            //manejo de booleanas
            _gameOver = true;
            _isOnGround = false;
            //manejo de animacion y sonido
            explosion.Play();
            dirtyAnim.Stop();
            //manejo de componentes audo
            _audioSource.PlayOneShot(crashSound, audioVolume);
            //manijo de animaciones
            _animator.SetBool(DEATH_B, true);
            _animator.SetInteger(DEATHTYPE_INT, Random.Range(1,3));
            //Time.timeScale = 0;
            //Carga scena de nuevo
            Invoke(nameof(ResetScene),2);
        }
       
    }


    private void ResetScene()
    {

        _speedMultiplayer = 0;
        SceneManager.LoadScene(PROTOTYPE_3);
    }
}
