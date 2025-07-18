using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private HealthBar healthBar;
    private PlayerMovementGenerated input;

    private void Awake()
    {
        input = new PlayerMovementGenerated(); // Nome do seu .inputactions gerado
    }

    private void OnEnable()
    {
        input.Enable();
        input.Debug.TestDamage.performed += OnTestDamage;
        // Substitua "Debug" pelo nome do seu Action Map
        // Substitua "TestDamage" pelo nome da Action
    }

    private void OnDisable()
    {
        input.Debug.TestDamage.performed -= OnTestDamage;
        input.Disable();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar = FindFirstObjectByType<HealthBar>();
        healthBar.SetHealth(currentHealth, maxHealth);
    }

    private void OnTestDamage(InputAction.CallbackContext ctx)
    {
        TakeDamage(10f);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player morreu!");
            // TODO: lógica de morte
        }
    }
}
