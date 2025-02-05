using UnityEngine;

public class PropInteraction : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (player.transform.position.y < transform.position.x)
        {
            //Sort Layer Lower
        }
        else
        {
            //Sort Layer Higher
        }
    }
}
