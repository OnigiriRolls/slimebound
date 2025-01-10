using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public float minTime;
    public float maxTime;
    public GameObject monster;

    void OnEnable()
    {
        var time = Random.Range(minTime, maxTime);
        StartCoroutine(Wait(time));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        var instance = Instantiate(monster, transform.position, Quaternion.identity);
        instance.GetComponent<MonsterController>().SetMovement(transform.up);
        time = Random.Range(minTime, maxTime);
        StartCoroutine(Wait(time));
    }
}
