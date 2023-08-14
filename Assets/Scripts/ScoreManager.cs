using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    private const string MAX_SCORE = "maxScore";

    public static ScoreManager Instance { get; private set; }

    private int score;
    private int maxScore;

    public event EventHandler OnScoreIncreased;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one ScoreManager Instance at the same time!");
        }
        else
        {
            Instance = this;
        }
        maxScore = PlayerPrefs.GetInt(MAX_SCORE);
    }

    private void Start()
    {
        GameManager.Instance.OnGameOverTrigger += GameManager_OnGameOverTrigger;
    }

    private void GameManager_OnGameOverTrigger(object sender, EventArgs e)
    {
        if (maxScore < score)
        {
            maxScore = score;
            PlayerPrefs.SetInt(MAX_SCORE, maxScore);
            PlayerPrefs.Save();
        }
    }

    public void IncreaseScore()
    {
        score++;
        OnScoreIncreased?.Invoke(this, EventArgs.Empty);
    }

    public int GetScore()
    {
        return score;
    }

    public int GetMaxScore()
    {
        return maxScore;
    }
}
