using System.Collections;
using UnityEngine;

public class MinionSpawnerController : MonoBehaviour
{
    public GameObject minion;
    public float pauseTime = 1.5f;

    private Coroutine waitCoroutine;

    void OnEnable()
    {
        if(waitCoroutine != null)
        {
            StopCoroutine(waitCoroutine);
            waitCoroutine = null;
        }
        waitCoroutine = StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(pauseTime);
        if (minion != null)
        {
            minion.transform.position = transform.position;
            minion.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
