using System;
using UnityEngine;

public class Bird : MonoBehaviour {

    public static Bird Instance { get; private set; }

    private Rigidbody2D birdRigidbody;
    [SerializeField]
    private float jumpForce = 17f;

    public event EventHandler OnJump;
    public event EventHandler OnGetScore;
    public event EventHandler OnCollide;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Bird Instance!");
        }
        else
        {
            Instance = this;
        }

        birdRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.Instance.IsGamePlaying())
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                HandleMoving();
                OnJump?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private void HandleMoving()
    {
        birdRigidbody.velocity = Vector2.up * jumpForce;
    }

    private void OnTriggerEnter2D()
    {
        OnGetScore?.Invoke(this, EventArgs.Empty);
        ScoreManager.Instance.IncreaseScore();
    }

    private void OnCollisionEnter2D()
    {
        OnCollide?.Invoke(this, EventArgs.Empty);
        GameManager.Instance.SetGameOver();

    }
}
