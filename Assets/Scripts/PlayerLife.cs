using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.MINION) && !CompareTag(GlobalConstants.PLAYER_UNDETACTABLE))
        {
            if (!CompareTag(GlobalConstants.PLAYER_UNDETACTABLE))
            {
                Debug.Log("-1 life");
            }
            Destroy(collision.gameObject);
        }
    }
}
