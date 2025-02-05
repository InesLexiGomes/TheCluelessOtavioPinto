using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool talkOnSight;
    [SerializeField] private Vector2 moveDir;
    [SerializeField] private int moveSpeed;

    private GameObject target;
    private bool isWalking = false;

    private void FixedUpdate()
    {
        WalkTowards();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement movement = collision.GetComponent<PlayerMovement>();
        if (talkOnSight && movement != null)
        {
            isWalking = true;
            target = collision.gameObject;
            movement.StopMovement();
        }
    }

    private void WalkTowards()
    {
        if (isWalking && target != null)
        {
            rb.linearVelocity = moveDir.normalized * moveSpeed;
            //if ()
        }
    }
}