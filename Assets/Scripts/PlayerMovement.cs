using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;
    private Vector2 moveDirection;

    private void GetInputs()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");

        moveDirection = moveDirection.normalized;
    }

    private void Update()
    {
        GetInputs();
    }

    private void DoMovement()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
    }

    private void FixedUpdate()
    {
        DoMovement();
    }
}
