using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    private const string MOVE_HANDS = "moveHand";
    private const string MOVE_X = "movex";
    private const string MOVE_Y = "movey";
    private const string MOVING = "moving";
    private bool isMoving = false;
    private bool isMovingHand = false;
    private float movex = 0, movey = 0;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(MOVE_HANDS,isMovingHand);
        _animator.SetBool(MOVING, isMoving);
        _animator.SetFloat(MOVE_X, movex);
        _animator.SetFloat(MOVE_Y, movey);
    }

    void Update()
    {
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");

        if(movex != 0 || movey != 0)
        {
            Debug.Log("dentro");
            isMoving = true;
            _animator.SetBool(MOVING, isMoving);
        }
        else if(movex == 0 || movey == 0)
        {
            isMoving = false;
        }

        _animator.SetFloat(MOVE_X, movex);
        _animator.SetFloat(MOVE_Y, movey);
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log(isMovingHand);
            isMovingHand = !isMovingHand;
            _animator.SetBool(MOVE_HANDS, isMovingHand);
         
        }
    }
}
