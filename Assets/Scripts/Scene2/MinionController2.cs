using System;
using UnityEngine;

public class MinionController2 : MonoBehaviour
{
    public GameObject particles;
    public float effectDuration = 0.1f;
    public float moveSpeed = 5f;
    public GameObject target;
    public GameObject spawner;

    Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            gameObject.SetActive(false);
            GameObject effect = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(effect, effectDuration);
            spawner.SetActive(true);
        }
        else if (collision.CompareTag(GlobalConstants.PARENT))
        {
            gameObject.SetActive(false);
            GameObject effect = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(effect, effectDuration);
            spawner.SetActive(true);
        }
    }
}
