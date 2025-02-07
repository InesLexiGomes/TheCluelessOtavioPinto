using UnityEngine;

public class DisableOnEnable : MonoBehaviour
{

    private PlayerMovement playerMovement;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private GameObject objectToActivate;

    private GameManager gameManager;

    void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnEnable() {
        playerMovement.StartMovement();
        if(objectToActivate != null) {
            objectToActivate.SetActive(true);
        }

        if (gameManager.getItemsLeft() == 0) {
            gameManager.displayAllItemsCutscene();
        }
        dialogueCanvas.SetActive(false);

    }
}
