using Unity.VisualScripting;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField] private GameObject cutscene;

    private void Awake() {
        cutscene.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.GetComponent<PlayerMovement>() != null) {
            cutscene.SetActive(true);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PickupItem(this);
            Destroy(gameObject);
        }
    }
}
