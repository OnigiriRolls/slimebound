using UnityEngine;

public class MenuController : MonoBehaviour
{
    DeactivateAndActivateGameObjects deactivateAndActivateGameObjects;

    void Start()
    {
        Debug.Log("deactivate?");
        deactivateAndActivateGameObjects = GetComponent<DeactivateAndActivateGameObjects>();
        deactivateAndActivateGameObjects.ActivateAndDeactivate();
    }
}
