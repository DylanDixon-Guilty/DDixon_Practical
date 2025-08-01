using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 6f;

    private Vector3 movement;
    private Rigidbody playerRb;
    private string moveHorizontal = "Horizontal";
    private string moveVertical = "Vertical";

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw(moveHorizontal);
        float vertical = Input.GetAxisRaw(moveVertical);
        Move(horizontal, vertical);
    }

    private void Move(float horizontal, float vertical)
    {
        movement.Set(horizontal, 0f, vertical);
        movement = movement.normalized * Speed * Time.deltaTime;
        playerRb.MovePosition(transform.position + movement);
    }
}
