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
    [Header("Zoom")]
    public bool holdZoom;
    public bool isZooming;
    public Toggle zoomToggle;
    KeyCode zoomKey;


    


    //--Bindning keyes-
    [Header("Bindning keyes")]
    public PauseManager pauseManager;
    private bool waitingForKey;
    private KeyCode newKey;
    public TextMeshProUGUI activePauseKeyText;
    public TextMeshProUGUI activeZoomKeyText;
    public GameObject instructionsText;
    private string lastPushedBindButton;
    

    public void Start()
    {
        senseNmbTxt.text = "";
        senseSlNmb = 5;
        fovNmb = 60;
        isZooming = false;
        holdZoom = true;
        zoomKey = KeyCode.V;
        instructionsText.SetActive(false);
    }

    private void Update()
    {
        // --SENSITIVITY--
        SetSensitivity();

        //--FOV--
        fovNmb = Mathf.RoundToInt(fovSlider.value);
        fovNmbTxt.text = fovNmb.ToString();
        SetFov();

        //Bindning keyes
        activePauseKeyText.text = "Active Pause Key: " + pauseManager.pauseButton.ToString();
        activeZoomKeyText.text = "Active Zoom Key: " + zoomKey.ToString();

    }

    public void SetSensitivity()
    {
        //Avrundar sensen och ger 3 värdesiffror (om vill ha fyra ändra 100 till 1000), sedan displayar siffran
        senseSlNmb = Mathf.RoundToInt(100 * senseSlider.value);
        senseNmbTxt.text = (senseSlNmb / 100).ToString();


        //Ändra sense
        senseSlNmb = senseSlNmb / 100;
        lookAroundScript.sensX = senseSlNmb;
        lookAroundScript.sensY = senseSlNmb;
        player304Script.sensitivity = senseSlNmb;
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
            if (Input.GetKeyDown(zoomKey))
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

    public void OnGUI()
    {
        GetNewKey();
    }

    private void GetNewKey()
    {
        ///TODO fixa så att det inte pausas upp så fort som man bindat om den
        ///- det som just nu inte funkar än är timeOfBind och allt relaterat
        float timeOfBind = 0;
        Event e = Event.current;


        if (waitingForKey)
        {
            instructionsText.SetActive(true);

            if (e.isKey && e.keyCode != null)
            {
                timeOfBind = Time.realtimeSinceStartup;
                
                waitingForKey = false;
                instructionsText.SetActive(false);

            }

        }
        if (timeOfBind < Time.realtimeSinceStartup + 10 && timeOfBind > 0)
        {
            newKey = e.keyCode;
            SetKeyToNewKey();

        }

    }

    private void SetKeyToNewKey()
    {
        if (lastPushedBindButton == "Pause")
        {
            pauseManager.pauseButton = newKey;
        }
        else if (lastPushedBindButton == "Zoom")
        {
            zoomKey = newKey;
        }
    }

    public void OnBindPauseButtonClick()
    {
        waitingForKey = true;
        lastPushedBindButton = "Pause";

    }
    public void OnBindZoomButtonClick()
    {
        waitingForKey = true;
        lastPushedBindButton = "Zoom";
    }

    public void HoldZoomToggle(bool toggeValue)
    {
        holdZoom = toggeValue;
    }

}
