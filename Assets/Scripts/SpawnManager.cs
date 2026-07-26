using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private float nextSpawnTime = 1;
    private Vector3 spawnPosition;
    private PlayerController _playerController;
    private Vector3 offset;


    private void Start()
    {
        offset = new Vector3(0,0,0.79f);
        Invoke("InvocacionDeObjetos", nextSpawnTime);
        spawnPosition = transform.position;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void InvocacionDeObjetos()
    {
        if (!_playerController.GameOver)
        {
            nextSpawnTime = Random.Range(1.05f, 2.5f);
            int indexRandom = Random.Range(0, obstacles.Length);

            Instantiate(
                obstacles[indexRandom],
                indexRandom == 1? spawnPosition + -offset : spawnPosition,
                obstacles[indexRandom].transform.rotation
                );

            Invoke(nameof(InvocacionDeObjetos), nextSpawnTime);
        }
    }

}
