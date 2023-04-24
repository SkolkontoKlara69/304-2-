using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject player;
    public Text sensitivityText;

    public TextMeshProUGUI myTextMeshPro;

    float screenNmb;

    public void Start()
    {
        sensitivityText = GetComponent<Text>();
        myTextMeshPro.text = "";
    }

    private void Update()
    {
        // myTextMeshPro.text = "Hej";
        screenNmb = player.GetComponent<LookAround>().sensX;
        myTextMeshPro.text = screenNmb.ToString();
    }

    public void SetSensitivity(float senseNmb)
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Hämta en referens till spelarobjektets PlayerController-script.
        LookAround lookAroundScript = player.GetComponent<LookAround>();
        Player304 player304Script = player.GetComponent<Player304>();

        //Ändra sense
        lookAroundScript.sensX = senseNmb;
        lookAroundScript.sensY = senseNmb;
        player304Script.sensitivity = senseNmb;

        screenNmb = lookAroundScript.sensX;
        screenNmb = senseNmb;

        /*
        float screenNmb = 15f;
        myTextMeshPro.text = ": " + screenNmb;
        */
        //UpdateSensitivityText(senseNmb);
    }
    void UpdateSensitivityText(float screenNmb)
    {
        /*
        GameObject senseTextObj = GameObject.FindGameObjectWithTag("SenseNmb");
        screenNmb = 15;
        Text senseText = senseTextObj.GetComponent<Text>();

        senseText.text = screenNmb.ToString();*/


    }
    private void OnGUI()
    {
        //Display(screenNmb.ToString());
    }
}
