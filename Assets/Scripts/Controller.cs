using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public abstract class Controller
{
    [Header("Controller")]
    [SerializeField]
    protected PooledMonoBehaviour playerPrefab;

    [SerializeField]
    protected Vector2 spawnOffset;

    protected InputAction move;
    protected InputAction fire;

    protected PooledMonoBehaviour spawnedPlayer;

    public PooledMonoBehaviour SpawnedPlayer => spawnedPlayer;

    protected Controller(Controller copyFrom)
    {
        playerPrefab = copyFrom.playerPrefab;
        spawnOffset = copyFrom.spawnOffset;
    }

    public virtual void Setup(InputAction move, InputAction fire, bool mirrored)
    {
        this.move = move;
        this.fire = fire;

        BindInput(move, fire);
        SpawnPlayer(mirrored);
    }

    protected void SpawnPlayer(bool mirrored)
    {
        Vector2 pos = spawnOffset;
        if (mirrored)
        {
            pos.x *= -1;
        }
        Quaternion rot = Quaternion.identity;

        spawnedPlayer = playerPrefab.GetAtPosAndRot<PooledMonoBehaviour>(pos, rot);
        if (spawnedPlayer.TryGetComponent(out Paddle paddle))
        {
            paddle.Controller = this;
        }
    }

    public abstract void Update();
    public abstract void BindInput(InputAction move, InputAction fire);
    public abstract Vector2 Bounce(IBounceable bounceable);
}
