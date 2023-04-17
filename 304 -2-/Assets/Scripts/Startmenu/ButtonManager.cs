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

    public void OnStartButtonPress()
    {
        pressNmbS = DebugLogPressNmb("Start", pressNmbS);
        SceneManager.LoadScene("Level Selector");
    }


    public void OnCreditsButtonPress()
    {
        pressNmbC = DebugLogPressNmb("Credits", pressNmbC);
        SceneManager.LoadScene("Credits");
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

    int DebugLogPressNmb(string buttonName, int pressNmb)
    {
        pressNmb++;
        Debug.Log(buttonName + " clicked " + pressNmb + " times.");
        return pressNmb;
    }
}
