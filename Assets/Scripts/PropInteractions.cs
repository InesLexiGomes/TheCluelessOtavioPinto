using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PropInteractions : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private string lowLayer;
    [SerializeField] private string highLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            playerSprite.sortingLayerID = SortingLayer.NameToID(lowLayer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            playerSprite.sortingLayerID = SortingLayer.NameToID(highLayer);
        }
    }
}
