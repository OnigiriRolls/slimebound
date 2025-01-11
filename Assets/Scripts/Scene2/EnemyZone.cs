using System.Collections;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    public GameObject laserSpawner;
    public GameObject healthSlider;
    public GameObject barrier;
    public float laserTime = 4;
    public float damageTime = 2;

    private Coroutine laserCoroutine;  
    private Coroutine damageCoroutine; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains(GlobalConstants.PARENT))
        {
            StopAllActiveCoroutines();
            laserSpawner.SetActive(true);
            if (!barrier.activeInHierarchy)
                laserCoroutine = StartCoroutine(WaitLaser());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Contains(GlobalConstants.PARENT))
        {
            laserSpawner.SetActive(false);
            healthSlider.SetActive(false);
            StopAllActiveCoroutines();
        }
    }

    private void StopAllActiveCoroutines()
    {
        if (laserCoroutine != null)
        {
            StopCoroutine(laserCoroutine);
            laserCoroutine = null;
        }

        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    IEnumerator WaitLaser()
    {
        yield return new WaitForSeconds(laserTime);
        laserSpawner.SetActive(false);
        healthSlider.SetActive(true);
        damageCoroutine = StartCoroutine(WaitDamage());
    }

    IEnumerator WaitDamage()
    {
        yield return new WaitForSeconds(damageTime);
        healthSlider.SetActive(false);
        laserSpawner.SetActive(true);
        laserCoroutine = StartCoroutine(WaitLaser());
    }
}
