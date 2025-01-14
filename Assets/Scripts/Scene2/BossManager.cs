using UnityEngine;

public class BossManager : MonoBehaviour
{
    //public GameObject spawner;
    //public GameObject monster;
    public GameObject manager;
    public GameObject jumpPosition;
    public GameObject landPosition;
    public float speed = 3;

    Animator animator;
    FightManager fightManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        fightManager = manager.GetComponent<FightManager>();
    }

    //public void ActivateSpawner()
    //{
    //    if (spawner != null && monster != null)
    //    {
    //        Instantiate(monster, spawner.transform.position, Quaternion.identity);
    //    }
    //}

    public void StartShortAttack()
    {
        fightManager.UnfreezePlayer();
        fightManager.StartShortAttack();
    }

    public void Jump()
    {
        while (transform.position != jumpPosition.transform.position)
        {
            transform.position = Vector2.MoveTowards(
                 transform.position,
                 jumpPosition.transform.position,
                 speed * Time.deltaTime
            );
        }
    }

    public void Land()
    {
        while (transform.position != landPosition.transform.position)
        {
            transform.position = Vector2.MoveTowards(
                 transform.position,
                 landPosition.transform.position,
                 speed * Time.deltaTime
            );
        }
    }
}
