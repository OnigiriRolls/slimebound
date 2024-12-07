using UnityEngine;
using UnityEngine.UI;

public class DestroyCellZone : MonoBehaviour
{
    public Animator cell;
    public GameObject slimes;
    public GameObject enemy;
    public GameObject inventory;
    public GameObject minionSpawner;
    public Rigidbody2D player;
    [SerializeField] private Slider healthSlider;

    void Start()
    {
       healthSlider.value = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.LASER_BEAM))
        {
            healthSlider.value += 0.2f;

            if (healthSlider.value >= 1)
            {
                healthSlider.gameObject.SetActive(false);
                minionSpawner.SetActive(false);
                enemy.SetActive(false);
                cell.SetBool(GlobalConstants.ANIM_COND_DESTROY, true);
                player.constraints = RigidbodyConstraints2D.FreezeAll;
                Destroy(collision.gameObject);
                gameObject.SetActive(false);
            }
            Destroy(collision.gameObject);
        }
    }
}
