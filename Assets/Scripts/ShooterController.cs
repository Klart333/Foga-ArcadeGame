using UnityEngine;

public class ShooterController : Controller
{
    public override void Setup(object inputs, bool mirrored)
    {

    }
}

public abstract class Controller
{
    [Header("Controller")]
    [SerializeField]
    protected PooledMonoBehaviour playerPrefab;

    [SerializeField]
    protected Vector2 spawnOffset;

    protected PooledMonoBehaviour spawnedPlayer;

    public virtual void Setup(object inputs, bool mirrored)
    {
        Vector2 pos = spawnOffset;
        if (mirrored)
        {
            pos.x *= -1;
        }
        Quaternion rot = Quaternion.identity;

        spawnedPlayer = playerPrefab.GetAtPosAndRot<PooledMonoBehaviour>(pos, rot);
    }
}
