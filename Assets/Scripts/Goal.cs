using UnityEngine;

public class Goal : MonoBehaviour, IGoal
{
    [SerializeField]
    private bool isLeft;

    public void Hit(IBounceable bounceable)
    {
        ScoreManager.Instance.IncreaseScore(1, !isLeft);
        GameManager.Instance.ResetBall(bounceable, isLeft);
    }
}

public interface IGoal
{
    public void Hit(IBounceable bounceable);
}
