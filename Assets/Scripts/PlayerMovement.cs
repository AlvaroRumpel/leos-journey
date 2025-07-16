using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerMovementGenerated input;
    private Rigidbody2D rb;
    private Vector2 movement;

    private Animator animator;

    private void Awake()
    {
        input = new PlayerMovementGenerated();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable() => input.Enable();
    private void OnDisable() => input.Disable();

    private void Update()
    {
        // Captura o input
        movement = input.Movement.Move.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        // Atualiza o Animator
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            if (Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
            {
                 animator.SetInteger("Direction", movement.y > 0 ? (int)Direction.Up : (int)Direction.Down);
                return;
            }

            animator.SetInteger("Direction",movement.x > 0 ? (int)Direction.Left : (int)Direction.Right);
            return;
        }

        animator.SetInteger("Direction", (int)Direction.Left);
    }
}

enum Direction
{
    Left = 0,
    Right = 1,
    Up = 2,
    Down = 3
}
