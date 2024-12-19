using UnityEngine;

public class InventoryManager2 : MonoBehaviour
{
    public GameObject[] covers;
    public GameObject[] slimes;

    public void ActivatePink(int coverToActivate, int coverToDeactivate)
    {
        covers[coverToActivate].gameObject.SetActive(true);
        covers[coverToDeactivate].gameObject.SetActive(false);
    }

    public void ActivateRobot(int coverToActivate, int coverToDeactivate)
    {
        covers[coverToActivate].gameObject.SetActive(true);
        covers[coverToDeactivate].gameObject.SetActive(false);
    }

    public void ActivateStealth(int coverToActivate, int coverToDeactivate)
    {
        covers[coverToActivate].gameObject.SetActive(true);
        covers[coverToDeactivate].gameObject.SetActive(false);
    }

    public void ActivateCover(int coverToActivate, int coverToDeactivate)
    {
        covers[coverToActivate].gameObject.SetActive(true);
        covers[coverToDeactivate].gameObject.SetActive(false);
    }
}
