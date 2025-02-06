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
        pos.z = transform.position.y;
        transform.position = pos;
        /*Vector3 pos;
        if (rb != null)
        {
            pos = rb.position;
            pos.z = rb.position.y;
            rb.position = pos;

            Debug.Log($"Set rb.position = {pos}");
        }
        else
        {
           
        }*/
    }
}
