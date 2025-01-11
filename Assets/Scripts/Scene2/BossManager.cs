using System.Threading;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject spawner; 
    public GameObject monster;
    public GameObject manager;

    Animator animator;
    FightManager fightManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        fightManager = manager.GetComponent<FightManager>();
    }

    public void ActivateSpawner()
    {
        if (spawner != null && monster != null)
        {
            Instantiate(monster, spawner.transform.position, Quaternion.identity);
        }
    }

    public void StartShortAttack()
    {
        fightManager.UnfreezePlayer();
        fightManager.StartShortAttack();
    }
}
