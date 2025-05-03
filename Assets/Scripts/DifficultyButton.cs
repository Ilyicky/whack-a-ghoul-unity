using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] int ghoulSpawnsPerSec = 1;
    [SerializeField] private GameManager gameManager;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        //gameManager to start the game
        gameManager.StartGame(ghoulSpawnsPerSec);
    }
}
