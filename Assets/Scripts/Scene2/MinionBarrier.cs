using UnityEngine;

public class MinionBarrier : MonoBehaviour
{
    public GameObject barrier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(GlobalConstants.MINION))
        {
            collision.gameObject.GetComponent<MinionController2>().target = barrier;
        }
    }
}
