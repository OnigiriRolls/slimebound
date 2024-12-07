using UnityEngine;

public class MinionController : MonoBehaviour
{
    public GameObject particles;
    public float effectDuration = 0.1f;
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    PlayerMovement target;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        if (target == null) return;
        Vector2 direction = (target.transform.position - transform.position).normalized;

        if (Vector2.Distance(transform.position, target.transform.position) > 0)
        {
            movement = direction * moveSpeed;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.SIMPLE_LASER) || collision.CompareTag(GlobalConstants.LASER_BEAM))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(effect, effectDuration);
    }
}
