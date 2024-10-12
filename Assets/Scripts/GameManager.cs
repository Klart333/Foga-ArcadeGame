using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Settings")]
    [SerializeField]
    private GameSettings[] gameSettings;

    [Header("Controllers")]
    [SerializeField]
    private PongController pongController;

    [SerializeField]
    private ShooterController shooterController;

    [SerializeField]
    private SnakeController snakeController;

    private List<Controller> currentControllers = new List<Controller>();

    public Controller RightController => currentControllers[0];
    public Controller LeftController => currentControllers[1];

    private InputActions inputActions;
    private InputAction leftMove;
    private InputAction leftFire;
    private InputAction rightFire;
    private InputAction rightMove;

    public bool IsPlaying { get; private set; }

    private void OnEnable()
    {
        inputActions = new InputActions();
        leftMove = inputActions.Player.LeftMove;
        leftMove.Enable();

        leftFire = inputActions.Player.LeftFire;
        leftFire.Enable();

        rightMove = inputActions.Player.RightMove;
        rightMove.Enable();

        rightFire = inputActions.Player.RightFire;
        rightFire.Enable();
    }

    private void OnDisable()
    {
        leftMove.Disable();
        leftFire.Disable();
        rightMove.Disable();
        rightFire.Disable();
    }

    private void Start()
    {
        SetupGame(gameSettings[0]);
    }

    private void Update()
    {
        if (IsPlaying)
        {
            for (int i = 0; i < currentControllers.Count; i++)
            {
                currentControllers[i].Update();
            }
        }
    }

    public void SetupGame(GameSettings gameSettings)
    {
        IsPlaying = true;
        currentControllers.Clear();

        SpawnGameMode(gameSettings.RightMode, false);
        SpawnGameMode(gameSettings.LeftMode, true);

        for (int i = 0; i < gameSettings.Balls.Count; i++)
        {
            Vector2 pos = UnityEngine.Random.insideUnitCircle * 2;
            pos.x += Mathf.Sign(pos.x) * 0.5f;
            pos.y *= 0.5f;
            Ball ball = gameSettings.Balls[i].GetAtPosAndRot<Ball>(pos, Quaternion.identity);
            ball.SetupVelocity();
        }
    }

    private void SpawnGameMode(GameMode gameMode, bool mirrored)
    {
        Controller controller = gameMode switch
        {
            GameMode.Pong => new PongController(pongController),
            GameMode.Snake => new SnakeController(snakeController),
            GameMode.Shooter => new ShooterController(shooterController),
            _ => throw new NotImplementedException(),
        };

        if (mirrored)
        {
            controller.Setup(leftMove, leftFire, mirrored);
        }
        else
        {
            controller.Setup(rightMove, rightFire, mirrored);
        }

        currentControllers.Add(controller);
    }

    internal void ResetBall(IBounceable bounceable, bool isLeft)
    {
        throw new NotImplementedException();
    }
}

public enum GameMode
{
    Pong,
    Snake,
    Shooter
}

[Serializable]
public class GameSettings
{
    public GameMode LeftMode;
    public GameMode RightMode;

    public List<Ball> Balls;
}
