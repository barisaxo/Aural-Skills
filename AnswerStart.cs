using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerStart : MonoBehaviour
{                                     //Enable AnswerDiaOrCroma
    public GameObject toEnable;
    public int Wrong;

    private void Start()
    {
        Wrong = 0;
    }

    public void EnableButton()
    {
        Invoke("RunThis", .2f);
    }

    void RunThis()
    {
        toEnable.SetActive(true);
        GameObject.Find("__NMECadenceManager").GetComponent<NMECadence>().chordToAnswer = this.gameObject;
     }

    public void DisableImage()
    {
        Invoke("DisableStart", .6f);
    }

    void DisableStart()
    {
        GetComponent<Image>().enabled = false;
    }
}
