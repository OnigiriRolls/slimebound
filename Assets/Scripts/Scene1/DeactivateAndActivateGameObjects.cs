using UnityEngine;
using UnityEngine.Rendering;

public class DeactivateAndActivateGameObjects : MonoBehaviour
{
    public GameObject[] gameObjectsToActivate;
    public GameObject[] gameObjectsToDeactivate;

    public void ActivateAndDeactivate()
    {
        foreach (var gameObject in gameObjectsToDeactivate)
        {
            gameObject.SetActive(false);
        }

        foreach (var gameObject in gameObjectsToActivate)
        {
            gameObject.SetActive(true);
        }
    }
}
