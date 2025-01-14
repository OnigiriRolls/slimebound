using TMPro;
using UnityEngine;

public class PlayerLifeManager2 : MonoBehaviour
{
    public GameObject[] lives;
    public int livesNumber = 3;
    public GameObject panel;
    public TextMeshProUGUI text;
    public GameObject restartButton;

    private DeactivateAndActivateGameObjects deactivateAndActivateGameObjects;

    void Start()
    {
        deactivateAndActivateGameObjects = GetComponent<DeactivateAndActivateGameObjects>();
    }

    public void LoseLife()
    {
        livesNumber--;
        if (livesNumber > 0)
            lives[livesNumber].SetActive(false);
        else
        {
            deactivateAndActivateGameObjects.ActivateAndDeactivate();
            text.SetText(GlobalConstants.MESSAGE_GAME_OVER);
            restartButton.gameObject.SetActive(true);
            panel.SetActive(true);
        }
    }
}
