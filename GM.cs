using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public GameObject chordFab, CTA, rootText, root, flatText, qualityText, bassText, bassFlatText, keyText,
        AC, wrongText, scoreText, failedText, solvedText, mm;
    public int wrong, solved, failed, score, wrongAnswers, noOfBars, correct;
    public bool menuSwitch, scoreSwitch;
    

    void Start()
    {
        mm = GameObject.Find("_MM");
        AC = GameObject.Find("_AnswerCodex");

        // Instantiate the chord blocks
        for (int i = 1; i <= 8; i++)
        {
            var parent = GameObject.Find("Bar" + i).transform;
            
            GameObject go = Instantiate(chordFab, parent);
            go.name = "Chord" + i + "A";

            GameObject og = Instantiate(chordFab, parent);
            og.transform.localPosition = new Vector2(150, 0);
            og.name = "Chord" + i +"B";
        }
    }

    // clear the selected CTA value in the _GM after you have finished answering
    public void ClearCTA()
    {
        if (CTA != null)
        {
            CTA.GetComponent<Image>().enabled = false;
            CTA = null;
            // cleares the whole chordblock
                RootCTA();
                rootText.GetComponent<Text>().text = "";
                FlatCTA();
                flatText.GetComponent<Text>().text = "";
                QualityCTA();
                qualityText.GetComponent<Text>().text = "";
                BassCTA();
                bassText.GetComponent<Text>().text = "";
                BassFlatCTA();
                bassFlatText.GetComponent<Text>().text = "";
            
        }
    }

    public void SetKeyInMenu()
    {
        string key = GameObject.Find("_AnswerCodex").GetComponent<AnswerCodexSub>().setkey;
        GameObject.Find("KEY").GetComponent<Text>().text = "Key: " + key;
    }

    public void RootCTA()
    { rootText = CTA.transform.GetChild(0).gameObject; }

    public void FlatCTA()
    { flatText = CTA.transform.GetChild(1).gameObject; }

    public void QualityCTA()
    { qualityText = CTA.transform.GetChild(2).gameObject; }

    public void BassCTA()
    { bassText = CTA.transform.GetChild(3).gameObject; }

    public void BassFlatCTA()
    { bassFlatText = CTA.transform.GetChild(4).gameObject; }

    public void MenuSwitch()
    {
        menuSwitch = !menuSwitch;
        if (menuSwitch == true)
        {
            scoreText = GameObject.Find("Score");
            wrongText = GameObject.Find("Mistakes");
            failedText = GameObject.Find("Failed");
            solvedText = GameObject.Find("Solved");
            UpdateFailed();
        }
        
    }

    private void FixedUpdate()
    {
        if (scoreSwitch == true)
        { score--; }

        if (menuSwitch == true)
        { scoreText.GetComponent<Text>().text = "Score: " + score.ToString(); }
    }

    public void UpdateFailed()
    {
        wrongText.GetComponent<Text>().text = "Mistakes: " + wrong.ToString();
        failedText.GetComponent<Text>().text = "Failed: " + failed.ToString();
        solvedText.GetComponent<Text>().text = "Solved: " + solved.ToString();
    }

    public void CheckAnswers()
    {
        correct = 0;
        noOfBars = AC.GetComponent<AnswerCodexSub>().noOfBars;

        for (int i = 1; i <= noOfBars; i++)
        {
            var ca = GameObject.Find("Chord" + i + "A").GetComponent<AnswerCodexSub>();
            var cb = GameObject.Find("Chord" + i + "B").GetComponent<AnswerCodexSub>();
          if (ca.rootSolved == true && ca.bassSolved == true && ca.qualitySolved == true)
            { correct++; }
          if (cb.rootSolved == true && cb.bassSolved == true && cb.qualitySolved == true)
            { correct++; }
        }

        if (correct >=13)
        {
            solved++;
            mm.GetComponent<MM>()._mus.Stop();
            score += 5000;
            scoreSwitch = false;
            UpdateFailed();

        }

        if (correct <13)
        {
            mm.GetComponent<MM>()._mus.Stop();
            failed++;
            score -= 5000;
            scoreSwitch = false;
            UpdateFailed();
        }
    }


}
