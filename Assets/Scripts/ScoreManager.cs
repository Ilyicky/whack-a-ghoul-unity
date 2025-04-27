using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{

    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = "SCORE: " + this.score;
    }
}
