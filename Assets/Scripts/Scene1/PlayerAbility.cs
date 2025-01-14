using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    public Animator animator;
    public AudioResource audioResource;
    public TextMeshProUGUI cooldownText;
    public float cooldownDuration = 5f;

    private float cooldownTimeRemaining = 0f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && cooldownTimeRemaining == 0)
            Hide();
    }

    private void Hide()
    {
        if (CompareTag(GlobalConstants.PLAYER))
        {
            tag = GlobalConstants.PLAYER_UNDETACTABLE;
            animator.SetLayerWeight(1, 1f);
            animator.Play("Hide", 1);
            if (audioSource != null)
            {
                audioSource.resource = audioResource;
                audioSource.Play();
            }
        }
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
