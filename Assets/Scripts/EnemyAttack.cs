using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float laserTime;
    public GameObject scanLight;
    public GameObject player;

    Animator anim;
    bool scanningAnim = true;
    LaserMovement laserMovement;

    public void Start()
    {
        anim = GetComponentInParent<Animator>();
        laserMovement = GetComponentInParent<LaserMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PLAYER))
        {
            collision.tag = GlobalConstants.PLAYER_FOUND;
            ToggleScanLight();
            EnableLaserAndStartAnim();
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
        laserMovement.EnableLaser();
        anim.SetBool(GlobalConstants.ANIM_COND_OPEN, true);
    }

    private void DisableLaserAndStopAnim()
    {
        anim.SetBool(GlobalConstants.ANIM_COND_OPEN, false);
        laserMovement.DisableLaser();
        anim.SetBool(GlobalConstants.ANIM_COND_SCAN, true);
    }

    IEnumerator LaserTimeCoroutine()
    {
        yield return new WaitForSeconds(laserTime);
        ToggleScanLight();
        DisableLaserAndStopAnim();
        player.tag = GlobalConstants.PLAYER;
    }
}
