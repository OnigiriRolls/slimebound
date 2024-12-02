using System.Collections;
using UnityEngine;

public class BigEnemyController : MonoBehaviour
{
    public GameObject laserSpawner;
    public float laserTime = 5;
    public float idleTime = 5;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("scan", false);
        anim.SetBool("open", true);
        StartCoroutine(LaserTimeCoroutine());
    }

    IEnumerator LaserTimeCoroutine()
    {
        laserSpawner.SetActive(true);
        yield return new WaitForSeconds(laserTime);
        laserSpawner.SetActive(false);
        StartCoroutine(IdleTimeCoroutine());
    }

    IEnumerator IdleTimeCoroutine()
    {
        anim.SetBool("open", false);
        anim.SetBool("close", true);
        yield return new WaitForSeconds(idleTime);
        anim.SetBool("close", false);
        anim.SetBool("open", true);
        StartCoroutine(LaserTimeCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.LASER_BEAM))
        {
            Debug.Log("laser beam");
            //healthSlider.value += 0.2f;

            //if (healthSlider.value >= 1)
            //{
            //    Debug.Log("cell destroyed");
            //    healthSlider.gameObject.SetActive(false);
            //    enemy.SetActive(false);
            //    cell.SetBool(GlobalConstants.ANIM_COND_DESTROY, true);
            //}
        }
    }
}
