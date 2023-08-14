public class ScoreWhilePlayingUI : ScoreUI {

    private void Awake()
    {
        HideScoreTemplate();
    }

    private void Start()
    {
        ScoreManager.Instance.OnScoreIncreased += ScoreManager_OnScoreIncreased;
        GameManager.Instance.OnGameOverTrigger += GameManager_OnGameOverTrigger;
        SpawnScore(0);
    }

    private void GameManager_OnGameOverTrigger(object sender, System.EventArgs e)
    {
        gameObject.SetActive(false);
    }

    private void ScoreManager_OnScoreIncreased(object sender, System.EventArgs e)
    {
        int score = ScoreManager.Instance.GetScore();
        SpawnScore(score);
    }

}
