using UnityEngine;

public class LaserBeamMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float laserBeamLife = 5f;
    Rigidbody2D rb;
    PlayerHealth2 target;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindFirstObjectByType<PlayerHealth2>();
        if (target == null)
            Destroy(gameObject);
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        var angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, laserBeamLife);
    }
}
