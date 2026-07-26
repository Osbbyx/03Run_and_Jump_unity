using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const string PROP_BARREL = "Prop_Barrel";
    private const string BARREL = "Barrel";
    public float velocity;
    private PlayerController _playerController;


    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if(!_playerController.GameOver)
        {
            if (gameObject.name.Contains(PROP_BARREL))
            {
                transform.Translate(Vector3.forward * velocity * Time.deltaTime);
            }
            else if(gameObject.name.Contains(BARREL))
            {
                transform.localPosition += (Vector3.left * velocity * Time.deltaTime);
            }
            else
            {

                transform.Translate(Vector3.left * velocity * Time.deltaTime);
            }
        }
        else if(GetComponent<CapsuleCollider>() != null)
        {
            GetComponent<CapsuleCollider>().material = null;
        }
        
    }
}
