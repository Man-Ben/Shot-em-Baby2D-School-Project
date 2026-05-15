using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainUI : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject difficultyMenu;

    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button backButton;
    [SerializeField] Button easyButton;
    [SerializeField] Button normalButton;
    [SerializeField] Button hardButton;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public Difficulty difficulty {get; private set;}

    public static MainUI Instance {get; private set;}

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        AddListenerToButtons();
    }

    void AddListenerToButtons()
    {
        playButton.onClick.AddListener(OnPlayButtonPressed);
        quitButton.onClick.AddListener(OnQuitButtonPressed);
        backButton.onClick.AddListener(OnBackButtonPressed);
        easyButton.onClick.AddListener(() => OnDifficultyButtonPressed(Difficulty.Easy));
        normalButton.onClick.AddListener(() => OnDifficultyButtonPressed(Difficulty.Normal));
        hardButton.onClick.AddListener(() => OnDifficultyButtonPressed(Difficulty.Hard));
    }

    void OnPlayButtonPressed()
    {
        startMenu.SetActive(false);
        difficultyMenu.SetActive(true);
    }

    void OnQuitButtonPressed()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    void OnBackButtonPressed()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    void OnDifficultyButtonPressed(Difficulty difficultyParameter)
    {
        difficulty = difficultyParameter;

        SceneManager.LoadScene(1);
    }

}
