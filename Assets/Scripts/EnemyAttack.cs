using UnityEngine;

public class EnemyAttack : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("enter");
        }
    }
}
