public class CurrentScoreUI : ScoreUI {

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
        int score = ScoreManager.Instance.GetScore();
        SpawnScore(score);
    }
}
