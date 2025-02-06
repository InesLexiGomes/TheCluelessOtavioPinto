using UnityEngine;

public class DisableOnEnable : MonoBehaviour
{

    private PlayerMovement playerMovement;
    [SerializeField] private GameObject dialogueCanvas;

    void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnEnable() {
        playerMovement.StartMovement();
        dialogueCanvas.SetActive(false);

    }
}
