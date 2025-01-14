using UnityEngine;

public class RightZoneController : MonoBehaviour
{
    public GameObject manager;

    FightManager fightManager;

    void Start()
    {
        fightManager = manager.GetComponent<FightManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PARENT))
        {
            //fightManager.StartAttackMonster();
        }
    }
}
