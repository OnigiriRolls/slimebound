using System.Collections;
using UnityEngine;

public class SceneFadeOut : MonoBehaviour
{
    public Animator transitionAnim;

    void Awake()
    {
        Debug.Log("awake");
    }

    void Start()
    {
        Debug.Log("start");
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        transitionAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(1.5f);
        transitionAnim.gameObject.SetActive(false);
    }
}
