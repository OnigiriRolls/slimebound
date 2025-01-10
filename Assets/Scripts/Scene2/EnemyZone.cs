using System.Collections;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    public GameObject laserSpawner;
    public GameObject healthSlider;
    public GameObject barrier;
    public float laserTime = 4;
    public float damageTime = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains(GlobalConstants.PARENT))
        {
            StopCoroutine(WaitLaser());
            StopCoroutine(WaitDamage());
            laserSpawner.SetActive(true);
            if (!barrier.activeInHierarchy)
                StartCoroutine(WaitLaser());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Contains(GlobalConstants.PARENT))
        {
            laserSpawner.SetActive(false);
            healthSlider.SetActive(false);
            if (!barrier.activeInHierarchy)
            {
                StopCoroutine(WaitLaser());
                StopCoroutine(WaitDamage());
            }
        }
    }

    IEnumerator WaitLaser()
    {
        yield return new WaitForSeconds(laserTime);
        laserSpawner.SetActive(false);
        healthSlider.SetActive(true);
        StartCoroutine(WaitDamage());
    }

    IEnumerator WaitDamage()
    {
        yield return new WaitForSeconds(damageTime);
        healthSlider.SetActive(false);
        laserSpawner.SetActive(true);
        StartCoroutine(WaitLaser());
    }
}
