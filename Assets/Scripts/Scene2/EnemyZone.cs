using System.Collections;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    public GameObject laserSpawner;
    public GameObject healthSlider;
    public GameObject barrier;
    public float laserTime = 4;
    public float damageTime = 2;
    public float pauseTime = 1.5f;

    private Coroutine laserCoroutine;  
    private Coroutine damageCoroutine; 
    private Coroutine pauseCoroutine; 

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
            if(laserSpawner != null) 
                laserSpawner.SetActive(false);
            if(healthSlider != null)
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

        if (pauseCoroutine != null)
        {
            StopCoroutine(pauseCoroutine);
            pauseCoroutine = null;
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
        laserSpawner.SetActive(false);
        pauseCoroutine = StartCoroutine(WaitPause());
    }

    IEnumerator WaitPause()
    {
        yield return new WaitForSeconds(pauseTime);
        laserSpawner.SetActive(true);
        healthSlider.SetActive(false);
        laserCoroutine = StartCoroutine(WaitLaser());
    }
}
