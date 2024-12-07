using TMPro;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    public GameObject[] lives;
    public int livesNumber = 3;
    public GameObject panel;
    public TextMeshProUGUI text;
    public GameObject continueButton;
    public GameObject restartButton;

    public void LoseLife()
    {
        livesNumber--;
        if (livesNumber > 0)
            lives[livesNumber].SetActive(false);
        else
        {
            text.SetText(GlobalConstants.MESSAGE_GAME_OVER);
            continueButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
            panel.SetActive(true);
        }
    }
}
