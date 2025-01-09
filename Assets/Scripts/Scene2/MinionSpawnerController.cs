using System.Collections;
using UnityEngine;

public class MinionSpawnerController : MonoBehaviour
{
    public GameObject minion;
    public float pauseTime = 1.5f;

    void OnEnable()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(pauseTime);
        Instantiate(minion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
