using UnityEngine;
using UnityEngine.Audio;

public class PlayerHealth2 : MonoBehaviour
{
    public GameObject playerLifeManagerObject;
    private PlayerLifeManager2 playerLifeManager;
    private AudioSource audioSource;

    void Start()
    {
        playerLifeManager = playerLifeManagerObject.GetComponent<PlayerLifeManager2>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.MINION) ||
            collision.CompareTag(GlobalConstants.LASER_BEAM) ||
            collision.CompareTag(GlobalConstants.MONSTER) ||
            collision.CompareTag(GlobalConstants.BIG_ENEMY ))
        {
            audioSource.Play();
            playerLifeManager.LoseLife();
            if (!collision.CompareTag(GlobalConstants.MINION) && !collision.CompareTag(GlobalConstants.BIG_ENEMY))
                Destroy(collision.gameObject);
        }
    }
}
