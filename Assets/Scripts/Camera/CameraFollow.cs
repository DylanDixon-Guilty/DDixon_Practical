using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerPosition;
    public float smoothing = 5f;

    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - PlayerPosition.position;
    }

    
    void FixedUpdate()
    {
        Vector3 playerCamPosition = PlayerPosition.position + offset;
        transform.position = Vector3.Lerp(transform.position, playerCamPosition, smoothing * Time.deltaTime);
    }

    
}
