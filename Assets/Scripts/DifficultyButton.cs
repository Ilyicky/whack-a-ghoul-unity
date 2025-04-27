using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] int ghoulSpawnsPerSec = 1;
    [SerializeField] private GameManager gameManager;

    private Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    private void SetDifficulty()
    {
        //gameManager to start the game
        gameManager.StartGame(ghoulSpawnsPerSec);
    }
}
