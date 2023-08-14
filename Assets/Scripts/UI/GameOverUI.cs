using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {
    [SerializeField] private Button playButton;
    [SerializeField] private List<Transform> childrenTransform;

    private void Awake()
    {
        Hide();
    }

    private void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            GameManager.Instance.RestartGame();
        });
        GameManager.Instance.OnGameOverTrigger += GameManager_OnGameOverTrigger;
    }

    private void GameManager_OnGameOverTrigger(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        foreach (Transform child in childrenTransform)
        {
            child.gameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (Transform child in childrenTransform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
