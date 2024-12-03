using UnityEngine;

public class SimpleLaserMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    float laserBeamLife = 5f;
    Rigidbody2D rb;
    Vector2 moveDirection;

    public void StartMovement(float scaleX)
    {
        rb = GetComponent<Rigidbody2D>();
        var isFacingLeft = scaleX >= 0 ? 1 : -1;
        moveDirection = new Vector2(isFacingLeft * moveSpeed, 0);
        rb.linearVelocity = moveDirection;
        var angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Destroy(gameObject, laserBeamLife);
    }
}
