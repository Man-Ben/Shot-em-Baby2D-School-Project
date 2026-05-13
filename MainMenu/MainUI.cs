using UnityEngine;
using UnityEngine.UI;

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

        DontDestroyOnLoad(gameObject);

        AddListenerToButtons();
    }

    void AddListenerToButtons()
    {
        
    }

}
