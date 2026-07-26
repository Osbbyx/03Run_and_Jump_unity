using UnityEngine;

public class Spin : MonoBehaviour
{

    [SerializeField]private float rotationVelocity = 80;
    private PlayerController _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationVelocity);
    }
}
