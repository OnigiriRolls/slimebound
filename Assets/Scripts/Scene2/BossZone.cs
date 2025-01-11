using UnityEngine;

public class BossZone : MonoBehaviour
{
    public GameObject stopZone;
    public Animator bossAnim;
    public GameObject parent;
    public GameObject manager;

    private FightManager fightManager;
    private Rigidbody2D rb;

    void Start()
    {
        rb = parent.GetComponent<Rigidbody2D>();
        fightManager = manager.GetComponent<FightManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PARENT))
        {
            Debug.Log("start fight");
            stopZone.SetActive(true);
            fightManager.StopAttackMonster();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            bossAnim.SetTrigger(GlobalConstants.ANIM_COND_JUMP);
            gameObject.SetActive(false);
        }
    }
}
