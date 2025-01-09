using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2 : MonoBehaviour
{
    public float speed = 10f;
    public float stickRadius;
    public bool facingLeft = true;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementInput.x * speed, rb.linearVelocity.y);
        SetPlayerDirection();
        SetAnimation();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void SetAnimation()
    {
        bool isSlithering = movementInput != Vector2.zero;
        animator.SetBool("slither", isSlithering);
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
}
