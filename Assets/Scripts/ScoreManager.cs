using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [Header("Score")]
    [SerializeField]
    private int partialForScore;

    public int LeftScore {  get; set; }
    public int RightScore {  get; set; }

    public int LeftPartial { get; set; }
    public int RightPartial { get; set; }

    public void IncreaseScore(int score, bool left)
    {
        if (left)
        {
            LeftScore += score;
        }
        else
        {
            RightScore += score;
        }
    }

    public void IncreasePartial(int score, bool left)
    {
        if (left)
        {
            LeftPartial += score;
            if (LeftPartial >= partialForScore) 
            {
                LeftPartial -= partialForScore;
                LeftScore++;
            }
        }
        else
        {
            RightPartial += score;
            if (RightPartial >= partialForScore)
            {
                RightPartial -= partialForScore;
                RightPartial++;
            }
        }
    }
}
