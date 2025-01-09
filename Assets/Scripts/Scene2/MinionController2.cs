using System;
using UnityEngine;

public class MinionController2 : MonoBehaviour
{
    public GameObject particles;
    public float effectDuration = 0.1f;
    public float moveSpeed = 5f;
    public GameObject target;

    Rigidbody2D rb;
    private Vector2 movement;
    private DeactivateAndActivateGameObjects spawner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawner = FindFirstObjectByType<DeactivateAndActivateGameObjects>();
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
        if (collision.CompareTag(GlobalConstants.SIMPLE_LASER))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(effect, effectDuration);
        spawner.ActivateAndDeactivate();
    }
}
