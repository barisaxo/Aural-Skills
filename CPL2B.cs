using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPL2B : MonoBehaviour
{
    public GameObject toEnable;
    public GameObject toDisable;
    public void EnableCPlvl2()
    {
        Invoke("RunThis", .2f);
    }

    void RunThis()
    {
        toEnable.SetActive(true);
        toDisable.SetActive(false);
    }
}
