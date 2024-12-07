using UnityEngine;

public class UnfreezePlayer : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject notificationManagerObject;
    public GameObject gameManagerObject;
    private NotificationManager notificationManager;
    private StartSecondPart gameManager;

    void Start()
    {
        notificationManager = notificationManagerObject.GetComponent<NotificationManager>();
        gameManager = gameManagerObject.GetComponent<StartSecondPart>();
    }

    public void Unfreeze()
    {
        player.constraints = RigidbodyConstraints2D.None;
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        notificationManager.ShowNotification(GlobalConstants.MESSAGE_SWITCH_ABILITY);
        gameManager.StartPart();
    }
}
