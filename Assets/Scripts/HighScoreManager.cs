using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreName;
    [SerializeField] private TextMeshProUGUI highScoreScore;

    [Header ("Display")]
    [SerializeField] private GameObject highScorePanel;
    [SerializeField] private TextMeshProUGUI highScoreListDisplay;

    private  HighScoreList highScoreList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreList = new HighScoreList();
        LoadHighScores();
    }

    // Update is called once per frame
    public void ShowHighScores()
    {
        highScorePanel.SetActive(true);
        highScoreListDisplay.text = highScoreList.ToString();    
    }

    public void CloseHighScores()
    {
        highScorePanel.SetActive(false);
    }

    public void SaveHighScore()
    {
        //get high score name and score
        string name = GetHighScoreName();
        string score = GetHighScoreScore();
        string names = PlayerPrefs.GetString("Names");
        string scores = PlayerPrefs.GetString("Scores");

        names += name + ";";
        scores += score + ";";

        PlayerPrefs.SetString("Names", names);
        PlayerPrefs.SetString("Scores", scores);
        PlayerPrefs.Save();

        highScoreList.AddHighScore(name, score);

        Debug.Log("DEBUG name: "+name+" score: "+score);
        Debug.Log("DEBUG names: "+names );        
        Debug.Log("DEBUG scores: "+scores );


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

        highScoreList.PopulateList(names,scores);
    }
}
