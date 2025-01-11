using UnityEngine;

public class MonsterControllerFromBoss : MonoBehaviour
{
    public GameObject particles;
    public float moveSpeed = 3f;
    public float effectDuration = 0.1f;

    Rigidbody2D rb;
    Vector2 movement;
    ParentPlayerEmptyScript target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindFirstObjectByType<ParentPlayerEmptyScript>();
    }

    void Update()
    {
        if (target == null) return;
        var direction = (target.transform.position - transform.position).normalized;

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

    private void OnDestroy()
    {
        GameObject effect = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(effect, effectDuration);
    }
}
