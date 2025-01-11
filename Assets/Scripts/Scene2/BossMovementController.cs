using UnityEngine;

public class BossMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject target;
    public GameObject boss;

    Rigidbody2D rb;
    private Vector2 movement;

    void OnEnable()
    {
        rb = boss.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target == null) return;
        var playerPosition = target.transform.position;
        var bossPosition = boss.transform.position;
        var directionX = playerPosition.x - bossPosition.x;
        var moveDirection = new Vector2(directionX, 0).normalized;

        if (Vector2.Distance(boss.transform.position, target.transform.position) > 0)
        {
            movement = moveDirection * moveSpeed;
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }
}
