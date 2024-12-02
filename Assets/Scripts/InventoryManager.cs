using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject robotSlime;
    public GameObject stealthSlime;
    private bool isStealthSlimeActive = true;

    public void SwitchSlime(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isStealthSlimeActive = !isStealthSlimeActive;
            stealthSlime.SetActive(isStealthSlimeActive);
            robotSlime.SetActive(!isStealthSlimeActive);
        }
    }
}
