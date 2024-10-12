using UnityEngine;

public class Paddle : MonoBehaviour, IBouncer
{
    public Controller Controller {  get; set; }

    public Vector2 Bounce(IBounceable bounceable)
    {
        return Controller.Bounce(bounceable);
    }
}
