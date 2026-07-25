using UnityEngine;

public class DestroyIt : MonoBehaviour
{
    private float limitX = -3f;
 
    void Update()
    {
        if(transform.position.x <= limitX)
        {
            Destroy(gameObject);
        }
    }
}
