using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public float laserTime;
    public float pauseAfterLaserTime;
    public GameObject scanLight;
    public GameObject player;
    public GameObject laserBeamSpawner;
    [SerializeField] private Slider healthSlider;

    Animator anim;
    bool scanningAnim = true;

    public void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PLAYER))
        {
            collision.tag = GlobalConstants.PLAYER_FOUND;
            ToggleScanLight();
            EnableLaserAndStartAnim();
            healthSlider.gameObject.SetActive(true);
            StartCoroutine(LaserTimeCoroutine());
        }
    }

    private void ToggleScanLight()
    {
        scanningAnim = !scanningAnim;
        scanLight.SetActive(scanningAnim);
    }

    private void EnableLaserAndStartAnim()
    {
        anim.SetBool(GlobalConstants.ANIM_COND_SCAN, false);
        laserBeamSpawner.SetActive(true);
        anim.SetBool(GlobalConstants.ANIM_COND_OPEN, true);
    }

    private void DisableLaserAndStopAnim()
    {
        anim.SetBool(GlobalConstants.ANIM_COND_OPEN, false);
        laserBeamSpawner.SetActive(false);
        StartCoroutine(PauseAfterLaserTimeCoroutine()); 
        anim.SetBool(GlobalConstants.ANIM_COND_SCAN, true);
    }

    IEnumerator LaserTimeCoroutine()
    {
        yield return new WaitForSeconds(laserTime);
        ToggleScanLight();
        DisableLaserAndStopAnim();
        healthSlider.gameObject.SetActive(false);
        player.tag = GlobalConstants.PLAYER;
    }

    IEnumerator PauseAfterLaserTimeCoroutine()
    {
        yield return new WaitForSeconds(pauseAfterLaserTime);
    }
}
