using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    //----SENSITIVITY----
    [Header("Sensitivity")]
    public LookAround lookAroundScript;
    public Player304 player304Script;

    public Slider senseSlider;
    public TextMeshProUGUI senseNmbTxt;

    public float senseSlNmb;

    //----FOV----
    [Header("FOV")]
    public TextMeshProUGUI fovNmbTxt;
    public Slider fovSlider;
    public float fovNmb;


    //-Hold to zoom-
    public bool holdZoom;
    public bool isZooming;
    public Toggle zoomToggle;
    KeyCode zoomKey = KeyCode.V;
    public void Start()
    {
        senseNmbTxt.text = "";
        senseSlNmb = 5;
        fovNmb = 60;
        isZooming = false;
        holdZoom = true;
    }

    private void Update()
    {
        // --SENSITIVITY--
        //Avrundar sensen och ger 3 värdesiffror (om vill ha fyra ändra 100 till 1000), sedan displayar siffran
        senseSlNmb = Mathf.RoundToInt(100 * senseSlider.value);
        senseNmbTxt.text = (senseSlNmb / 100).ToString();
        SetSensitivity();

        //--FOV--
        fovNmb = Mathf.RoundToInt(fovSlider.value);
        fovNmbTxt.text = fovNmb.ToString();
        SetFov();

        //--Zoom--
        

    }

    public void SetSensitivity()
    {
        //Ändra sense
        senseSlNmb = senseSlNmb / 100;
        lookAroundScript.sensX = senseSlNmb;
        lookAroundScript.sensY = senseSlNmb;
        player304Script.sensitivity = senseSlNmb;
    }

    public void HoldZoomToggle(bool toggeValue)
    {
        holdZoom = toggeValue;
    }

    void SetFov()
    {
        float zoomFov = fovNmb - 0.2f * fovNmb;

        if (holdZoom == true)
        {
            //Zooms when the key is down
            if (Input.GetKey(zoomKey))
            {
                Camera.main.fieldOfView = zoomFov;
            }
            else
            {
                Camera.main.fieldOfView = fovNmb;
            }
        }
        else
        {
            //Changes if the player is zooming or not
            if (Input.GetKeyDown (zoomKey))
            {
                isZooming = !isZooming;
            }

            //Sets the fov to zoom or not
            if (isZooming == true)
            {
                Camera.main.fieldOfView = zoomFov;
            }
            else
            {
                Camera.main.fieldOfView = fovNmb;
            }
        }
        
    }
}
