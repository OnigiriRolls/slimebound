using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager2 : MonoBehaviour
{
    public GameObject robotSlimeImage;
    public GameObject flySlimeImage;
    public GameObject parent;
    public GameObject robotSlime;
    public GameObject flySlime;
    public GameObject notificationObject;

    private Rigidbody2D rb;
    private bool isFlySlimeActive = true;
    private NotificationController notificationController;

    void Start()
    {
        notificationController = notificationObject.GetComponent<NotificationController>();
        rb = parent.GetComponent<Rigidbody2D>();
    }

    public void SwitchSlime(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (flySlime.activeInHierarchy == false || !flySlime.CompareTag(GlobalConstants.PLAYER_FLYING))
            {
                isFlySlimeActive = !isFlySlimeActive;
                flySlimeImage.SetActive(!isFlySlimeActive);
                robotSlimeImage.SetActive(isFlySlimeActive);
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
        if (isFlySlimeActive)
        {
            robotSlime.SetActive(false);
            if ((robotSlime.transform.localScale.x >= 0 && flySlime.transform.localScale.x < 0)
                || (robotSlime.transform.localScale.x < 0 && flySlime.transform.localScale.x >= 0))
            {
                flySlime.transform.localScale = new Vector3(
                    flySlime.transform.localScale.x * (-1),
                    flySlime.transform.localScale.y,
                    flySlime.transform.localScale.z);
                flySlime.GetComponent<FlyAbility>().facingLeft = !flySlime.GetComponent<FlyAbility>().facingLeft;
            }
            rb.gravityScale = 2f;
            flySlime.SetActive(true);
        }
        else
        {
            flySlime.SetActive(false);
            if ((flySlime.transform.localScale.x >= 0 && robotSlime.transform.localScale.x < 0)
                || (flySlime.transform.localScale.x < 0 && robotSlime.transform.localScale.x >= 0))
            {
                robotSlime.transform.localScale = new Vector3(
                    robotSlime.transform.localScale.x * (-1),
                    robotSlime.transform.localScale.y,
                    robotSlime.transform.localScale.z);
                robotSlime.GetComponent<PlayerMovement2>().facingLeft = !robotSlime.GetComponent<PlayerMovement2>().facingLeft;
            }
            rb.gravityScale = 10f;
            robotSlime.SetActive(true);
        }
    }
}
