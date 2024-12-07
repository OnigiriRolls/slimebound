using UnityEngine;

public class MenuController : MonoBehaviour
{
    DeactivateAndActivateGameObjects deactivateAndActivateGameObjects;

    void Start()
    {
        deactivateAndActivateGameObjects = GetComponent<DeactivateAndActivateGameObjects>();
        deactivateAndActivateGameObjects.ActivateAndDeactivate();
    }
}
