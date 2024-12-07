using UnityEngine;

public class EnemyPositionController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Transform initialPosition;
    public Transform attackPosition;
    public float speed = 3f;
    public GameObject minionSpawner;

    bool inZone = false;
    Animator anim;
    Transform targetPosition;

    void Start()
    {
        targetPosition = initialPosition;
        anim = enemy.GetComponent<Animator>();
    }

    void Update()
    {
        if (enemy.activeInHierarchy)
        {
            if ((inZone && anim.GetBool(GlobalConstants.ANIM_COND_OPEN) && enemy.transform != attackPosition) ||
            (!inZone && anim.GetBool(GlobalConstants.ANIM_COND_OPEN) && enemy.transform != initialPosition))
            {
                enemy.transform.position = Vector2.MoveTowards(
                    enemy.transform.position,
                    targetPosition.position,
                    speed * Time.deltaTime
                );
            }
            else if (!anim.GetBool(GlobalConstants.ANIM_COND_OPEN) && enemy.transform != initialPosition)
            {
                enemy.transform.position = Vector2.MoveTowards(
                    enemy.transform.position,
                    initialPosition.position,
                    speed * Time.deltaTime
                );
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PLAYER) || collision.CompareTag(GlobalConstants.PLAYER_UNDETACTABLE))
        {
            targetPosition = attackPosition;
            inZone = true;
            if (minionSpawner != null) minionSpawner.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PLAYER) ||
            collision.CompareTag(GlobalConstants.PLAYER_UNDETACTABLE))
        {
            targetPosition = initialPosition;
            inZone = false;
            if (minionSpawner != null) minionSpawner.SetActive(false);
        }
    }
}
