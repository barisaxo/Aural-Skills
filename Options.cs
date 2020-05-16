using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{

    public int chordSolmization, difficulty;
    public bool requireQuality, confirmAnswer;

    // Start is called before the first frame update
    void Start()
    {
        requireQuality = false;
    }
}

/* chord solmization: Roman Numerals, Solfege(fixed), Solfege(moveable), Anglicized, Scale Degree
 *              Solfege Fixed = Do, Re, Mi, Fa, Sol, La, Si, Do.
 *              Solfege Movable = Do, Re, Mi, Fa, So, La, Ti, Do.
 *
 *Difficulty Levels:
 *          Require Slash /(bass) notes
 *          Require Quality
 *          # of wrong answers allowed before fail
 *
 *
 *
 *              
 */
