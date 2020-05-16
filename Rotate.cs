using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float r;
    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(-1.666f, 1.666f);
        //Debug.Log(r);
        transform.Rotate(0, 0, Random.Range(-180f, 180f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, r * Time.deltaTime);
    }
}
