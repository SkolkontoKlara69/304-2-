using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public bool paused;
    
    //vilken knapp som ska tryckas ned (just nu P)
    KeyCode pauseButton = KeyCode.P;

    /// <summary>
    /// F�r att l�gga in ett villkor i en annan kod f�r att bero p� om spelet �r pausat g�r man s�h�r:
    /// 1. l�gg in: 
    /// public PauseManager pauseManager;
    /// i det script du ska ha l�ngst upp i koden i classen, men utanf�r alla metoder. 
    /// 2. l�gg in pausemanagern scriptet sedan (antingen genom att dra in objektet PausManager i scenen eller genom att l�gga till scriptet dit direkt om det g�r)
    /// 3. skriv en if-sats i den fil du vill ha funktionen som beror p� om det �r pausat och skriv vilkoret:
    /// pauseManager.paused == false
    /// om du vill att allting som �r i if-satsen k�rs n�r spelet inte �r pausat. 
    /// 
    /// KOM VERKLIGEN IH�G ATT L�GGA IN PAUSEMANAGERN I ALLT SOM KAN PAUSAS, ANNARS KOMMER DE INTE ATT FUNGERA ALLS
    /// </summary>


    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            if (paused == false)
            {
                paused = true;

            }
            else
            {
                paused = false;

            }
            

        }
    }
}
