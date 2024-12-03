using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI cooldownText; 
    public float cooldownDuration = 5f;

    private float cooldownTimeRemaining = 0f;

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && cooldownTimeRemaining == 0)
            Hide();
    }

    private void Hide()
    {
        if (CompareTag(GlobalConstants.PLAYER))
            tag = GlobalConstants.PLAYER_UNDETACTABLE;
        animator.SetLayerWeight(1, 1f);
        animator.Play("Hide", 1);
    }

    public void StartAbilityCooldown()
    {
        cooldownTimeRemaining = cooldownDuration;
    }

    void Update()
    {
        if (cooldownTimeRemaining > 0)
        {
            cooldownTimeRemaining -= Time.deltaTime;

            if (cooldownTimeRemaining < 0)
                cooldownTimeRemaining = 0;
            UpdateCooldownText();
        }
    }

    private void UpdateCooldownText()
    {
        if (cooldownTimeRemaining > 0)
        {
            cooldownText.text = Mathf.Ceil(cooldownTimeRemaining).ToString();
        }
        else
        {
            cooldownText.text = "-";
        }
    }
}
