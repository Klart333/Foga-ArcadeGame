using UnityEngine;

public class Ball : PooledMonoBehaviour, IBounceable
{
    [SerializeField]
    private float movementSpeed;

    private Rigidbody2D rb;

    public Vector2 Velocity => rb.velocity;
    public Vector2 Position => rb.position;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetupVelocity()
    {
        Vector2 dir = -transform.position.normalized;
        rb.velocity = dir * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IBouncer bouncer))
        {
            rb.velocity = bouncer.Bounce(this) * 1.05f;
        }
    }
}

public interface IBounceable
{
    public Vector2 Velocity { get; }
    public Vector2 Position { get; }
}

public interface IBouncer
{
    public Vector2 Bounce(IBounceable bounceable);
}
