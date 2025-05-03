using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header ("Text Displays")]
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI difficultyText;
    [SerializeField] private TextMeshProUGUI timerText;

    [Header ("Managers")]
    [SerializeField] private GhoulSpawner ghoulSpawner;
    [SerializeField] private TimeManager timeManager;
    private HighScoreManager highScoreManager;


    [Header ("Sound Effects")]
    [SerializeField] private AudioClip gameOverSfx;
    [SerializeField] private float volume = 1f;
    private AudioSource audioSource;

    [Header ("Game Objects")]
    [SerializeField] private GameObject highScoreButton;
    [SerializeField] private GameObject inactiveBackground;

    private bool isGameActive = false;
    private GhoulStates states;

    void Awake()
    {
        states = GetComponent<GhoulStates>();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        highScoreManager = GetComponent<HighScoreManager>();
    }
    
    public bool IsGameActive
    {
        get{ return isGameActive; }
    }

    public void DisplayGameOver()
    {
        //show the gameOverText
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        timerText.gameObject.SetActive(false);

        PlayGameOverSfx(); //play the gameover sound
        highScoreButton.SetActive(true); 
        inactiveBackground.SetActive(true); //activate black background
        highScoreManager.CheckIfScoreQualifies();  //check for top5
    }

    public void RestartScene()
    {
         //reset the scene
        SceneManager.LoadScene
        (SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayGameOverSfx()
    {
        audioSource.PlayOneShot(gameOverSfx, volume);
    }

    public void StartGame(int ghoulSpawnsPerSec)
    {
        //set the game active and remove the black bg
        isGameActive = true;
        inactiveBackground.SetActive(false);   

        //set TimerText to active and start it
        timerText.gameObject.SetActive(true);
        timeManager.StartTimer();

        //hide difficulty text and hide the highscorebutton every start game
        difficultyText.gameObject.SetActive(false);
        highScoreButton.SetActive(false);

        //set ScoreText active
        scoreText.gameObject.SetActive(true);

        //Set spawnRate of spawner then start spawning
        ghoulSpawner.GhoulSpawnsPerSec = ghoulSpawnsPerSec;
        ghoulSpawner.StartSpawn();
    }
}


