using UnityEngine;

public class SortByPosition : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ChangeZAccordingToY();
    }

    private void ChangeZAccordingToY()
    {
        Vector3 pos = transform.position;
        pos.z = transform.position.y/100 + 100;
        transform.position = pos;
    }
}
