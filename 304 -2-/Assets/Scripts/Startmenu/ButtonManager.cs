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

    public void OnStartButtonPress()
    {
        DebugLogPressNmb("Start", pressNmbS);
        SceneManager.LoadScene("Prison level utomhus");
    }


    public void OnCreditsButtonPress()
    {
        DebugLogPressNmb("Credits", pressNmbC);
    }


    public void OnExitButtonPress()
    {
        DebugLogPressNmb("Exit", pressNmbE);
    }

    void DebugLogPressNmb(string buttonName, int pressNmb)
    {
        pressNmb++;
        Debug.Log(buttonName + " clicked " + pressNmb + " times.");
    }
}
