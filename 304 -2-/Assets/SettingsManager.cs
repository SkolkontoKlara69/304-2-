using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Text sensitivityText;

    public void SetSensitivity(float senseNmb)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Hämta en referens till spelarobjektets PlayerController-script.
        LookAround lookAroundScript = player.GetComponent<LookAround>();
        Player304 player304Script = player.GetComponent<Player304>();

        // Ändra hälsan på spelaren.
        lookAroundScript.sensX = senseNmb;
        lookAroundScript.sensY = senseNmb;
        player304Script.sensitivity = senseNmb;

        UpdateSensitivityText();
    }
    void UpdateSensitivityText()
    {

    }
}
