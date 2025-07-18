using UnityEngine;
using UnityEngine.InputSystem;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] private string dialogueText = "Olá, viajante!";
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TMPro.TextMeshProUGUI dialogueTextBox;

    private bool playerInRange = false;
    private PlayerMovementGenerated input;

    private void Awake()
    {
        input = new PlayerMovementGenerated();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Movement.Interact.performed += OnInteract; // nome da action
    }

    private void OnDisable()
    {
        input.Movement.Interact.performed -= OnInteract;
        input.Disable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueUI.SetActive(false);
        }
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        if (playerInRange)
        {
            dialogueUI.SetActive(true);
            dialogueTextBox.text = dialogueText;
        }
    }
}
