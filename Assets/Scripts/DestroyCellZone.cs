using UnityEngine;
using UnityEngine.UI;

public class DestroyCellZone : MonoBehaviour
{
    public Animator cell;
    public GameObject slimes;
    public GameObject enemy;
    public GameObject inventory;
    [SerializeField] private Slider healthSlider;

    void Start()
    {
       healthSlider.value = 0;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.LASER_BEAM))
        {
            healthSlider.value += 0.2f;

            if (healthSlider.value >= 1)
            {
                Debug.Log("cell destroyed");
                healthSlider.gameObject.SetActive(false);
                enemy.SetActive(false);
                cell.SetBool(GlobalConstants.ANIM_COND_DESTROY, true);
            }
        }
    }
}
