using TMPro;
using UnityEngine;

public class FloorGameOver : MonoBehaviour
{
    public GameObject menu;
    public GameObject restartButton;
    public GameObject continueButton;
    public TextMeshProUGUI text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains(GlobalConstants.PLAYER))
        {
            continueButton.SetActive(false);
            restartButton.SetActive(true);
            text.SetText(GlobalConstants.MESSAGE_GAME_OVER);
            menu.SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag(GlobalConstants.MONSTER))
        {
            Destroy(collision.gameObject);
        }
    }
}
