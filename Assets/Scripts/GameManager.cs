using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header ("Text Displays")]
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI difficultyText;
    [SerializeField] TextMeshProUGUI timerText;


    [Header ("Managers")]
    [SerializeField] private GhoulSpawner ghoulSpawner;
    [SerializeField] private TimeManager timeManager;


    [Header ("Sound Effects")]
    [SerializeField] private AudioClip gameOverSfx;
    [SerializeField] private float volume = 1f;
    private AudioSource audioSource;

    [Header ("Game Objects")]
    [SerializeField] private GameObject highScoreButton;
    [SerializeField] private GameObject inactiveBackground;

    private bool isGameActive = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        inactiveBackground.SetActive(true);  
        
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


