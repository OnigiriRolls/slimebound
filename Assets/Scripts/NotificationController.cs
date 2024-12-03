using System.Collections;
using TMPro;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
    private TextMeshProUGUI text;
    private float notificationTime = 3;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ShowNotification(string msg)
    {
        text.SetText(msg);
        StartCoroutine(NotificationTimeCoroutine());
    }

    IEnumerator NotificationTimeCoroutine()
    {
        yield return new WaitForSeconds(notificationTime);
        text.SetText("");
    }
}
