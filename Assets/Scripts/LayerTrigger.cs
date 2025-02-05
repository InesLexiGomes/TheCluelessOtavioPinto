using UnityEngine;

public class LayerTrigger : MonoBehaviour
{
    [SerializeField] private string layer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            SpriteRenderer[] sprites = collision.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in sprites)
            {
                sprite.sortingLayerID = SortingLayer.NameToID(layer);
            }
        }
    }
}
