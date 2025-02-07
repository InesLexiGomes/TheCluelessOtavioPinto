using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
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

    private void FixedUpdate()
    {
        DoMovement();
        MovementVisuals();
        FootStepNoise();
    }

    private void DoMovement()
    {
        if (active)
        {
            rb.linearVelocity = moveDirection * moveSpeed;
        }
    }

    private void MovementVisuals()
    {
        ResetTriggers();
        if (moveDirection == Vector2.zero) animator.SetTrigger("Idle");
        else if (moveDirection.y > 0) animator.SetTrigger("Up");
        else if (moveDirection.y < 0) animator.SetTrigger("Down");
        else if (moveDirection.x > 0) animator.SetTrigger("Right");
        else if (moveDirection.x < 0) animator.SetTrigger("Left");
    }

    private void ResetTriggers()
    {
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("Up");
        animator.ResetTrigger("Down");
        animator.ResetTrigger("Left");
        animator.ResetTrigger("Right");
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

    private void FootStepNoise()
    {
        if (!audioSource.isPlaying && moveDirection != Vector2.zero)
        {
            audioSource.Play();
        }
        else if (moveDirection == Vector2.zero)
        {
            audioSource.Stop();
        }
    }
}
