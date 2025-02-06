using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private int bounceFactor;
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
        MovementVisuals();
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

    private void MovementVisuals()
    {
        Vector2 spriteBounce = Vector2.zero;
        if (moveDirection.x != 0)
        {
            spriteBounce.x = Mathf.Sin(Time.time)*bounceFactor;
        }
        if (moveDirection.y != 0)
        {
            spriteBounce.y = Mathf.Sin(Time.time) * bounceFactor;
        }
        if (moveDirection.x == 0 && moveDirection.y == 0)
        {
            spriteBounce = Vector2.zero;
        }
        playerSprite.gameObject.transform.localPosition = spriteBounce;
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
