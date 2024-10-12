using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class PongController : Controller
{
    [Header("Movement")]
    [SerializeField]
    private float movementSpeed = 1;

    [SerializeField]
    private float acceleration = 1;

    [SerializeField]
    private float maxSpeed = 1.25f;

    private float extraSpeed = 1;

    public PongController(Controller copyFrom) : base(copyFrom)
    {
        if (copyFrom is PongController pongCopy)
        {
            movementSpeed = pongCopy.movementSpeed;
            acceleration = pongCopy.acceleration;
            maxSpeed = pongCopy.maxSpeed;
        }
    }

    public override void BindInput(InputAction move, InputAction fire)
    {
    }

    public override Vector2 Bounce(IBounceable bounceable)
    {
        Vector2 normal = new Vector2(Mathf.Sign(SpawnedPlayer.transform.position.x), move.ReadValue<Vector2>().y * 0.1f);
        return Vector2.Reflect(bounceable.Velocity, normal);
    }

    public override void Setup(InputAction move, InputAction fire, bool mirrored)
    {
        base.Setup(move, fire, mirrored);
    }

    public override void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = move.ReadValue<Vector2>();
        if (Mathf.Abs(movement.y) - 0.1f <= 0)
        {
            extraSpeed = 1;
            return;
        }

        movement.x = 0;
        movement *= Time.deltaTime * movementSpeed * extraSpeed;
        spawnedPlayer.transform.Translate(movement);

        float blend = Mathf.Pow(0.5f, Time.deltaTime * acceleration);
        extraSpeed = Mathf.Lerp(maxSpeed, extraSpeed, blend);
    }
}
