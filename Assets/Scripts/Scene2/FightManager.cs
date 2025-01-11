using System.Collections;
using System.Threading;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public Animator bossAnim;
    public GameObject parent;
    public float attackMonsterTime = 1;
    public float shortAttackTime = 1;

    Rigidbody2D rbParent;
    Coroutine attackMonster;
    Coroutine shortAttackMonster;

    public void StartAttackMonster()
    {
        bossAnim.SetTrigger(GlobalConstants.ANIM_COND_ATTACK_AND_SHOOT);
        attackMonster = StartCoroutine(WaitAttack());
        rbParent = parent.GetComponent<Rigidbody2D>();
    }

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(attackMonsterTime);
        bossAnim.SetTrigger(GlobalConstants.ANIM_COND_ATTACK_AND_SHOOT);
        attackMonster = StartCoroutine(WaitAttack());
    }

    public void StartShortAttack()
    {
        bossAnim.SetTrigger(GlobalConstants.ANIM_COND_ATACK_SHORT);
        shortAttackMonster = StartCoroutine(WaitShortAttack());
    }

    IEnumerator WaitShortAttack()
    {
        yield return new WaitForSeconds(shortAttackTime);
        bossAnim.SetTrigger(GlobalConstants.ANIM_COND_ATACK_SHORT);
        shortAttackMonster = StartCoroutine(WaitShortAttack());
    }

    public void StopShortAttack()
    {
        StopCoroutine(shortAttackMonster);
        shortAttackMonster = null;
    }

    public void StopAttackMonster()
    {
        StopCoroutine(attackMonster);
        attackMonster = null;
    }

    public void UnfreezePlayer()
    {
        rbParent.constraints = RigidbodyConstraints2D.None;
        rbParent.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
