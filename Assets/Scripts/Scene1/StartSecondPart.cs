using System.Collections;
using UnityEngine;

public class StartSecondPart : MonoBehaviour
{
    public GameObject enemy;
    public GameObject laserSpawner;
    public GameObject minionSpawner1;
    public GameObject minionSpawner2;
    public GameObject minionSpawner3;
    private BigEnemyController bigEnemyController;

    private void Start()
    {
        bigEnemyController = enemy.GetComponent<BigEnemyController>();
    }

    public void StartPart()
    {
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        laserSpawner.SetActive(true);
        bigEnemyController.enabled = true;
        minionSpawner1.SetActive(true);
        minionSpawner2.SetActive(true);
        minionSpawner3.SetActive(true);
    }
}
