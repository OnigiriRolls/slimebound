using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BigEnemyController : MonoBehaviour
{
    public GameObject laserSpawner;
    public GameObject doorFinishZone;
    public float laserTime = 5;
    public float idleTime = 5;
    [SerializeField] private Slider healthSlider;
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
        healthSlider.gameObject.SetActive(true);
        yield return new WaitForSeconds(idleTime);
        healthSlider.gameObject.SetActive(false);
        anim.SetBool("close", false);
        anim.SetBool("open", true);
        StartCoroutine(LaserTimeCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.SIMPLE_LASER) && healthSlider.IsActive())
        {
            Debug.Log("laser beam");
            healthSlider.value += 0.01f;
            if (healthSlider.value >= 1)
            {
                Debug.Log("enemy destroyed");
                healthSlider.gameObject.SetActive(false);
                gameObject.SetActive(false);
                doorFinishZone.SetActive(true);
            }
        }
    }
}
