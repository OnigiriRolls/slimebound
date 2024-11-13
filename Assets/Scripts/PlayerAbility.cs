using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    public Animator animator;

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
            Hide();
    }

    private void Hide()
    {
        if (CompareTag(GlobalConstants.PLAYER))
            tag = GlobalConstants.PLAYER_UNDETACTABLE;
        animator.SetLayerWeight(1, 1f);
        animator.Play("Hide", 1);
    }
}
