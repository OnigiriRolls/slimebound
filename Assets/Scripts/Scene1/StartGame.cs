using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Animator enemyAnim;
    public GameObject enemyScanLight;
    public GameObject transitionPanel;

    void Update()
    {
        if(!transitionPanel.activeInHierarchy)
        {
            enemyScanLight.SetActive(true);
            enemyAnim.SetBool(GlobalConstants.ANIM_COND_SCAN, true);
            enabled = false;
        }
    }
}
