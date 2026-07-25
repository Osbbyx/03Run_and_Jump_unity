using UnityEngine;

public class RotationItSelf : MonoBehaviour
{

    public float velocity;
 
    void Update()
    {
        transform.Rotate(Vector3.up*velocity*Time.deltaTime);
    }
}
