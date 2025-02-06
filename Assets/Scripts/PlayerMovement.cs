using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;
    private Vector2 moveDirection;
    private bool active = true;

    private void GetInputs()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        moveDirection = moveDirection.normalized;
    }

    private void Update()
    {
        GetInputs();
    }

    private void DoMovement()
    {
        if (active)
        {
            rb.linearVelocity = moveDirection * moveSpeed;
        }
    }

    private void FixedUpdate()
    {
        DoMovement();
    }

    public void StopMovement()
    {
        rb.linearVelocity = Vector2.zero;
        active = false;
    }

    public void StartMovement()
    {
        active = true;
    }
}
