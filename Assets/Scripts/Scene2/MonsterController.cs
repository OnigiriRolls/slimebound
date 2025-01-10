using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject particles;
    public float moveSpeed = 3f;
    public float effectDuration = 0.1f;

    Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = direction * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement;
    }

    public void SetMovement(Vector3 direction)
    {
        this.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.BACKGROUND))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(effect, effectDuration);
    }
}
