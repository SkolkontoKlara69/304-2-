using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    //----SENSITIVITY----
    public LookAround lookAroundScript;
    public Player304 player304Script;

    public Slider senseSlider;
    public TextMeshProUGUI senseNmbTxt;

    public float senseSlNmb;

    //----FOV----
    public TextMeshProUGUI fovNmbTxt;
    public Slider fovSlider;
    public float fovNmb;

    public void Start()
    {
        senseNmbTxt.text = "";
        senseSlNmb = 5;
        fovNmb = 60;
    }

    private void Update()
    {
        // --SENSITIVITY--
        //Avrundar sensen och ger 3 värdesiffror (om vill ha fyra ändra 100 till 1000), sedan displayar siffran
        senseSlNmb = Mathf.RoundToInt(100 * senseSlider.value);
        senseNmbTxt.text = (senseSlNmb/100).ToString();
        SetSensitivity();

        //--FOV--
        fovNmb = Mathf.RoundToInt(fovSlider.value);
        fovNmbTxt.text = fovNmb.ToString();
        Camera.main.fieldOfView = fovNmb;
    }


    public void SetSensitivity()
    {
        //Ändra sense
        senseSlNmb = senseSlNmb / 100;
        lookAroundScript.sensX = senseSlNmb;
        lookAroundScript.sensY = senseSlNmb;
        player304Script.sensitivity = senseSlNmb;
    }
}
