using UnityEngine;

public class NpcBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool talkOnSight;
    [SerializeField] private Vector2 moveDir;
    [SerializeField] private int moveSpeed;
    [SerializeField] private float talkRadius;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private BoxCollider2D trigger;

    private GameObject target;
    private bool isWalking = false;

    private Vector2 startPosition;

    private void Start()
    {
        cutscene.SetActive(false);
        startPosition = rb.position;
        if (!talkOnSight) trigger.enabled = false;
        else trigger.enabled = true;
    }

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

            if (Physics2D.OverlapCircle(transform.position, talkRadius, layerMask, -1, 1) != null)
            {
                cutscene.SetActive(true);
                isWalking = false;
                rb.position = startPosition;
                trigger.enabled = false;
            }
        }
    }
}