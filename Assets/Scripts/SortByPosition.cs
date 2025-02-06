using UnityEngine;

public class SortByPosition : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = ChangeZAccordingToY();
    }

    private Vector3 ChangeZAccordingToY()
    {
        Vector3 pos = transform.position;
        pos.z = transform.position.y / 100;
        return pos;
    }
}
