using System;
using System.Collections.Generic;
using System.Linq;

public class HighScoreList
{
    public class HighScore
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public HighScore(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
    private List<HighScore> highScores = new List<HighScore>();

    public void AddHighScore(string name, string score)
    {
        if (Int32.TryParse(score, out int parsedScore) && !string.IsNullOrEmpty(name))
        {
            HighScore highScore = new HighScore(name, parsedScore);
            highScores.Add(highScore);

            //sort and keep only the top 5 scores
            highScores = highScores.OrderByDescending(x => x.Score).Take(5).ToList();
        }
    }

    //populate the high score list from PlayerPrefs
    public void PopulateList(string names, string scores)
    {
        string[] namesArray = names.Split(";");
        string[] scoresArray = scores.Split(";");

        highScores.Clear();

        for (int i = 0; i < namesArray.Length - 1; i++)
        {
            AddHighScore(namesArray[i], scoresArray[i]);
        }
    }

    public bool IsScoreInTop5(int score)
    {
        return highScores.Count < 5 || score > highScores.Last().Score;
    }

    public List<HighScore> GetTopHighScores()
    {
        return highScores.OrderByDescending(x => x.Score).Take(5).ToList();
    }

    //convert to string for output
    // public override string ToString()
    // {
    //     string output = "Top 5 High Scores\n";
    //     output += "--------------------------\n";  // Add a separator line for clarity

    //     // Format header for name and score
    //     output += string.Format("{0,-20} {1,10}\n", "Name", "Score");
    //     output += "--------------------------\n";  // Another separator

    //     foreach (HighScore highScore in highScores)
    //     {
    //         // Ensure that both name and score are aligned nicely
    //         output += string.Format("{0,-20} {1,10}\n", highScore.Name, highScore.Score);
    //     }

    //     return output;
    // }
}
