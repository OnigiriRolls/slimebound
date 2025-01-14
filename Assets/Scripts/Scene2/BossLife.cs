using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossLife : MonoBehaviour
{
    public GameObject monstersSpawner;
    public GameObject menu;
    public GameObject restartButton;
    public TextMeshProUGUI text;
    public Rigidbody2D player;
    public float damage = 0.2f;
    [SerializeField] private Slider healthSlider;
    private DeactivateAndActivateGameObjects deactivateAndActivateGameObjects;

    void Start()
    {
        healthSlider.value = 0;
        deactivateAndActivateGameObjects = GetComponent<DeactivateAndActivateGameObjects>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.SIMPLE_LASER) && healthSlider.gameObject.activeInHierarchy)
        {
            healthSlider.value += damage;

            if (healthSlider.value >= 1)
            {
                healthSlider.gameObject.SetActive(false);
                monstersSpawner.SetActive(false);
                player.constraints = RigidbodyConstraints2D.FreezeAll;
                Destroy(collision.gameObject);
                restartButton.SetActive(false);
                text.SetText(GlobalConstants.MESSAGE_WIN);
                deactivateAndActivateGameObjects.ActivateAndDeactivate();
                menu.SetActive(true);
                gameObject.SetActive(false);
            }
            Destroy(collision.gameObject);
        }
    }
}
