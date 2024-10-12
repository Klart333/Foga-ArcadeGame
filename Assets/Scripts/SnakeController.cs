using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class SnakeController : Controller
{
    public SnakeController(Controller copyFrom) : base(copyFrom)
    {
    }

    public override void BindInput(InputAction move, InputAction fire)
    {
        throw new System.NotImplementedException();
    }

    public override Vector2 Bounce(IBounceable bounceable)
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
