using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Always : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Settings.valueVol = PlayerPrefs.GetFloat("Volume");
        Settings.valueSens = PlayerPrefs.GetFloat("Sensevity");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
