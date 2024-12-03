using UnityEngine;

public class LaserBeamMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float laserBeamLife = 5f;
    Rigidbody2D rb;
    PlayerMovement target;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = FindFirstObjectByType<PlayerMovement>();
        if (target == null)
            Destroy(gameObject);
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        var angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, laserBeamLife);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER_FOUND))
        {
            Debug.Log("player shot");
            //this.tag = "fish";
            //GetComponent<SpriteRenderer>().enabled = false;
            //transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
