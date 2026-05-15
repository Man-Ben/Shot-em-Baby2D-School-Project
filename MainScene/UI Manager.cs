using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject pausedMenu;

    [SerializeField] Button quitButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button continueButton;

    [SerializeField] TextMeshProUGUI scoreText;

    public List<Image> healthPoints;

    public enum GameState
    {
        Neutral,
        Paused,
        GameOver
    }

    public GameState gameState {get; private set;}
    public static UIManager Instance {get; private set;}

    int remainingHP;
    int totalHP;
    int score = 0;
    int scoreToAdd;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        AddListenerToButtons();
        SetDifficulty();

        if(remainingHP != 0)
            SetHealth();
    }

    void Update()
    {
        OnEscPressed();

        if(score == -100)
            GameOverMessage();
    }

    void AddListenerToButtons()
    {
        quitButton.onClick.AddListener(OnQuitButtonPressed);
        continueButton.onClick.AddListener(OnContinueButtonPressed);
        restartButton.onClick.AddListener(OnRestartButtonPressed);
    }

    void SetDifficulty()
    {
        switch(MainUI.Instance.difficulty)
        {
            case MainUI.Difficulty.Easy:
            totalHP = 3;
            scoreToAdd = 20;
            break;

            case MainUI.Difficulty.Normal:
            totalHP = 2;
            scoreToAdd = 10;
            break;

            case MainUI.Difficulty.Hard:
            totalHP = 1;
            scoreToAdd = 5;
            break;
        }

        remainingHP = totalHP - 1;
    }

    public void AddScore()
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    public void ReductScore()
    {
        score -= 20;

        scoreText.text = $"Score: {score}";
    }

    void SetHealth()
    {           
        for(int i = 0; i < totalHP; i++)
        {
            healthPoints[i].gameObject.SetActive(true);
        }
    }

    public void InactivateHealth()
    {
        healthPoints[remainingHP].gameObject.SetActive(false);
        remainingHP--;

        if(remainingHP == -1)
        {

            GameOverMessage();

            gameState = GameState.GameOver;

            return;
        }
    }


    void GameOverMessage()
        {
            gameOverMenu.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }

        void OnEscPressed()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                gameState = GameState.Paused;

                pausedMenu.SetActive(true);
                quitButton.gameObject.SetActive(true);
            }
        }



    void OnContinueButtonPressed()
    {
        pausedMenu.SetActive(false);
        quitButton.gameObject.SetActive(false);

        gameState = GameState.Neutral;
    }

    void OnQuitButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    void OnRestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
