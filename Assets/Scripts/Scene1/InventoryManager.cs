using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public GameObject robotSlimeImage;
    public GameObject stealthSlimeImage;
    public GameObject robotSlime;
    public GameObject stealthSlime;
    public GameObject stats;
    public GameObject notificationObject;
    private bool isStealthSlimeActive = true;
    private NotificationController notificationController;

    void Start()
    {
        notificationController = notificationObject.GetComponent<NotificationController>();
    }

    public void SwitchSlime(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (stealthSlime.activeInHierarchy == false || !stealthSlime.CompareTag(GlobalConstants.PLAYER_UNDETACTABLE))
            {
                isStealthSlimeActive = !isStealthSlimeActive;
                stealthSlimeImage.SetActive(!isStealthSlimeActive);
                robotSlimeImage.SetActive(isStealthSlimeActive);
                SwitchSlimeInstance();
            }
            else
            {
                notificationController.ShowNotification(GlobalConstants.MESSAGE_NO_SWITCH_NOW);
            }
        }
    }

    private void SwitchSlimeInstance()
    {
        if (isStealthSlimeActive)
        {
            robotSlime.SetActive(false);
            stealthSlime.transform.position = robotSlime.transform.position;
            stats.SetActive(true);
            stealthSlime.SetActive(true);
        }
        else
        {
            stats.SetActive(false);
            stealthSlime.SetActive(false);
            robotSlime.transform.position = stealthSlime.transform.position;
            robotSlime.SetActive(true);
        }
    }
}
