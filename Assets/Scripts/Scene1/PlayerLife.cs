using TMPro;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject playerLifeManagerObject;
    private PlayerLifeManager playerLifeManager;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLifeManager = playerLifeManagerObject.GetComponent<PlayerLifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.MINION) ||
            collision.CompareTag(GlobalConstants.LASER_BEAM))
        {
            if (!CompareTag(GlobalConstants.PLAYER_UNDETACTABLE) && rb.constraints == RigidbodyConstraints2D.FreezeRotation)
            {
                playerLifeManager.LoseLife();
            }
            Destroy(collision.gameObject);
        }
    }
}
