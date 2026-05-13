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

    int hpCount = 2;
    int score = 0;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        AddListenerToButtons();

        if(hpCount != 0)
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

    public void AddScore()
    {
        score += 20;

        scoreText.text = $"Score: {score}";
    }

    public void ReductScore()
    {
        score -= 20;

        scoreText.text = $"Score: {score}";
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

    void SetHealth()
    {
        for(int i = 0; i < 3; i++)
        {
            healthPoints[i].gameObject.SetActive(true);
        }
    }

    public void InactivateHealth()
    {
        if(hpCount == 0)
        {
            healthPoints[hpCount].gameObject.SetActive(false);

            GameOverMessage();

            gameState = GameState.GameOver;

            return;
        }

        healthPoints[hpCount].gameObject.SetActive(false);
        hpCount--;

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
