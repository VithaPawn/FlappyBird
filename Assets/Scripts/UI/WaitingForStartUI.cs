using UnityEngine;

public class WaitingForStartUI : MonoBehaviour {
    [SerializeField] private Transform messageImage;

    private void Awake()
    {
        Show();
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsWaittingForStart())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        messageImage.gameObject.SetActive(true);
    }

    private void Hide()
    {
        messageImage.gameObject.SetActive(false);
    }
}
