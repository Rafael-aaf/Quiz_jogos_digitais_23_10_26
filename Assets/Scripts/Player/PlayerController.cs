using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb2d; // RigidBody2D
    PlayerControls inputActions;
    Vector2 moveInput;
    SpriteRenderer spriteRenderer;
    bool isGrounded;
    bool jumpRequested;
    Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        inputActions = new PlayerControls();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Movement.Move.performed += OnMove;
        inputActions.Movement.Move.canceled += OnMoveDisabled;
        inputActions.Movement.Jump.performed += OnJump;
    }

    void OnDisable()
    {
        inputActions.Movement.Move.performed -= OnMove;
        inputActions.Movement.Move.canceled -= OnMoveDisabled;
        inputActions.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void OnMoveDisabled(InputAction.CallbackContext context)
    {
        moveInput = new Vector2(0, 0);
        // moveInput = Vector2.zero;
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            jumpRequested = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );

        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));
        animator.SetFloat("VerticalVelocity", rb2d.linearVelocity.y);
        animator.SetBool("isGrounded", isGrounded);
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.linearVelocity.y);

        if(moveInput.x > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveInput.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }

        if (jumpRequested)
        {
            rb2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumpRequested = false;
        }

        if (rb2d.linearVelocity.y < 0f)
        {
            rb2d.gravityScale = 6f;
        }
        else
        {
            rb2d.gravityScale = 2f;
        }
    }
}
