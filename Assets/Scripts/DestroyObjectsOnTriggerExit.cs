using UnityEngine;

public class DestroyObjectsOnTriggerExit : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.SIMPLE_LASER))
            Destroy(collision.gameObject);
    }
}
