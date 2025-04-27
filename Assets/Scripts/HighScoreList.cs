using System;
using System.Collections.Generic;
using System.Linq;

public class HighScoreList
{
    private List<HighScore> highScores = new List<HighScore>();

    public void AddHighScore(string name, string score)
    {
        HighScore highScore = new HighScore(name, Int32.Parse(score));
        highScores.Add(highScore);
    }

    public void PopulateList(string names, string scores)
    {
        string[] namesArray =  names.Split(";");    
        string[] scoresArray =  scores.Split(";");    

        for (int i = 0; i < namesArray.Length-1; i++)
        {
            AddHighScore(namesArray[i],scoresArray[i]);
        }
    }

    public override string ToString()
    {
        string output = "";
        highScores.OrderBy(x => x.Score).ToList();
        highScores.Reverse();

        foreach (HighScore highScore in highScores)
        {
            output += highScore.Name + "\t" + highScore.Score + "\n";
        }
        return output;
    }
}
class HighScore
{
    private string name;
    private int score;

    public string Name
    {
        get { return name; }
    }

    public int Score
    {
        get { return score; }
    }

    public HighScore(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}