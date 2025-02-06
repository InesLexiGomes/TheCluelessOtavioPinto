using UnityEngine;

public class DisableOnEnable : MonoBehaviour
{

    private PlayerMovement playerMovement;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private GameObject objectToActivate;

    void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnEnable() {
        playerMovement.StartMovement();
        if(objectToActivate != null) {
            objectToActivate.SetActive(true);
        }
        dialogueCanvas.SetActive(false);

    }
}
