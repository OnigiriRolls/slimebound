using UnityEngine;

public class GlobalConstants : MonoBehaviour
{
    public static readonly string PLAYER_UNDETACTABLE = "Player Undetactable";
    public static readonly string PLAYER_FOUND = "Player Found";
    public static readonly string PLAYER = "Player";

    public static readonly string BIG_ENEMY = "Big Enemy";

    public static readonly string LASER_BEAM = "Laser Beam";
    public static readonly string SIMPLE_LASER = "Simple Laser";

    public static readonly string ANIM_COND_SCAN = "scan";
    public static readonly string ANIM_COND_OPEN = "open";
    public static readonly string ANIM_COND_DESTROY = "destroy";

    public static GlobalConstants Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
