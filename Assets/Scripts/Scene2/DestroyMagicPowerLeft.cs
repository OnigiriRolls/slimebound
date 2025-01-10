using UnityEngine;
using UnityEngine.UI;

public class DestroyMagicPowerLeft : MonoBehaviour
{
    public GameObject spawner;
    public GameObject slider;
    public GameObject barrier;
    public float damage = 0.1f;
    public Animator animator;
    [SerializeField] private Slider healthSlider;

    void Start()
    {
        healthSlider.value = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.SIMPLE_LASER) && healthSlider.IsActive())
        {
            healthSlider.value += damage;

            if (healthSlider.value >= 1)
            {
                healthSlider.gameObject.SetActive(false);
                if (slider != null)
                    slider.SetActive(true);
                barrier.SetActive(false);
                Destroy(collision.gameObject);
                animator.SetTrigger("attack");
                spawner.SetActive(true);
                gameObject.SetActive(false);
            }
            Destroy(collision.gameObject);
        }
    }
}
