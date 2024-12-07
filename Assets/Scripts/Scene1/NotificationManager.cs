using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI notificationText;

    public void ShowNotification(string message)
    {
        notificationText.SetText(message);
        panel.SetActive(true);
    }

    public void HideNotification()
    {
        panel.SetActive(false);
    }
}
