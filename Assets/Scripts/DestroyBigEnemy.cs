using UnityEngine;

public class DestroyBigEnemy : MonoBehaviour
{
    //public Animator cell;
    //public GameObject slimes;
    //public GameObject enemy;
    //public GameObject inventory;
    //[SerializeField] private Slider healthSlider;

    void Start()
    {
        //healthSlider.value = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.PLAYER))
        {
            Debug.Log("player");
            //healthSlider.value += 0.2f;

            //if (healthSlider.value >= 1)
            //{
            //    Debug.Log("cell destroyed");
            //    healthSlider.gameObject.SetActive(false);
            //    enemy.SetActive(false);
            //    cell.SetBool(GlobalConstants.ANIM_COND_DESTROY, true);
            //}
        }
    }
}
