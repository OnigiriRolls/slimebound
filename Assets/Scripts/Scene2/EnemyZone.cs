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
        if (collision.tag.Contains(GlobalConstants.PLAYER))
        {
            StopCoroutine(WaitLaser());
            StopCoroutine(WaitDamage());
            Debug.Log("enter");
            laserSpawner.SetActive(true);
            //if (!barrier.activeInHierarchy)
                StartCoroutine(WaitLaser());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Contains(GlobalConstants.PLAYER))
        {
            Debug.Log("exit");
            laserSpawner.SetActive(false);
            healthSlider.SetActive(false);
           // if (!barrier.activeInHierarchy)
            //{
                //Debug.Log("stop");
                StopCoroutine(WaitLaser());
                StopCoroutine(WaitDamage());
           // }
        }
    }

    IEnumerator WaitLaser()
    {
//Debug.Log("laser enter");
        yield return new WaitForSeconds(laserTime);
        laserSpawner.SetActive(false);
        healthSlider.SetActive(true);
        //Debug.Log("laser exit");
        StartCoroutine(WaitDamage());
    }

    IEnumerator WaitDamage()
    {
        //Debug.Log("damage enter");
        yield return new WaitForSeconds(damageTime);
        healthSlider.SetActive(false);
        laserSpawner.SetActive(true);
        //Debug.Log("damage exit");
        StartCoroutine(WaitLaser());
    }
}
