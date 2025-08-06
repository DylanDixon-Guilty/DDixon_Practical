using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 6f;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 movement;
    [SerializeField] private const string moveHorizontal = "Horizontal";
    [SerializeField] private const string moveVertical = "Vertical";
    [SerializeField] private const string cameraRotateAxis = "Mouse X";

    
    void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        float rotateInput = Input.GetAxis(cameraRotateAxis);
        transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw(moveHorizontal);
        float vertical = Input.GetAxisRaw(moveVertical);
        movement.Set(horizontal, 0f, vertical);
        movement = movement.normalized * Speed * Time.deltaTime;
        transform.Translate(movement * Speed * Time.deltaTime);
    }
}
