using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//RENAME THIS SCRIPT


public class SubmitAnswer : MonoBehaviour
{
    public GameObject chordToAnswer;
    public GameObject submitAnswer;

    public void AnswerSubmit()
    {
        var NME = chordToAnswer.GetComponent<NMECadence>();
        //if (NME.NMEfamily == submitAnswer.Family)
        //{
        //    NME.solvedFunction = true;
        //}
    }
}
