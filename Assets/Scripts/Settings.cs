using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static float valueSens;
    public static float valueVol;
    public Slider sliderVol;
    public Slider sliderSens;

    private void Update()
    {
        valueVol = sliderVol.value;
        valueSens = sliderSens.value;
        PlayerPrefs.SetFloat("Volume", valueVol);
        PlayerPrefs.SetFloat("Sensevity", valueSens);
    }
    public void Volume() // Звук
    {
        // заглушка
    }

    public void Sensevity() // Чувствительность
    {

    }
}