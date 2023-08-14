public class MaxScoreUI : ScoreUI {
    private void Awake()
    {
        HideScoreTemplate();
    }

    private void Start()
    {
        GameManager.Instance.OnGameOverTrigger += GameManager_OnGameOverTrigger;
    }

    private void GameManager_OnGameOverTrigger(object sender, System.EventArgs e)
    {
        int maxScore = ScoreManager.Instance.GetMaxScore();
        int score = ScoreManager.Instance.GetScore();
        if (score > maxScore) { maxScore = score; }
        SpawnScore(maxScore);
    }
}
