using UnityEngine;

public class PongController : MonoBehaviour, IController
{
    public void Setup()
    {

    }
}

public interface IController
{
    public void Setup();
}
