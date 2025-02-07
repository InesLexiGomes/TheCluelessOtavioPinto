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

    private Animator animator;

    private GameObject target;
    private bool isWalking = false;

    private Vector2 startPosition;


    private void Awake() {
        cutscene.SetActive(false);
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        
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
            
            animator.SetTrigger("Down");
            rb.linearVelocity = moveDir.normalized * moveSpeed;

            if (Physics2D.OverlapCircle(transform.position, talkRadius, layerMask, -10000, 10000) != null)
            {
                animator.ResetTrigger("Down");
                cutscene.SetActive(true);
                isWalking = false;
                gameObject.transform.position = startPosition;
                rb.linearVelocity = Vector2.zero;
                trigger.enabled = false;
                
            }
        }
    }
}