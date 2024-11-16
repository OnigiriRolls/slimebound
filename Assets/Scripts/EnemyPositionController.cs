using UnityEngine;

public class EnemyPositionController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Transform initialPosition;
    public Transform attackPosition;
    public float speed = 3f;

    bool inZone = false;
    Transform targetPosition;

    void Start()
    {
        targetPosition = initialPosition;
    }

    void Update()
    {
        if ((inZone && player.CompareTag(GlobalConstants.PLAYER_FOUND) && enemy.transform != attackPosition) ||
            (!inZone && enemy.transform != initialPosition))
        {
            enemy.transform.position = Vector2.MoveTowards(
                enemy.transform.position,
                targetPosition.position,
                speed * Time.deltaTime
            );
        } else if (inZone && !player.CompareTag(GlobalConstants.PLAYER_FOUND) && enemy.transform != initialPosition)
        {
            enemy.transform.position = Vector2.MoveTowards(
                enemy.transform.position,
                initialPosition.position,
                speed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PLAYER_FOUND))
        {
            targetPosition = attackPosition;
            inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PLAYER_FOUND) ||
            collision.CompareTag(GlobalConstants.PLAYER) ||
            collision.CompareTag(GlobalConstants.PLAYER_UNDETACTABLE))
        {
            targetPosition = initialPosition;
            inZone = false;
        }
    }
}
