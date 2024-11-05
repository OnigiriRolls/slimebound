using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    private readonly string PLAYER_UNDETACTABLE = "Player Undetactable";
    private readonly string PLAYER = "Player";

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
            Hide();
    }

    private void Hide()
    {
        if (CompareTag(PLAYER))
            tag = PLAYER_UNDETACTABLE;
        else tag = PLAYER;
        Debug.Log("hide");
    }
}
