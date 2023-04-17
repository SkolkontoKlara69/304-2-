using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public bool paused;
    
    //vilken knapp som ska tryckas ned (just nu P)
    KeyCode pauseButton = KeyCode.P;

    /// <summary>
    /// För att lägga in ett villkor i en annan kod för att bero på om spelet är pausat gör man såhär:
    /// 1. lägg in: 
    /// public PauseManager pauseManager;
    /// i det script du ska ha längst upp i koden i classen, men utanför alla metoder. 
    /// 2. lägg in pausemanagern scriptet sedan (antingen genom att dra in objektet PausManager i scenen eller genom att lägga till scriptet dit direkt om det går)
    /// 3. skriv en if-sats i den fil du vill ha funktionen som beror på om det är pausat och skriv vilkoret:
    /// pauseManager.paused == false
    /// om du vill att allting som är i if-satsen körs när spelet inte är pausat. 
    /// 
    /// KOM VERKLIGEN IHÅG ATT LÄGGA IN PAUSEMANAGERN I ALLT SOM KAN PAUSAS, ANNARS KOMMER DE INTE ATT FUNGERA ALLS
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
