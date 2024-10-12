using System;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class ShooterController : Controller
{
    public ShooterController(Controller copyFrom) : base(copyFrom)
    {
    }

    public override void BindInput(InputAction move, InputAction fire)
    {
        throw new NotImplementedException();
    }

    public override Vector2 Bounce(IBounceable bounceable)
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}
