using UnityEngine;

public class FightManager : MonoBehaviour
{
    void Start()
    {
        GetComponent<DeactivateAndActivateGameObjects>().ActivateAndDeactivate();
    }
}
