using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private float nextSpawnTime = 1;
    private Vector3 spawnPosition;
    private PlayerController _playerController;


    private void Start()
    {
        Invoke("InvocacionDeObjetos", nextSpawnTime);
        spawnPosition = transform.position;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void InvocacionDeObjetos()
    {
        if (!_playerController.GameOver)
        {
            nextSpawnTime = Random.Range(1.1f, 2.5f);
            int indexRandom = Random.Range(0, obstacles.Length);

            Instantiate(
                obstacles[indexRandom],
                spawnPosition,
                obstacles[indexRandom].transform.rotation
                );

            Invoke(nameof(InvocacionDeObjetos), nextSpawnTime);
        }
    }

}
