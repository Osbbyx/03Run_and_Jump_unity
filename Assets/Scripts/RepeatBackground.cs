using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float bCollider;

    void Start()
    {
        startPosition = transform.position;
        bCollider = GetComponent<BoxCollider>().size.x / 2;
    }
  
    void Update()
    { 
        if(startPosition.x - transform.position.x > bCollider)
        {
            transform.position = startPosition;
        } 
    }
}
