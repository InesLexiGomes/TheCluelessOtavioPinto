using UnityEngine;

public class DisableOnEnable : MonoBehaviour
{

    private PlayerMovement playerMovement;

    void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnEnable() {
        gameObject.SetActive(false);
        playerMovement.StartMovement();
    }
}
