using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    private const string SAMPLE_SCENE = "SampleScene";
    public enum State {
        WaitingForStart,
        GamePlaying,
        GameOver
    }

    private State state;
    public event EventHandler OnStateChanged;
    public event EventHandler OnGameOverTrigger;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one GameManager Instance at the same time!");
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        state = State.WaitingForStart;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingForStart:
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                Time.timeScale = 1f;
                break;
            case State.GameOver:
                Time.timeScale = 0f;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    RestartGame();
                }
                break;
        }
    }

    public State GetState() { return state; }

    public void SetState(State state) { this.state = state; }

    public bool IsWaittingForStart()
    {
        return state == State.WaitingForStart;
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public void SetGameOver()
    {
        state = State.GameOver;
        OnGameOverTrigger?.Invoke(this, EventArgs.Empty);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SAMPLE_SCENE.ToString());
    }
}
