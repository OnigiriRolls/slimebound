using TMPro;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameObject menuPanel;
    public TextMeshProUGUI text;
    public GameObject continueButton;
    public GameObject restartButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PLAYER) || collision.CompareTag(GlobalConstants.PLAYER_UNDETACTABLE))
        {
            collision.tag = GlobalConstants.PLAYER_UNDETACTABLE;
            text.SetText(GlobalConstants.MESSAGE_WIN);
            restartButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(true);
            menuPanel.SetActive(true);
        }
    }
}
