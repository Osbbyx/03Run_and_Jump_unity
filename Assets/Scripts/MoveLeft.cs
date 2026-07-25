using UnityEngine;

public class MoveLeft : MonoBehaviour
{
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
            if (gameObject.name.Contains("Prop_Barrel"))
            {
                transform.Translate(Vector3.forward * velocity * Time.deltaTime);
            }
            else
            {

                transform.Translate(Vector3.left * velocity * Time.deltaTime);
            }
        }
        
    }
}
