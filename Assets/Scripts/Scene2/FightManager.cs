using System.Collections;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public Animator bossAnim;
    public GameObject parent;
    public GameObject bossSlider;
    public GameObject bossMovement;
    public GameObject bossSpawners;
    public float attackMonsterTime = 3;
    public float shortTimeMin = 1;
    public float shortTimeMax = 3;
    public float pauseTime = 3;

    Rigidbody2D rbParent;
    Coroutine attackMonster;
    Coroutine shortAttackMonster;

    void Start()
    {
        rbParent = parent.GetComponent<Rigidbody2D>();
    }

    //public void StartAttackMonster()
    //{
    //    bossAnim.SetTrigger(GlobalConstants.ANIM_COND_ATTACK_AND_SHOOT);
    //    attackMonster = StartCoroutine(WaitAttack());
    //}

    //IEnumerator WaitAttack()
    //{
    //    yield return new WaitForSeconds(attackMonsterTime);
    //    bossAnim.SetTrigger(GlobalConstants.ANIM_COND_ATTACK_AND_SHOOT);
    //    attackMonster = StartCoroutine(WaitAttack());
    //}

    public void StartShortAttack()
    {
        StartCoroutine(WaitPause());
    }

    IEnumerator WaitShortAttack(float time)
    {
        yield return new WaitForSeconds(time);
        bossAnim.SetTrigger(GlobalConstants.ANIM_COND_ATACK_SHORT);
        time = Random.Range(shortTimeMin, shortTimeMax);
        shortAttackMonster = StartCoroutine(WaitShortAttack(time));
    }

    IEnumerator WaitPause()
    {
        yield return new WaitForSeconds(pauseTime);
        bossAnim.SetTrigger(GlobalConstants.ANIM_COND_ATACK_SHORT);
        var time = Random.Range(shortTimeMin, shortTimeMax);
        bossMovement.SetActive(true);
        bossSpawners.SetActive(true);
        bossSlider.SetActive(true);
        shortAttackMonster = StartCoroutine(WaitShortAttack(time));
    }

    public void StopShortAttack()
    {
        if (shortAttackMonster != null)
        {
            StopCoroutine(shortAttackMonster);
            shortAttackMonster = null;
        }
    }

    public void StopAttackMonster()
    {
        if (attackMonster != null)
        {
            StopCoroutine(attackMonster);
            attackMonster = null;
        }
    }

    public void UnfreezePlayer()
    {
        rbParent.constraints = RigidbodyConstraints2D.None;
        rbParent.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
