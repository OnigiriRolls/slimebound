using UnityEngine;

public class LaserBeamSpawner : MonoBehaviour
{
    public float startTimeBtwShots;
    public GameObject projectile;
    private float timeBtwShots;

    //void OnEnable()
    //{
    //    timeBtwShots = startTimeBtwShots;
    //}

    void Update()
    {
        if (timeBtwShots <= 0)
        {

            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
