using UnityEngine;

public class FloorGameOver : MonoBehaviour
{
    public GameObject menu;
    public GameObject restartButton;
    public GameObject continueButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains(GlobalConstants.PLAYER))
        {
            continueButton.SetActive(false);
            restartButton.SetActive(true);
            menu.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
