using UnityEngine;

public class GlobalConstants : MonoBehaviour
{
    public static readonly string PLAYER_UNDETACTABLE = "Player Undetactable";
    public static readonly string PLAYER_FLYING = "Player Flying";
    public static readonly string PLAYER = "Player";

    public static readonly string BIG_ENEMY = "Big Enemy";
    public static readonly string MINION = "Minion";

    public static readonly string LASER_BEAM = "Laser Beam";
    public static readonly string SIMPLE_LASER = "Simple Laser";

    public static readonly string ANIM_COND_SCAN = "scan";
    public static readonly string ANIM_COND_OPEN = "open";
    public static readonly string ANIM_COND_DESTROY = "destroy";

    public static readonly string MESSAGE_NO_SWITCH_NOW = "Can't switch now!";
    public static readonly string MESSAGE_WIN = "WIN";
    public static readonly string MESSAGE_GAME_OVER = "GAME OVER";
    public static readonly string MESSAGE_STEALTH_ABILITY = "Press SPACE to use ability";
    public static readonly string MESSAGE_SWITCH_ABILITY = "Press E to switch slime";

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
