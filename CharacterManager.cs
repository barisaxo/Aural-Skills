using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public int SolvedCadences, Mistakes, FailedCadences, Score;
    public int wrongI, wrongII, wrongIII, wrongIV, wrongV, wrongVI, wrongVII;
    public int wrongbII, wrongbIII, wrongbV, wrongbVI, wrongbVII;
    public int wrongMaj, wrongMin, wrongDom, wrongSus, wrong7Sus;
    public int wrongTonicMin, wrongAlt, wrong7sharp11, wrongDim, wrongMin7b5;

    public int avgScore, highScore, lowScore, favoriteCadence, hardestCadence, playTime;

    private void Start()
    {
      SolvedCadences =  PlayerPrefs.GetInt("Solved Cadences", 0);
        Mistakes = PlayerPrefs.GetInt("Mistakes", 0);
       FailedCadences = PlayerPrefs.GetInt("Failed Cadences", 0);
       Score = PlayerPrefs.GetInt("Score", 0);

        GameObject.Find("Failed").GetComponent<Text>().text = "Failed: " + FailedCadences.ToString();

        GameObject.Find("Errors").GetComponent<Text>().text = "Mistakes: " + Mistakes.ToString();

        GameObject.Find("Solved").GetComponent<Text>().text = "Solved: " + SolvedCadences.ToString();

        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + Score;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Solved Cadences", SolvedCadences);
        PlayerPrefs.SetInt("Mistakes", Mistakes);
        PlayerPrefs.SetInt("Failed Cadences", FailedCadences);
        PlayerPrefs.SetInt("Score", GameObject.Find("Score").GetComponent<KeepScore>().myScore);
    }
}
