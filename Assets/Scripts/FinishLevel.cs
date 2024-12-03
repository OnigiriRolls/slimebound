using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PLAYER))
            Debug.Log("game finish");
    }
}
