using UnityEngine;
using UnityEngine.InputSystem;

public class FlyAbility : MonoBehaviour
{
    public float speed = 10f;
    public float stickRadius;
    public bool facingLeft = false;
    public GameObject parent;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Animator animator;
    private bool isFlying = false;

    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        rb = parent.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (IsGrounded())
        {
            if (isFlying)
            {
                SetAnimation(false);
            }
            rb.linearVelocity = new Vector2(0, movementInput.y * speed);
        }
        else
        {
            if (!isFlying)
            {
                SetAnimation(true);
            }
            rb.linearVelocity = movementInput * speed;
        }
        SetPlayerDirection();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void SetAnimation(bool isFlyingNow)
    {
        isFlying = isFlyingNow;
        animator.SetBool("fly", isFlyingNow);
        if (isFlyingNow) gameObject.tag = GlobalConstants.PLAYER_FLYING;
        else gameObject.tag = GlobalConstants.PLAYER;
    }

    private void SetPlayerDirection()
    {
        if ((movementInput.x < 0 && facingLeft == false) ||
            (movementInput.x > 0 && facingLeft == true))
            Flip();
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundLayer);
    }
}
