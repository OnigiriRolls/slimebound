using System.Collections;
using UnityEngine;

public class BossMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float delay = 0.1f; 
    public GameObject target;
    public GameObject boss;
    public float safeDistance = 2f; 
    public float deadZone = 0.1f; 

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 lastTargetPosition;
    private bool isDelayed = false;
    private bool isFacingLeft = true;

    void OnEnable()
    {
        rb = boss.GetComponent<Rigidbody2D>();
        if (target != null)
        {
            lastTargetPosition = target.transform.position; 
        }
    }

    void Update()
    {
        if (target == null) return;

        if (!isDelayed)
        {
            StartCoroutine(UpdateTargetAfterDelay());
        }

        var bossPosition = boss.transform.position;
        var directionX = lastTargetPosition.x - bossPosition.x; 
        var distanceToPlayer = Mathf.Abs(directionX);

        if (distanceToPlayer < safeDistance - deadZone)
        {
            var moveDirection = new Vector2(-Mathf.Sign(directionX), 0).normalized;
            movement = moveDirection * moveSpeed;
        }
        else if (distanceToPlayer > safeDistance + deadZone)
        {
            var moveDirection = new Vector2(Mathf.Sign(directionX), 0).normalized;
            movement = moveDirection * moveSpeed;
        }
        else
        {
            movement = Vector2.zero;
        }

        FlipBoss(directionX);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement.x, 0);
    }

    IEnumerator UpdateTargetAfterDelay()
    {
        isDelayed = true;
        yield return new WaitForSeconds(delay);

        if (target != null)
        {
            lastTargetPosition = target.transform.position;
        }
        isDelayed = false;
    }

    private void FlipBoss(float directionX)
    {
        if (directionX > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            Flip();
        }
        else if (directionX < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 currentScale = boss.transform.localScale;
        currentScale.x *= -1; 
        boss.transform.localScale = currentScale;
    }
}
