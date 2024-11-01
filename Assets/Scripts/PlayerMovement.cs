using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float stickRadius;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Animator animator;
    private bool facingLeft = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movementInput * speed;
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
        if ((movementInput.x < (-1) * stickRadius && facingLeft == false) || 
            (movementInput.x > stickRadius && facingLeft == true))
            Flip();
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
