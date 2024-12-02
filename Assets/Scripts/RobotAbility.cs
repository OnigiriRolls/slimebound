using UnityEngine;
using UnityEngine.InputSystem;

public class RobotAbility : MonoBehaviour
{
    public GameObject laser;
    public Transform spawnPoint;
    public float fireRate = 0.2f; 

    private bool isFiring = false; 
    private float nextFireTime = 0f;

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Shoot();
            isFiring = true; 
        }
        else if (context.canceled) 
        {
            isFiring = false;
        }
    }

    void Update()
    {
        if (isFiring && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        var laserObject = Instantiate(laser, spawnPoint.position, Quaternion.identity);
        laserObject.GetComponent<SimpleLaserMovement>().StartMovement(transform.localScale.x);
    }
}
