using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerSub : MonoBehaviour
{
    public int Family, sc;
    GameObject CTA;

    private void Start()
    {
      
    }


    public void CheckAnswer()
    {
        CTA = GameObject.Find("__NMECadenceManager").GetComponent<NMECadence>( ).chordToAnswer;
        GameObject.Find("__CharacterStats").GetComponent<CharacterManager>().SaveGame();
        GameObject.Find("Score").GetComponent<KeepScore>().SaveTime();

        if (CTA.GetComponent<NMECadence>().NMEfamily == Family) // && GameObject.Find("__OptionsManager").GetComponent<Options>().difficulty == _ ;
        {
            CTA.GetComponent<NMECadence>().chordIsSolved = true;

            GameObject.Find("__NMECadenceManager").GetComponent<NMECadence>().SolveChord();

            GameObject.Find("Score").GetComponent<KeepScore>().myScore += 1000;
            return;
        }
        
        //update mistakes score
        GameObject.Find("__CharacterStats").GetComponent<CharacterManager>().Mistakes++;
        GameObject.Find("Errors").GetComponent<Text>().text ="Mistakes: " +
            GameObject.Find("__CharacterStats").GetComponent<CharacterManager>().Mistakes.ToString();


        //update wrong answers and score
        CTA.GetComponent<AnswerStart>().Wrong++;
        GameObject.Find("__NMECadenceManager").GetComponent<NMECadence>().wrongAnswer++;

        //if (CTA.GetComponent<AnswerStart>().Wrong == 1)
        //{
        //    CTA.GetComponentInChildren<Text>().color = new Color(0.8f, 0.52f, 0.16f, 1f);
        //    CTA.GetComponentInChildren<Text>().text = "?";
        //    GameObject.Find("Score").GetComponent<KeepScore>().myScore -= 500;
        //    return;
        //}

        if (CTA.GetComponent<AnswerStart>().Wrong == 1)
        {
            CTA.GetComponentInChildren<Text>().color = new Color(0.8f, 0.52f, 0.16f, 1f);
            CTA.GetComponentInChildren<Text>().text = "!";
            GameObject.Find("Score").GetComponent<KeepScore>().myScore -= 2500;
            return;
        }
        if (CTA.GetComponent<AnswerStart>().Wrong == 2 || GameObject.Find("__NMECadenceManager").GetComponent<NMECadence>().wrongAnswer == 3)
        {
            GameObject.Find("Score").GetComponent<KeepScore>().myScore -= 10000;

            GameObject.Find("__CharacterStats").GetComponent<CharacterManager>().FailedCadences++;
            GameObject.Find("Failed").GetComponent<Text>().text = "Failed: " +
                GameObject.Find("__CharacterStats").GetComponent<CharacterManager>().FailedCadences.ToString();

            for (int i = 1; i <= 4; i++)
            {
                CTA = GameObject.Find("Chord" + i);
                GameObject.Find("__NMECadenceManager").GetComponent<NMECadence>().chordToAnswer = CTA;
                if (CTA.GetComponent<NMECadence>().chordIsSolved != true)
                {
                    CTA.GetComponentInChildren<Text>().color = new Color(0.8f, 0.22f, 0.35f, 1f);
                    GameObject.Find("__NMECadenceManager").GetComponent<NMECadence>().SolveChord();
                }
            }
            GameObject.Find("__MusicManager").GetComponent<MusicManager>().SolvedCadence();
        }
    }
}
