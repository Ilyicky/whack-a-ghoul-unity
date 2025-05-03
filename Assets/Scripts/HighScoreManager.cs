using TMPro;
using UnityEngine;
using System;

public class HighScoreManager : MonoBehaviour
{
    [Header("Display")]
    [SerializeField] private TextMeshProUGUI highScoreName;
    [SerializeField] private TextMeshProUGUI highScoreScore;
    [SerializeField] private TextMeshProUGUI highScoreListName;
    [SerializeField] private TextMeshProUGUI highScoreListScore;

    [Header("Panels")]
    [SerializeField] private GameObject highScorePanel;
    [SerializeField] private GameObject saveBoxPanel;

    private HighScoreList highScoreList;

    void Start()
    {
        highScoreList = new HighScoreList();
        LoadHighScores();
    }

    public void ShowHighScores()
    {
        highScorePanel.SetActive(true);

        var topScores = highScoreList.GetTopHighScores();

        string names = "";
        string scores = "";

        foreach (var hs in topScores)
        {
            names += hs.Name + "\n";
            scores += hs.Score.ToString() + "\n";
        }

        highScoreListName.text = names;
        highScoreListScore.text = scores;
    }


    public void CloseHighScores()
    {
        highScorePanel.SetActive(false);
    }

    public void CheckIfScoreQualifies()
    {
        string scoreText = GetHighScoreScore();

        if (string.IsNullOrEmpty(scoreText))
        {
            Debug.Log("Score text is empty or null.");
            return;
        }
        
        int parsedScore;
        if (int.TryParse(scoreText, out parsedScore))
        {
            Debug.Log("Parsed score: " + parsedScore);

            if (highScoreList.IsScoreInTop5(parsedScore))
            {
                Debug.Log("Score qualifies for top 5. Showing save box.");
                saveBoxPanel.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Score does not qualify for top 5. Hiding save box.");
                saveBoxPanel.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("Failed to parse score text into an integer.");
        }
    }

    public void SaveHighScore()
    {
        string name = GetHighScoreName();
        string score = GetHighScoreScore();

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(score)) return;

        int parsedScore = Int32.Parse(score);

        if (highScoreList.IsScoreInTop5(parsedScore))
        {
            highScoreList.AddHighScore(name, score);
            SaveHighScoresToPlayerPrefs();

            //update the display after saving
            var topScores = highScoreList.GetTopHighScores();
            string names = "Name\n";
            string scores = "Score\n";

            foreach (var hs in topScores)
            {
                names += hs.Name + "\n";
                scores += hs.Score.ToString() + "\n";
            }

            highScoreListName.text = names;
            highScoreListScore.text = scores;
        }
        else
        {
            Debug.Log("Score not in top 5, not saved.");
        }
    }


    private void SaveHighScoresToPlayerPrefs()
    {
        string names = "";
        string scores = "";

        foreach (var highScore in highScoreList.GetTopHighScores())
        {
            names += highScore.Name + ";";
            scores += highScore.Score + ";";
        }

        PlayerPrefs.SetString("Names", names);
        PlayerPrefs.SetString("Scores", scores);
        PlayerPrefs.Save();
    }

    private string GetHighScoreName()
    {
        return highScoreName.text;
    }

    private string GetHighScoreScore()
    {
        string output = highScoreScore.text;
        output = output.Replace("SCORE: ", "");
        return output;
    }

    private void LoadHighScores()
    {
        string names = PlayerPrefs.GetString("Names");
        string scores = PlayerPrefs.GetString("Scores");
        highScoreList.PopulateList(names, scores);
    }
}
