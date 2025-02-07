using Unity.VisualScripting;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField] private GameObject cutscene;
    private GameManager gameManager;

    private void Awake() {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        cutscene.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.GetComponent<PlayerMovement>() != null) {
            cutscene.SetActive(true);
            gameManager.PickupItem(this);
            collision.GetComponent<PlayerMovement>().StopMovement();
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
