using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private bool isGameOver = false;
    [SerializeField] private GhoulSpawner ghoulSpawner;
    [SerializeField] private GameManager gameManager;
 
    void Update()
    {
        if (gameManager.IsGameActive)
        {
            StartTimer();
        }
    }

    public void StartTimer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0)
            {
                remainingTime = 0;
            }

        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("TIME: {0}:{1:00}", minutes, seconds);

        if (remainingTime <= 0 && !isGameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        GameObject.Find("GameManager")
            .GetComponent<GameManager>()
            .DisplayGameOver();
        
    }
}
