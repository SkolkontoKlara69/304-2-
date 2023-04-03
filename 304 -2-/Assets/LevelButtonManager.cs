using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour
{
    public void PrisonUtomhusButton()
    {
        LoadLevel("Prison level utomhus");
       
    }

    public void TutorialsButton()
    {
        LoadLevel("Tutorial Level");
    }
    public void tcbt2Button()
    {
        LoadLevel("Tcbt-level Våning 2");
    }
    void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
