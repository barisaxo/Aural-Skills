using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour
{
   public int myScore, timePlayed, secondsPlayed, minutePlayed, hoursPlayed;
   
    Text scoreText, timeText;

    private void Start()
    {
      //  myScore = GameObject.Find("__CharacterStats").GetComponent<CharacterManager>().Score;
        scoreText = GameObject.Find("Score").GetComponent<Text>();

        timePlayed = GameObject.Find("__CharacterStats").GetComponent<CharacterManager>().playTime;
        timeText = GameObject.Find("TimePlayed").GetComponent<Text>();

        hoursPlayed = PlayerPrefs.GetInt("Hours Played", 0);
        minutePlayed = PlayerPrefs.GetInt("Minutes Played", 0);
        secondsPlayed = PlayerPrefs.GetInt("Seconds Played", 0);
        myScore = PlayerPrefs.GetInt("My Score", 0);
        scoreText.text = "Score: " + myScore.ToString();
    }
    void FixedUpdate()
    {
        myScore--;
        scoreText.text = "Score: " + myScore.ToString();
        timePlayed++;
        if (timePlayed == 50)
        {
            secondsPlayed++;
            timePlayed = 0;
            if (secondsPlayed == 60)
            { minutePlayed++;
                secondsPlayed = 0;
            }
            if (minutePlayed == 60)
            { hoursPlayed++;
                minutePlayed = 0;
            }
        }
        TimePlay();
    }

    void TimePlay()
    {
        timeText.text = "Time Played: " + hoursPlayed.ToString() + ":" + minutePlayed.ToString() + ":" + secondsPlayed.ToString() + "." + (timePlayed).ToString();
    }

    public void SaveTime()
    {
        PlayerPrefs.SetInt("Hours Played", hoursPlayed);
        PlayerPrefs.SetInt("Minutes Played", minutePlayed);
        PlayerPrefs.SetInt("Seconds Played", secondsPlayed);
        PlayerPrefs.SetInt("My Score", myScore);
    }
}
