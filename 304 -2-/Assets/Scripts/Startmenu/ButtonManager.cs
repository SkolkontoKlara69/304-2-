using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
   
    int pressNmbS;
    int pressNmbE;
    int pressNmbC;
    int pressNmbM;


    public GameObject settingsMenuObj;

    public void Start()
    {
         settingsMenuObj.SetActive(false);
    }

    public void OnStartButtonPress()
    {
        pressNmbS = DebugLogPressNmb("Start", pressNmbS);
        SceneManager.LoadScene("Level Selector");
        
        settingsMenuObj.SetActive(false);
    }


    public void OnCreditsButtonPress()
    {
        pressNmbC = DebugLogPressNmb("Credits", pressNmbC);
        SceneManager.LoadScene("Credits");
    }

    public void OnPausMenu()
    {
        settingsMenuObj.SetActive(false);
    }

    public void OnExitButtonPress()
    {
        pressNmbE = DebugLogPressNmb("Exit", pressNmbE);
        Application.Quit();
        
    }

    public void OnMenuButtonPress()
    {
        pressNmbM = DebugLogPressNmb("Start Menu", pressNmbM);
        SceneManager.LoadScene("Start menu");
    }

    public void OnSettingsPress()
    {
        settingsMenuObj.SetActive(true);
    }

    int DebugLogPressNmb(string buttonName, int pressNmb)
    {
        pressNmb++;
        Debug.Log(buttonName + " clicked " + pressNmb + " times.");
        return pressNmb;
    }
}
