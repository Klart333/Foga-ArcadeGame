using UnityEngine;

public class Wall : MonoBehaviour, IBouncer
{
    private Vector2 normal;

    private void Start()
    {
        normal = new Vector2(0, Mathf.Sign(transform.position.y));
    }

    public Vector2 Bounce(IBounceable bounceable)
    {
        return Vector2.Reflect(bounceable.Velocity, normal);
    }
}
