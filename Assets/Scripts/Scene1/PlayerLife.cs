using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerLife : MonoBehaviour
{
    public GameObject playerLifeManagerObject;
    public AudioResource audioResource;
    private PlayerLifeManager playerLifeManager;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerLifeManager = playerLifeManagerObject.GetComponent<PlayerLifeManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GlobalConstants.MINION) ||
            collision.CompareTag(GlobalConstants.LASER_BEAM))
        {
            if (!CompareTag(GlobalConstants.PLAYER_UNDETACTABLE) && rb.constraints == RigidbodyConstraints2D.FreezeRotation)
            {
                audioSource.resource = audioResource;
                audioSource.Play();
                playerLifeManager.LoseLife();
            }
            Destroy(collision.gameObject);
        }
    }
}
